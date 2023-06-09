using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace TextAnalyticsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextAnalyzerController : ControllerBase
    {
        public TextAnalyzerController()
        {
        }

        [HttpPost("analyze")]
        public IActionResult Analyze(string textToAnalyze)
        {
            return Ok(textToAnalyze);
        }

        [HttpPost("similarities")]
        public IActionResult GetSimilarities(string textToAnalyze)
        {
            return Ok(textToAnalyze);
        }
    }
}