namespace PromptingForImpactDemo.Api
{
    /// <summary>
    /// Helper for validating weather endpoint input.
    /// </summary>
    public static class WeatherValidation
    {
        /// <summary>
        /// Validates city and state input for the weather endpoint.
        /// </summary>
        /// <param name="city">City name</param>
        /// <param name="state">State code</param>
        /// <returns>Error message if invalid, otherwise null</returns>
        public static string? ValidateCityState(string? city, string? state)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return "Missing or invalid city parameter.";
            }
            if (string.IsNullOrWhiteSpace(state))
            {
                return "Missing or invalid state parameter.";
            }
            // Optionally, add further validation (e.g., regex, length)
            return null;
        }
    }
}
