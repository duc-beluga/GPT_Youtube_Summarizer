namespace SkipClip.Services
{
    public interface IVideoIndexerService
    {
        Task<string> TranscribeVideo(string videoUrl);
    }
}
