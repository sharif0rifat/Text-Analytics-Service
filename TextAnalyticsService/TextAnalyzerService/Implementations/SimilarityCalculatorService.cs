using Newtonsoft.Json;
using TextAnalyticsService.TextAnalyzerService.Interfaces;
using TextAnalyticsService.ViewModels;

namespace TextAnalyticsService.TextAnalyzerService.Implementations
{
    public class SimilarityCalculatorService : ISimilarityCalculatorService
    {
        public TextSimilarityResult GetTextSimilarity(string textInput)
        {
            TextInputMultiple input = JsonConvert.DeserializeObject<TextInputMultiple>(textInput);
            float similarity1 = GetSimilarityPercent(input.Text1, input.Text2);
            float similarity2 = GetSimilarityPercent(input.Text2, input.Text1);

            return new TextSimilarityResult
            {
                Similarity = ((float)(similarity1 + similarity2) / 2).ToString("0.00"),
            };
        }

        private float GetSimilarityPercent(string text1, string text2)
        {
            var words1 = text1.Split(' ');
            var words2 = text2.Split(' ');
            var similar = words1.Where(i => words2.Any(x => x == i)).Count();
            return (float)(similar*100) / words1.Length;
        }
    }
}
