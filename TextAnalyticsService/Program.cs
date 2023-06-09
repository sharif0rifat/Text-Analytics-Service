using TextAnalyticsService.TextAnalyzerService.Implementations;
using TextAnalyticsService.TextAnalyzerService.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//dependency injection
builder.Services.AddScoped<ITextAnalyzerService, TextAnalyzerService>();
builder.Services.AddScoped<ISimilarityCalculatorService, SimilarityCalculatorService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();
