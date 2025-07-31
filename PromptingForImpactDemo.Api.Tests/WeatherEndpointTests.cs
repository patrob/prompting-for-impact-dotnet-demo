using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace PromptingForImpactDemo.Api.Tests
{
    /// <summary>
    /// Tests for the Weather API endpoint as described in prd.md user stories.
    /// </summary>
    public class WeatherEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly IFixture _fixture;

        public WeatherEndpointTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _fixture = new Fixture();
        }

        [Fact(DisplayName = "Should return BadRequest when city is missing (PRD 1, 3)")]
        public async Task GetWeather_MissingCity_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var state = _fixture.Create<string>();

            // Act
            var response = await client.GetAsync($"/weather?state={state}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact(DisplayName = "Should return BadRequest when state is missing (PRD 1, 3)")]
        public async Task GetWeather_MissingState_ReturnsBadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var city = _fixture.Create<string>();

            // Act
            var response = await client.GetAsync($"/weather?city={city}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory(DisplayName = "Should return BadRequest for invalid city or state (PRD 1, 3)")]
        [InlineData("", "CA")]
        [InlineData("Los Angeles", "")]
        [InlineData(" ", "NY")]
        [InlineData("Seattle", " ")]
        public async Task GetWeather_InvalidCityOrState_ReturnsBadRequest(string city, string state)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/weather?city={city}&state={state}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact(DisplayName = "Should return weather data for valid city and state (PRD 2)")]
        public async Task GetWeather_ValidRequest_ReturnsWeatherData()
        {
            // Arrange
            var client = _factory.CreateClient();
            var city = "Seattle";
            var state = "WA";

            // Act
            var response = await client.GetAsync($"/weather?city={city}&state={state}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var weather = await response.Content.ReadFromJsonAsync<WeatherResponse>();
            weather.Should().NotBeNull();
            weather!.Temperature.Should().NotBe(0);
            weather.Humidity.Should().BeInRange(0, 100);
            weather.Conditions.Should().NotBeNullOrWhiteSpace();
        }

        [Fact(DisplayName = "Should return NotFound when weather data is unavailable (PRD 3)")]
        public async Task GetWeather_LocationNotFound_ReturnsNotFound()
        {
            // Arrange
            var client = _factory.CreateClient();
            var city = "Nowhereville";
            var state = "ZZ";

            // Act
            var response = await client.GetAsync($"/weather?city={city}&state={state}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact(DisplayName = "Should return InternalServerError when weather service throws (PRD 3)")]
        public async Task GetWeather_WeatherServiceThrows_ReturnsServerError()
        {
            // Arrange
            var client = _factory.CreateClient();
            var city = "Seattle";
            var state = "WA";

            // Simulate service failure (details depend on implementation)
            // This test will need to be updated once DI/mocking is set up.

            // Act
            var response = await client.GetAsync($"/weather?city={city}&state={state}&simulateError=true");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        // Helper DTO for deserialization
        private class WeatherResponse
        {
            public double Temperature { get; set; }
            public int Humidity { get; set; }
            public string Conditions { get; set; } = string.Empty;
        }
    }
}
