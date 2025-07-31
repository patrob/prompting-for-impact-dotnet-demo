# Product Requirements Document (PRD)

## Feature: Weather by City and State Endpoint

### Overview
Add a new endpoint to the ASP.NET Core API to retrieve weather data for a specific city in a state. The endpoint will accept `state` and `city` as parameters and return weather information, following existing coding standards and ensuring test coverage.

---

## Implementation Plan

1. **Design the Endpoint**
   - Create a new GET endpoint (e.g., `/weatherforecast/{state}/{city}`) that accepts `state` and `city` as route parameters.
2. **Implement the Logic**
   - Add logic to generate or retrieve weather data for the specified city and state.
   - Reuse or extend the existing `WeatherForecast` record as needed.
3. **Follow Coding Standards**
   - Ensure code style, naming, and structure are consistent with the rest of the project.
4. **Add Unit/Integration Tests**
   - Write tests to verify the new endpoint’s behavior.
5. **Document the Endpoint**
   - Update OpenAPI/Swagger documentation if applicable.

---

## Todo List

- [ ] Design the new endpoint route and parameters.
- [ ] Implement the endpoint logic in the API.
- [ ] Update or extend the `WeatherForecast` record if needed.
- [ ] Write unit/integration tests for the new endpoint.
- [ ] Update OpenAPI/Swagger documentation.
- [ ] Review and refactor for coding standards.
