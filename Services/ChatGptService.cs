using OpenAI_API.Completions;
using OpenAI_API;
using System.Net.Http.Headers;

namespace SkipClip.Services
{
    public class ChatGptService : IChatGptService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ChatGptService(IConfiguration config)
        {
            _apiKey = config.GetValue<string>("ChatGpt:OpenAIKey") ?? string.Empty; ;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openai.com/v1/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }
        public async Task<string> GenerateSummary(string transcript)
        {
            var openAI = new OpenAIAPI(_apiKey);
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = "Summarize this transcript: " + transcript;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 100;
            var completions = await openAI.Completions.CreateCompletionAsync(completionRequest);
            var content = completions.Completions.ToString();
            if (content != null)
            {
                return content;
            }
            return "No Content";
        }
    }
}
