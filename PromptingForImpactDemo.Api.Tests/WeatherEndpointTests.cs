using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace PromptingForImpactDemo.Api.Tests
{
    public class WeatherEndpointTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public WeatherEndpointTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("CA", "SanFrancisco")]
        [InlineData("NY", "NewYork")]
        public async Task GetWeatherForCity_ReturnsWeather(string state, string city)
        {
            var response = await _client.GetAsync($"/weather/{state}/{city}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<WeatherResponse>();
            Assert.NotNull(result);
            Assert.Equal(state, result.State);
            Assert.Equal(city, result.City);
            Assert.NotNull(result.Weather);
        }

        private class WeatherResponse
        {
            public string? State { get; set; }
            public string? City { get; set; }
            public WeatherForecastDto? Weather { get; set; }
        }

        private class WeatherForecastDto
        {
            public string? Date { get; set; }
            public int TemperatureC { get; set; }
            public int TemperatureF { get; set; }
            public string? Summary { get; set; }
        }
    }
}
