using Newtonsoft.Json;
using TextAnalyticsService.TextAnalyzerService.Interfaces;
using TextAnalyticsService.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace TextAnalyticsService.TextAnalyzerService.Implementations
{
    public class SimilarityCalculatorService : ISimilarityCalculatorService
    {
        public TextSimilarityResult GetTextSimilarity(string textInput)
        {
            TextInputMultiple input = JsonConvert.DeserializeObject<TextInputMultiple>(textInput);
            double similarity1 = GetSimilarityPercent(input.Text1, input.Text2);
            double similarity2 = GetSimilarityPercent(input.Text1, input.Text2);

            return new TextSimilarityResult
            {
                Similarity = (similarity1 + similarity2) / 2,
            };
        }

        private double GetSimilarityPercent(string text1, string text2)
        {
            var words1 = text1.Split(' ');
            var words2 = text2.Split(' ');
            var similar = words1.Where(i => words2.Any(x => x == i)).Count();
            return similar / words1.Length * 100;
        }
    }
}
