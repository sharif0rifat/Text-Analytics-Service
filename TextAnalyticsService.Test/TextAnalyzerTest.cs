using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http.Results;
using TextAnalyticsService.Controllers;
using TextAnalyticsService.TextAnalyzerService.Interfaces;
using TextAnalyticsService.ViewModels;
using Xunit;

namespace TextAnalyticsService.Test
{
    public class TextAnalyzerTest
    {
        public ITextAnalyzerService? textAnalyzerService { get; }

        public TextAnalyzerTest() {
            var services = new ServiceCollection();
            services.AddTransient<ITextAnalyzerService, TextAnalyzerService.Implementations.TextAnalyzerService>();
            var serviceProvider = services.BuildServiceProvider();
            textAnalyzerService = serviceProvider.GetService<ITextAnalyzerService>();
        }

        [Fact]
        public  void Check_Analyze_The_Text_Returns_Correct_Character_Count()
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
        
        [Fact]
        public void Check_Analyze_That_Returns_Error()
        {
            //Arrange 
            //The Text is wrong having extra '"' 
            var input = "{\r\n\"text\": \"The quick brown fox jumps over the lazy dog\". The dog was\r\nnot amused.\"\r\n}";
            var controller = new TextAnalyzerController(textAnalyzerService, null);

            //Act
            var actionResult = controller.Analyze(input);

            
            // Assert
            Assert.IsType(typeof(BadRequestObjectResult), actionResult);
            var response = actionResult as BadRequestObjectResult;
            Assert.Equal(response.Value, "The Text is not valid");
        }

        [Fact]
        public void Check_Analyze_That_Empty_Text_Returns_Error()
        {
            //Arrange 
            //The Text is wrong having extra '"' 
            var input = "{\r\n\"text\":\"\"}";
            var controller = new TextAnalyzerController(textAnalyzerService, null);

            //Act
            var actionResult = controller.Analyze(input);


            // Assert
            Assert.IsType(typeof(BadRequestObjectResult), actionResult);
            var response = actionResult as BadRequestObjectResult;
            Assert.Equal(response.Value, "The text is Empty");
        }
    }
}