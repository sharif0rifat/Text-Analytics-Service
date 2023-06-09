using Newtonsoft.Json;
using System.Linq;
using TextAnalyticsService.TextAnalyzerService.Interfaces;
using TextAnalyticsService.ViewModels;

namespace TextAnalyticsService.TextAnalyzerService.Implementations
{
    public class TextAnalyzerService : ITextAnalyzerService
    {
        public TextAnalyzeResult Analyze(string text)
        {
            TextInput input = JsonConvert.DeserializeObject<TextInput>(text);
            TextAnalyzeResult result = new TextAnalyzeResult();
            result.CharCount = input.Text.Where(i => i != ' ').Count();
            result.WordCount = input.Text.Split(' ').Count();
            result.SentenceCount = input.Text.Split('.').Count();
            result.MostFrequentWord = GetMostFrequentWord(input.Text);
            result.LongestWord = GetLonestWord(input.Text);
            
            return result;
        }

        private LongestWord GetLonestWord(string text)
        {
            string temp = text.ToLower();
            var wordArray = temp.Split(' ');
            wordArray = wordArray.OrderBy(i => i.Length).ToArray();
            return new LongestWord
            {
                Word = wordArray.First(),
                Length = wordArray.First().Length,
            };
        }

        private MostFrequentWord GetMostFrequentWord(string text)
        {
            string temp = text.ToLower();
            var wordArray = temp.Split(' ');
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var word in wordArray)
            {
                var wordValue = wordCount[word];
                if (wordValue == 0)
                    wordCount.Add(word, 1);
                else
                    wordCount[word]++;
            }
            wordCount = wordCount.OrderBy(i => i.Value).Select(i => i).ToDictionary(x => x.Key, x => x.Value);
            return new MostFrequentWord { Word = wordCount.First().Key, Frequency = wordCount.First().Value };
        }
    }
}
