using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoIndexController : ControllerBase
    {
        private readonly string _apiUrl;
        private readonly string _accountId;
        private readonly string _location;
        private readonly string _apiKey;

        public VideoIndexController(IConfiguration config)
        {
            _apiUrl = config.GetValue<string>("VideoIndexer:ApiUrl") ?? string.Empty;
            _accountId = config.GetValue<string>("VideoIndexer:AccountId") ?? string.Empty;
            _location = config.GetValue<string>("VideoIndexer:Location") ?? string.Empty;
            _apiKey = config.GetValue<string>("VideoIndexer:ApiKey") ?? string.Empty;
        }

        [HttpPost("UploadVideo")]
        public async Task<IActionResult> UploadVideo([FromBody] string videoUrl)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.ServicePointManager.SecurityProtocol | System.Net.SecurityProtocolType.Tls12;

                // create the http client
                var handler = new HttpClientHandler();
                handler.AllowAutoRedirect = false;
                var client = new HttpClient(handler);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);

                // obtain account access token
                var accountAccessTokenRequestResult = await client.GetAsync($"{_apiUrl}/auth/{_location}/Accounts/{_accountId}/AccessToken?allowEdit=true");
                var accountAccessToken = await accountAccessTokenRequestResult.Content.ReadAsStringAsync();
                accountAccessToken = accountAccessToken.Replace("\"", "");

                client.DefaultRequestHeaders.Remove("Ocp-Apim-Subscription-Key");

                // upload a video
                var uploadRequestResult = await client.PostAsync($"{_apiUrl}/{_location}/Accounts/{_accountId}/Videos?accessToken={accountAccessToken}&name=some_name&description=some_description&privacy=private&partition=some_partition&videoUrl={videoUrl}", null);
                var uploadResult = await uploadRequestResult.Content.ReadAsStringAsync();

                // get the video id from the upload result
                var videoId = JsonConvert.DeserializeObject<dynamic>(uploadResult)["id"];

                // obtain video access token
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);
                var videoTokenRequestResult = await client.GetAsync($"{_apiUrl}/auth/{_location}/Accounts/{_accountId}/Videos/{videoId}/AccessToken?allowEdit=true");
                var videoAccessToken = await videoTokenRequestResult.Content.ReadAsStringAsync();
                videoAccessToken = videoAccessToken.Replace("\"", "");

                client.DefaultRequestHeaders.Remove("Ocp-Apim-Subscription-Key");

                // wait for the video index to finish
                while (true)
                {
                    await Task.Delay(10000);

                    var videoGetIndexRequestResult = await client.GetAsync($"{_apiUrl}/{_location}/Accounts/{_accountId}/Videos/{videoId}/Index?accessToken={videoAccessToken}&language=English");
                    var videoGetIndexResult = await videoGetIndexRequestResult.Content.ReadAsStringAsync();
                    var videoIndexData = JsonConvert.DeserializeObject<dynamic>(videoGetIndexResult);

                    if (videoIndexData?.videos?[0]?.insights?.transcript != null)
                    {
                        var processingState = JsonConvert.DeserializeObject<dynamic>(videoGetIndexResult)["state"];

                        // job is finished
                        if (processingState != "Uploaded" && processingState != "Processing")
                        {
                            var transcript = JsonConvert.DeserializeObject<dynamic>(videoGetIndexResult)["videos"][0]["insights"]["transcript"];
                            return Ok(transcript);
                        }
                    }
                    else
                    {
                        return StatusCode(400, "Invalid URL, 404, API returns null");
                    }

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred during video upload and processing: " + ex.ToString());
            }
        }
    }
}
