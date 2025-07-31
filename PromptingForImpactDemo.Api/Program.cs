using Scalar.AspNetCore;



using PromptingForImpactDemo.Api;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IWeatherService, WeatherService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection();

// Minimal API endpoint for /weather
/// <summary>
/// Weather endpoint: returns current weather for a given city and state.
/// </summary>
app.MapGet("/weather", (
    string? city,
    string? state,
    bool? simulateError,
    IWeatherService weatherService) =>
{
    // Validate input using helper
    var validationError = WeatherValidation.ValidateCityState(city, state);
    if (validationError is not null)
    {
        return Results.BadRequest(validationError);
    }

    try
    {
        var result = weatherService.GetWeather(city!.Trim(), state!.Trim(), simulateError ?? false);
        if (result is null)
        {
            return Results.NotFound();
        }
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        // Log error (placeholder)
        // logger?.LogError(ex, "Weather service failed");
        return Results.Problem("An unexpected error occurred while retrieving weather data.", statusCode: 500);
    }
})
.WithName("GetWeather");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}