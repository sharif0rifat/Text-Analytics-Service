using Newtonsoft.Json;
using System.Linq;
using TextAnalyticsService.TextAnalyzerService.Interfaces;
using TextAnalyticsService.ViewModels;

namespace TextAnalyticsService.TextAnalyzerService.Implementations
{
    public class TextAnalyzerService : ITextAnalyzerService
    {
        private readonly char[] puntuations;

        public TextAnalyzerService() {
            puntuations = new char[] { ',', '.', '?', '!', '\'', '/', ':', '*' };
        }
        public TextAnalyzeResult Analyze(string text)
        {
            TextInput input = JsonConvert.DeserializeObject<TextInput>(text);
            TextAnalyzeResult result = new TextAnalyzeResult();
            result.CharCount = input.Text.Where(i => !puntuations.Any(x=>x==i) && i!=' ').Count();      //Ass Puntuation and character are not counted
            result.WordCount = input.Text.Split(' ').Count();
            result.SentenceCount = input.Text.Split('.').Count();
            result.MostFrequentWord = GetMostFrequentWord(input.Text);
            result.LongestWord = GetLonestWord(input.Text);
            
            return result;
        }

        private LongestWord GetLonestWord(string text)
        {
            string temp = text.ToLower();
            //As punctuation are not counted as characters, we need to remove them from string
            temp = temp.Trim(puntuations);
            var wordArray = temp.Split(' ');
            wordArray = wordArray.OrderByDescending(i => i.Length).ToArray();
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
                if(wordCount.ContainsKey(word))
                    wordCount[word]++;
                else
                    wordCount.Add(word, 1);
            }
            wordCount = wordCount.OrderByDescending(i => i.Value).Select(i => i).ToDictionary(x => x.Key, x => x.Value);
            return new MostFrequentWord { Word = wordCount.First().Key, Frequency = wordCount.First().Value };
        }
    }
}
