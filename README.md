[![Board Status](https://dev.azure.com/gwldevopsmay/a1bfd668-30a2-40f4-9424-abae233099da/f1a4c149-7dca-4e2e-ae0e-f145415a7eef/_apis/work/boardbadge/fd91b82f-ca4a-4c9a-bdbf-832f19404203)](https://dev.azure.com/gwldevopsmay/a1bfd668-30a2-40f4-9424-abae233099da/_boards/board/t/f1a4c149-7dca-4e2e-ae0e-f145415a7eef/Microsoft.RequirementCategory)
# HttpClientServiceHelper
.NET HTTP Client Service library.

## Stats and Reports

 ![GitHub contributors](https://img.shields.io/github/contributors-anon/daraoladapo/HttpClientServiceHelper)
 [![Build Status](https://dev.azure.com/daraoladapo/HttpClientServiceHelper/_apis/build/status/HttpClientServiceHelper?branchName=master)](https://dev.azure.com/daraoladapo/HttpClientServiceHelper/_build/latest?definitionId=3&branchName=master) 
 ![Nuget](https://img.shields.io/nuget/dt/HttpClientServiceHelper?label=Total%20NUGET%20Downloads)
 ![GitHub](https://img.shields.io/github/license/daraoladapo/httpclientservicehelper) 

 


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
