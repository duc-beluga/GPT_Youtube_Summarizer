using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using OpenAI_API;
using OpenAI_API.Completions;
using System.Diagnostics;

namespace SkipClip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatGptController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ChatGptController(IConfiguration config)
        {
            _apiKey = config.GetValue<string>("ChatGpt:OpenAIKey") ?? string.Empty; ;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openai.com/v1/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        [HttpPost("SendPrompt")]
        public async Task<IActionResult> SendPrompt([FromBody] string msg)
        {
            var openAI = new OpenAIAPI(_apiKey);
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = "Summarize this transcript: " + msg;
            completionRequest.Model = OpenAI_API.Models.Model.AdaText;
            var completions = await openAI.Completions.CreateCompletionAsync(completionRequest);

            return Ok(completions.Completions);
        }
    }
}
