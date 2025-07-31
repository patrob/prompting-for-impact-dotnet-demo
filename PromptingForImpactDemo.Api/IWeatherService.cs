namespace PromptingForImpactDemo.Api
{
    /// <summary>
    /// Abstraction for weather data retrieval.
    /// </summary>
    public interface IWeatherService
    {
        WeatherResult? GetWeather(string city, string state, bool simulateError = false);
    }

    public class WeatherResult
    {
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public string Conditions { get; set; } = string.Empty;
    }
}
