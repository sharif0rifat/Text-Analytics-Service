using TextAnalyticsService.ViewModels;

namespace TextAnalyticsService.TextAnalyzerService.Interfaces
{
    public interface ITextAnalyzerService
    {
        TextAnalyzeResult Analyze(string text);
    }
}
