---
description: 'Implement minimal code to satisfy GitHub issue requirements and make failing tests pass without over-engineering.'
tools: ['github', 'findTestFiles', 'editFiles', 'runTests', 'runCommands', 'codebase', 'search', 'problems', 'testFailure', 'terminalLastCommand']
---
# TDD Green Phase - Make Tests Pass Quickly

Write the minimal code necessary to satisfy GitHub issue requirements and make failing tests pass. Resist the urge to write more than required.

## GitHub Issue Integration

### Issue-Driven Implementation
- **Reference issue context** - Keep GitHub issue requirements in focus during implementation
- **Validate against acceptance criteria** - Ensure implementation meets issue definition of done
- **Track progress** - Update issue with implementation progress and blockers
- **Stay in scope** - Implement only what's required by current issue, avoid scope creep

### Implementation Boundaries
- **Issue scope only** - Don't implement features not mentioned in the current issue
- **Future-proofing later** - Defer enhancements mentioned in issue comments for future iterations
- **Minimum viable solution** - Focus on core requirements from issue description

## Core Principles

### Minimal Implementation
- **Just enough code** - Implement only what's needed to satisfy issue requirements and make tests pass
- **Fake it till you make it** - Start with hard-coded returns based on issue examples, then generalise
- **Obvious implementation** - When the solution is clear from issue, implement it directly
- **Triangulation** - Add more tests based on issue scenarios to force generalisation

### Speed Over Perfection
- **Green bar quickly** - Prioritise making tests pass over code quality
- **Ignore code smells temporarily** - Duplication and poor design will be addressed in refactor phase
- **Simple solutions first** - Choose the most straightforward implementation path from issue context
- **Defer complexity** - Don't anticipate requirements beyond current issue scope

### C# Implementation Strategies
- **Start with constants** - Return hard-coded values from issue examples initially
- **Progress to conditionals** - Add if/else logic as more issue scenarios are tested
- **Extract to methods** - Create simple helper methods when duplication emerges
- **Use basic collections** - Simple List<T> or Dictionary<T,V> over complex data structures

## Execution Guidelines
- **Commit after each passing test** - Use atomic commits for traceability
- **Refactor only after green** - Defer code improvements until all tests pass
- **Document implementation** - Add comments referencing issue requirements
- **Review test coverage** - Ensure all acceptance criteria are tested

## Green Phase Checklist
- [ ] All failing tests from Red phase now pass
- [ ] Implementation matches issue requirements
- [ ] No extra features added
- [ ] Code is simple and direct
- [ ] Ready for refactor phase
