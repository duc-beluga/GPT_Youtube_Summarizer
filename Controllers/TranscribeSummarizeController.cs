using Microsoft.AspNetCore.Mvc;
using SkipClip.Services;

namespace SkipClip.Controllers
{
    [ApiController]
    [Route("api/transcribe-summarize")]
    public class TranscribeSummarizeController : ControllerBase
    {
        private readonly IVideoIndexerService videoIndexerService;
        private readonly IChatGptService chatGptService;

        public TranscribeSummarizeController(IVideoIndexerService videoIndexerService, IChatGptService chatGptService)
        {
            this.videoIndexerService = videoIndexerService;
            this.chatGptService = chatGptService;
        }

        [HttpPost]
        public async Task<IActionResult> TranscribeAndSummarizeVideo([FromBody] TranscriptionRequest request)
        {
            // Step 1: Transcribe the video using Video Indexer
            var transcriptionResult = await videoIndexerService.TranscribeVideo(request.videoUrl);
            if (transcriptionResult == null)
            {
                return NotFound("Invalid URL");
            }
            // Step 2: Pass the transcription to the ChatGPT service for summarization
            var summary = await chatGptService.GenerateSummary(transcriptionResult, request.wordLimits);
            if (summary == null)
            {
                return StatusCode(500, "Cannot Summarize Content (Invalid API, Model,...)");
            }
            return Ok(summary);
        }
        public class TranscriptionRequest
        {
            public string videoUrl { get; set; }
            public string wordLimits { get; set; }
        }
    }
}
