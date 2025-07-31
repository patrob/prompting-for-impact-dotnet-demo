using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace PromptingForImpactDemo.Api.Tests;

public class WeatherEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WeatherEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("CA", "Los Angeles")]
    [InlineData("NY", "New York")]
    public async Task WeatherEndpoint_ReturnsOk_WithValidParams(string state, string city)
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/weather?state={state}&city={city}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var json = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        Assert.NotNull(json);
        Assert.Equal(state, json["state"]?.ToString());
        Assert.Equal(city, json["city"]?.ToString());
    }

    [Theory]
    [InlineData("", "Los Angeles")]
    [InlineData("CA", "")]
    public async Task WeatherEndpoint_ReturnsBadRequest_WhenMissingParams(string state, string city)
    {
        var client = _factory.CreateClient();
        var url = "/weather";
        // Only add params if not empty
        if (!string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(city))
            url += $"?state={state}&city={city}";
        else if (!string.IsNullOrEmpty(state))
            url += $"?state={state}";
        else if (!string.IsNullOrEmpty(city))
            url += $"?city={city}";
        var response = await client.GetAsync(url);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task WeatherEndpoint_ReturnsBadRequest_WhenNoParams()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/weather");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
