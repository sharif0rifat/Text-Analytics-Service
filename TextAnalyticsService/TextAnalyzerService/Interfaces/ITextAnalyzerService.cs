using TextAnalyticsService.Helper;
using TextAnalyticsService.ViewModels;

namespace TextAnalyticsService.TextAnalyzerService.Interfaces
{
    public interface ITextAnalyzerService
    {
        ResponseResult Analyze(string text);
    }
}
