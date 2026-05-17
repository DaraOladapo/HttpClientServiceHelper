# Upgrade Guide

## Upgrading to .NET 10.0

- Update the `<TargetFramework>` in all .csproj files to `net10.0`.
- Update all dependencies to their latest stable versions (e.g., Newtonsoft.Json 13.0.3).
- Run `dotnet restore` and `dotnet build` to ensure compatibility.
- Run all tests to verify functionality.

## Project Structure
- Main library: `src/HttpClientServiceHelper/`
- Tests: `src/HttpClientServiceHelper.Tests/`
- Models: `src/HttpClientServiceHelper/Models/`

## Troubleshooting
- If you encounter build errors, check for breaking changes in .NET or dependencies.
- Review the official .NET migration documentation for additional guidance.

## Contribution Workflow
- Use feature branches for upgrades and major changes.
- Open a pull request and link to the relevant issue.
- Ensure all tests pass before merging.
