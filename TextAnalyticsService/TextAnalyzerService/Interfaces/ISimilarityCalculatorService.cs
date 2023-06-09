using TextAnalyticsService.Helper;
using TextAnalyticsService.ViewModels;

namespace TextAnalyticsService.TextAnalyzerService.Interfaces
{
    public interface ISimilarityCalculatorService
    {
        ResponseResult GetTextSimilarity(string textInput);
    }
}
