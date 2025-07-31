---
description: "Sample reusable prompt for the example given in the demo."
tools: ['codebase', 'fetch', 'findTestFiles', 'openSimpleBrowser', 'problems', 'search', 'searchResults']
---

You are tasked with designing and implementing a new API endpoint to retrieve weather data based on a provided city and state. Follow these detailed instructions to ensure the solution adheres to SOLID, Clean Code, DRY, and Pragmatic Programmer principles.

## Step-by-Step Process

### 1. Requirements Clarification
- The endpoint must accept `city` and `state` as parameters.
- It should return current weather data (temperature, humidity, conditions, etc.).
- Handle invalid or missing parameters gracefully.
- Ensure the endpoint is RESTful and follows naming conventions.

### 2. API Design
- Define the endpoint path (e.g., `GET /weather?city={city}&state={state}`).
- Specify request and response formats (prefer JSON).
- Document expected status codes (200, 400, 404, 500).

### 3. Interface & Contract
- Create a clear interface for the weather service.
- Use descriptive method and variable names.
- Define input validation rules.

### 4. Implementation Planning
- Identify or create a service to fetch weather data (external API or internal source).
- Abstract external dependencies behind interfaces.
- Ensure single responsibility for each class/module.
- Avoid code duplication by reusing validation and error handling logic.

### 5. Error Handling & Edge Cases
- Return meaningful error messages for invalid input.
- Handle cases where weather data is unavailable.
- Log errors appropriately without exposing sensitive details.

### 6. Testing Strategy
- Write unit tests for input validation, service logic, and error handling.
- Add integration tests for the endpoint.
- Mock external API calls in tests.

### 7. Documentation
- Document the endpoint in API docs (OpenAPI/Swagger if available).
- Provide usage examples and sample responses.

### 8. Code Quality & Review
- Apply SOLID principles:
    - Single Responsibility: Each class/module does one thing.
    - Open/Closed: Code is open for extension, closed for modification.
    - Liskov Substitution: Subtypes can replace base types.
    - Interface Segregation: Prefer small, specific interfaces.
    - Dependency Inversion: Depend on abstractions, not concretions.
- Follow Clean Code practices:
    - Use meaningful names.
    - Keep functions small and focused.
    - Minimize side effects.
- DRY: Extract reusable logic.
- Pragmatic Programmer: Automate repetitive tasks, keep codebase flexible.

### 9. Security & Performance
- Validate and sanitize all inputs.
- Protect against injection and other common vulnerabilities.
- Optimize for performance (e.g., caching if appropriate).

### 10. Deployment & Monitoring
- Ensure the endpoint is included in deployment scripts.
- Add monitoring/alerting for failures or high error rates.

---

**Deliverables:**
- Endpoint implementation code.
- Interface and service abstractions.
- Unit and integration tests.
- API documentation.
- Deployment and monitoring updates.

**Checklist:**
- [ ] Requirements clarified
- [ ] API designed and documented
- [ ] Interfaces and contracts defined
- [ ] Implementation complete
- [ ] Error handling robust
- [ ] Tests written and passing
- [ ] Code reviewed for SOLID, Clean Code, DRY, Pragmatic principles
- [ ] Security and performance verified
- [ ] Deployed and monitored