using System.Net;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace PromptingForImpactDemo.Api.Tests
{
    public class WeatherForecastEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public WeatherForecastEndpointTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact(DisplayName = "GetWeatherByCityAndState_ValidInput_ReturnsWeatherForecast")]
        public async Task GetWeatherByCityAndState_ValidInput_ReturnsWeatherForecast()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/weatherforecast/Texas/Austin");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("Austin");
            content.Should().Contain("TEXAS");
        }

        [Fact(DisplayName = "GetWeatherByCityAndState_EmptyInput_ReturnsBadRequest")]
        public async Task GetWeatherByCityAndState_EmptyInput_ReturnsBadRequest()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/weatherforecast//Austin");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact(DisplayName = "GetWeatherByCityAndState_InvalidCharacters_ReturnsBadRequest")]
        public async Task GetWeatherByCityAndState_InvalidCharacters_ReturnsBadRequest()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/weatherforecast/T3xas/Aust1n");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
