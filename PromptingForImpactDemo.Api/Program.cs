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

// Minimal API for weather by city/state
app.MapGet("/weather", (string? state, string? city) =>
{
    if (string.IsNullOrWhiteSpace(state) || string.IsNullOrWhiteSpace(city))
    {
        return Results.BadRequest("Both state and city must be provided.");
    }
    var weather = new Dictionary<string, object>
    {
        { "state", state },
        { "city", city },
        { "temperatureC", 25 },
        { "temperatureF", 77 },
        { "summary", "Sunny" },
        { "date", DateTime.UtcNow }
    };
    return Results.Ok(weather);
})
.WithName("GetWeatherByCityState");

app.Run();

public partial class Program { }

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}