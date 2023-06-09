using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TextAnalyticsService.ViewModels
{
    public struct TextAnalyzeResult
    {
        public int CharCount { get; set; }
        public int WordCount { get; set; }
        public int SentenceCount { get; set; }
        public MostFrequentWord MostFrequentWord { get; set; }
        public LongestWord LongestWord { get; set; }
    }
    public struct MostFrequentWord {
        public string Word { get; set; }
        public int Frequency { get; set; }
    }
    public struct LongestWord {
        public string Word { get; set; }
        public int Length { get; set; }
    }
}