using System;

namespace PromptingForImpactDemo.Api
{
    /// <summary>
    /// Fake implementation for TDD green phase.
    /// </summary>
    public class WeatherService : IWeatherService
    {
        public WeatherResult? GetWeather(string city, string state, bool simulateError = false)
        {
            if (simulateError)
            {
                throw new Exception("Simulated service failure");
            }
            if (city == "Nowhereville" && state == "ZZ")
            {
                return null;
            }
            if (city == "Seattle" && state == "WA")
            {
                return new WeatherResult
                {
                    Temperature = 72.0,
                    Humidity = 55,
                    Conditions = "Sunny"
                };
            }
            return null;
        }
    }
}
