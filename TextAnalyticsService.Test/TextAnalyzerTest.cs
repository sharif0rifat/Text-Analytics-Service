using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TextAnalyticsService.Controllers;
using TextAnalyticsService.TextAnalyzerService.Implementations;
using TextAnalyticsService.TextAnalyzerService.Interfaces;
using TextAnalyticsService.ViewModels;
using Xunit;

namespace TextAnalyticsService.Test
{
    public class TextAnalyzerTest
    {
        private readonly ServiceProvider serviceProvider;
        public ITextAnalyzerService? textAnalyzerService { get; }

        public TextAnalyzerTest() {
            var services = new ServiceCollection();
            services.AddTransient<ITextAnalyzerService, TextAnalyzerService.Implementations.TextAnalyzerService>();

            serviceProvider = services.BuildServiceProvider();
            textAnalyzerService = serviceProvider.GetService<ITextAnalyzerService>();
        }
        [Fact]
        public  void Analyze_The_Text_Returns_Correct_Character_Count()
        {
            //Arrange
            var input = "{\r\n\"text\": \"The quick brown fox jumps over the lazy dog. The dog was\r\nnot amused.\"\r\n}";
            var controller = new TextAnalyzerController(textAnalyzerService, null);
            
            //Act
            var actionResult = controller.Analyze(input) as OkObjectResult;
            //Test
            var result = (TextAnalyzeResult)actionResult.Value;
            Assert.Equal(result.CharCount, 53);
        }
    }
}