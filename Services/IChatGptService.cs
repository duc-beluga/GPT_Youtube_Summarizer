namespace SkipClip.Services
{
    public interface IChatGptService
    {
        Task<string> GenerateSummary(string transcript, string wordLimits);
    }
}
