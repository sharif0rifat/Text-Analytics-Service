using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TextAnalyticsService.Controllers;
using TextAnalyticsService.TextAnalyzerService.Implementations;
using TextAnalyticsService.TextAnalyzerService.Interfaces;
using TextAnalyticsService.ViewModels;

namespace TextAnalyticsService.Test
{
    public class TextSimilarityTest
    {
        //private readonly ServiceProvider serviceProvider;
        public ISimilarityCalculatorService? similarityCalculatorService { get; }

        public TextSimilarityTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<ISimilarityCalculatorService, SimilarityCalculatorService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            similarityCalculatorService =  serviceProvider.GetService<ISimilarityCalculatorService>();
        }

        [Fact]
        public void Check_Text_Similarities_Returns_Correct_Value()
        {
            //Arrange
            var input = "{\r\n\"text1\": \"The quick brown fox jumps over the lazy dog\",\r\n\"text2\": \"The dog was not amused\"\r\n}";
            var controller = new TextAnalyzerController(null, similarityCalculatorService);

            //Act
            var actionResult = controller.GetSimilarities(input) as OkObjectResult;
            //Test
            var result = (TextSimilarityResult)actionResult.Value;
            Assert.Equal(result.Similarity, "31.11");
        }
        [Fact]
        public void Check_Text_Similarities_That_Returns_Error()
        {
            //Arrange 
            //The Text is wrong having extra '"' 
            var input = "{\r\n\"text\": \"The quick brown fox jumps over the lazy dog\". The dog was\r\nnot amused.\"\r\n}";
            var controller = new TextAnalyzerController(null, similarityCalculatorService);

            //Act
            var actionResult = controller.GetSimilarities(input);


            // Assert
            Assert.IsType(typeof(BadRequestObjectResult), actionResult);
            var response = actionResult as BadRequestObjectResult;
            Assert.Equal(response.Value, "The Text is not valid");
        }
        [Fact]
        public void Check_Text_Similarities_That_Empty_Text_Returns_Error()
        {
            //Arrange 
            //The Text is wrong having extra '"' 
            var input = "{\r\n\"text1\": \"The quick brown fox jumps over the lazy dog\",\r\n\"text2\": \"\"\r\n}";
            var controller = new TextAnalyzerController(null, similarityCalculatorService);

            //Act
            var actionResult = controller.GetSimilarities(input);

            // Assert
            Assert.IsType(typeof(BadRequestObjectResult), actionResult);
            var response = actionResult as BadRequestObjectResult;
            Assert.Equal(response.Value, "One of the text is empty");
        }
    }
}
