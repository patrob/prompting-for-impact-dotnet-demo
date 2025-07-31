---
description: 'Improve code quality, apply security best practices, and enhance design whilst maintaining green tests and GitHub issue compliance.'
tools: ['github', 'findTestFiles', 'editFiles', 'runTests', 'runCommands', 'codebase', 'search', 'problems', 'testFailure', 'terminalLastCommand']
---
# TDD Refactor Phase - Improve Quality & Security

Clean up code, apply security best practices, and enhance design whilst keeping all tests green and maintaining GitHub issue compliance.

## GitHub Issue Integration
- **Revalidate acceptance criteria** - Ensure all issue requirements are still met after refactor
- **Update issue with refactor notes** - Document improvements and any new issues found
- **Link PRs to issues** - Reference issue number in pull request for traceability

## Core Principles

### Code Quality Improvements
- **Remove duplication** - Extract common code into reusable methods or classes
- **Improve readability** - Use intention-revealing names and clear structure aligned with issue domain
- **Apply SOLID principles** - Single responsibility, dependency inversion, etc.
- **Simplify complexity** - Break down large methods, reduce cyclomatic complexity

### Security Hardening
- **Input validation** - Sanitise and validate all external inputs per issue security requirements
- **Authentication/Authorisation** - Implement proper access controls if specified in issue
- **Data protection** - Encrypt sensitive data, use secure connection strings
- **Error handling** - Avoid information disclosure through exception details
- **Dependency scanning** - Check for vulnerable NuGet packages
- **Secrets management** - Use Azure Key Vault or user secrets, never hard-code credentials
- **OWASP compliance** - Address security concerns mentioned in issue or related security tickets

### Design Excellence
- **Design patterns** - Apply appropriate patterns (Repository, Factory, Strategy, etc.)
- **Dependency injection** - Use DI container for loose coupling
- **Configuration management** - Externalise settings using IOptions pattern
- **Logging and monitoring** - Add structured logging with Serilog for issue troubleshooting
- **Performance optimisation** - Use async/await, efficient collections, caching

### C# Best Practices
- **Nullable reference types** - Enable and properly configure nullability
- **Modern C# features** - Use pattern matching, switch expressions, records
- **Memory efficiency** - Consider Span<T>, Memory<T> for performance-critical code
- **Exception handling** - Use specific exception types, avoid catching Exception

## Security Checklist
- [ ] Input validation on all public methods
- [ ] SQL injection prevention (parameterised queries)
- [ ] XSS protection for web applications
- [ ] Authorisation checks on sensitive operations
- [ ] Secure configuration (no secrets in code)
- [ ] Error handling without information disclosure
- [ ] Dependency vulnerability scanning
- [ ] OWASP Top 10 considerations addressed

## Execution Guidelines
- **Refactor in small steps** - Make incremental improvements, run tests after each
- **Keep tests green** - Never break existing tests during refactor
- **Document changes** - Add comments and update documentation as needed
- **Create follow-up issues** - If new problems are found, log them for future work

## Refactor Phase Checklist
- [ ] GitHub issue acceptance criteria fully satisfied
- [ ] Code duplication eliminated
- [ ] Names clearly express intent aligned with issue domain
- [ ] Methods have single responsibility
- [ ] Security vulnerabilities addressed per issue requirements
- [ ] Performance considerations applied
- [ ] All tests remain green
- [ ] Code coverage maintained or improved
- [ ] Issue marked as complete or follow-up issues created
- [ ] Documentation updated as specified in issue
