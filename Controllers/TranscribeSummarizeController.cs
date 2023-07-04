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
        public IActionResult TranscribeAndSummarizeVideo(string videoUrl)
        {
            // Step 1: Transcribe the video using Video Indexer
            var transcriptionResult = videoIndexerService.TranscribeVideo(videoUrl);

            // Step 2: Pass the transcription to the ChatGPT service for summarization
            var summary = chatGptService.GenerateSummary(transcriptionResult.Transcription);

            // Handle and return the summary
            // ...
        }
    }
}
