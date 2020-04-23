# HttpClientServiceHelper
.NET HTTP Client Service library.

Use this library to quickly bootstrap your HttpClient Service calls.
It uses the System.Net.Http library.
You pass in your routes and objects for the calls - Get, Post, Put, Delete.
It returns an HttpResponseMessage/String Response depending on the method called which you can then utilize in your projects.

## Adding to your project

Using the Package Manager Console

`Install-Package HttpClientServiceHelper`

Using .NET CLI

`dotnet add package HttpClientServiceHelper`

Using Package Reference

Copy the following into the .csproj file of your project (using version 1.0.0 as reference).

`<PackageReference Include="HttpClientServiceHelper" Version="1.0.0" />`

Get the NUGET Package [here](https://www.nuget.org/packages/HttpClientServiceHelper).

Happy Usage!