using TextAnalyticsService.ViewModels;

namespace TextAnalyticsService.TextAnalyzerService.Interfaces
{
    public interface ISimilarityCalculatorService
    {
        TextSimilarityResult GetTextSimilarity(string textInput);
    }
}
