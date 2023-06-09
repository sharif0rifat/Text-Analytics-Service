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

        [HttpGet(Name = "GetTextAnalyzer")]
        public IActionResult Get()
        {
            return Ok("This Is just");
        }
    }
}