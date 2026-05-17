# HttpClientServiceHelper Documentation

## Overview
HttpClientServiceHelper is a .NET library designed to simplify HTTP operations (GET, POST, PUT, PATCH, DELETE) with a focus on reusability, testability, and ease of use. It provides helper classes and models to streamline HTTP requests and responses, including support for custom headers and authorization.

## Project Structure
- **src/HttpClientServiceHelper/**: Main library source code
- **src/HttpClientServiceHelper.Tests/**: Unit tests for the library
- **src/HttpClientServiceHelper/Models/**: Data models for headers, authorization, and generic payloads
- **src/HttpClientServiceHelper/Assets/**: Static assets (if any)
- **/docs/**: Project documentation

## Main Components
### Core Classes
- **Get.cs**: Handles HTTP GET requests
- **Post.cs**: Handles HTTP POST requests
- **Put.cs**: Handles HTTP PUT requests
- **Patch.cs**: Handles HTTP PATCH requests
- **Delete.cs**: Handles HTTP DELETE requests
- **HttpClientServiceHelper.cs**: Central helper class for HTTP operations

### Models
- **Authorization.cs**: Represents authorization data (e.g., Bearer tokens)
- **Header.cs**: Represents custom HTTP headers
- **GenericModel.cs**: Generic model for request/response payloads

## Usage
1. Add the library to your .NET project.
2. Instantiate the relevant helper class (e.g., `Get`, `Post`).
3. Use the provided methods to perform HTTP operations, passing in models as needed.

## Testing
- Unit tests are located in `src/HttpClientServiceHelper.Tests/`.
- Tests cover all HTTP methods and edge cases.

## Upgrading
- The project targets the latest .NET (net10.0) for the main library and will be updated for the test project.
- Dependencies are kept up to date (e.g., Newtonsoft.Json 13.0.3).

## Contribution
- Feature branches are used for major upgrades and changes.
- Issues and pull requests are tracked on GitHub.

## License
This project is licensed under the MIT License.
