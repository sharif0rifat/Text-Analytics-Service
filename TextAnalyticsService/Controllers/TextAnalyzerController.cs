using Microsoft.AspNetCore.Mvc;
using TextAnalyticsService.TextAnalyzerService.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace TextAnalyticsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextAnalyzerController : ControllerBase
    {
        private readonly ITextAnalyzerService _textAnalyzerService;
        private readonly ISimilarityCalculatorService _similarityCalculatorService;

        public TextAnalyzerController(ITextAnalyzerService textAnalyzerService, ISimilarityCalculatorService similarityCalculatorService)
        {
            this._textAnalyzerService = textAnalyzerService;
            this._similarityCalculatorService = similarityCalculatorService;
        }

        [HttpPost("analyze")]
        public IActionResult Analyze(string textToAnalyze)
        {
            var result= _textAnalyzerService.Analyze(textToAnalyze);
            return Ok(result);
        }

        [HttpPost("similarities")]
        public IActionResult GetSimilarities(string textToAnalyze)
        {
            var result= _similarityCalculatorService.GetTextSimilarity(textToAnalyze);
            return Ok(result);
        }
    }
}