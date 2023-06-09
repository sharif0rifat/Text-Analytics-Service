using Newtonsoft.Json;
using TextAnalyticsService.Helper;
using TextAnalyticsService.TextAnalyzerService.Interfaces;
using TextAnalyticsService.ViewModels;

namespace TextAnalyticsService.TextAnalyzerService.Implementations
{
    public class SimilarityCalculatorService : ISimilarityCalculatorService
    {
        public ResponseResult GetTextSimilarity(string textInput)
        {
            try
            {
                if (!JsonValidator.ValidateJson<TextInputMultiple>(textInput))
                    return ResponseResult.Fail("The Text is not valid");
                TextInputMultiple input = JsonConvert.DeserializeObject<TextInputMultiple>(textInput);
                float similarity1 = GetSimilarityPercent(input.Text1, input.Text2);
                float similarity2 = GetSimilarityPercent(input.Text2, input.Text1);
                return ResponseResult.Successs("Similarity found",
                    new TextSimilarityResult
                    {
                        Similarity = ((float)(similarity1 + similarity2) / 2).ToString("0.00"),
                    });
            }
            catch (Exception)
            {
                return ResponseResult.Fail("Some error happened while analyzing text");
            }
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
