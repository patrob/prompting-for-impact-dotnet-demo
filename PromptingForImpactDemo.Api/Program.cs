using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


// Existing endpoint
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

// New endpoint: /weatherforecast/{state}/{city}
app.MapGet("/weatherforecast/{state}/{city}",
    (string state, string city) =>
    {
        // Input validation: state and city must be non-empty, alpha only
        if (string.IsNullOrWhiteSpace(state) || string.IsNullOrWhiteSpace(city))
        {
            return Results.BadRequest("State and city are required.");
        }
        if (!state.All(char.IsLetter) || !city.All(c => char.IsLetter(c) || c == ' '))
        {
            return Results.BadRequest("State and city must contain only letters and spaces.");
        }

        // Demo: Generate a single weather forecast for the city/state
        var forecast = new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now),
            Random.Shared.Next(-20, 55),
            $"{summaries[Random.Shared.Next(summaries.Length)]} in {city}, {state.ToUpper()}"
        );
        return Results.Ok(forecast);
    })
    .WithName("GetWeatherByCityAndState")
    .WithSummary("Get weather for a specific city and state.")
    .WithDescription("Returns a weather forecast for the specified city and state. Useful for demo/testing.")
    .Produces<WeatherForecast>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest);


app.Run();

// For integration testing
public partial class Program { }

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}