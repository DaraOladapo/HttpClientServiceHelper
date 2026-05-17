using HttpClientServiceHelper.Models;
using Authorization = HttpClientServiceHelper.Models.Authorization;
using HttpClientServiceHelper.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace HttpClientServiceHelper.Tests
{
    public class PostTest : IDisposable
    {
        private readonly WireMockServer _server;
        private readonly string _route;
        private readonly string _token = Guid.NewGuid().ToString();
        private readonly List<Header> _customHeaders = new() { new Header { Name = "X-Custom", Value = "custom-value" } };
        private readonly Authorization _auth = new() { Scheme = "Basic", Parameter = "dXNlcjpwYXNz" };

        public PostTest()
        {
            _server = WireMockServer.Start();
            _route = _server.Urls[0];
            _server.Given(Request.Create().WithPath("/").UsingAnyMethod())
                   .RespondWith(Response.Create().WithStatusCode(200).WithBody("created"));
            _server.Given(Request.Create().WithPath("/error").UsingAnyMethod())
                   .RespondWith(Response.Create().WithStatusCode(422).WithBody("unprocessable"));
        }

        public void Dispose() => _server.Dispose();

        [Fact]
        public async Task PostAsync()
        {
            var response = await HttpClientHelper.PostAsync(_route, Person.GetPerson());
            Assert.NotNull(response);
            Assert.IsType<HttpResponseMessage>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostAsync_NoAuth_SendsNonEmptyBody()
        {
            await HttpClientHelper.PostAsync(_route, Person.GetPerson());
            var entry = _server.LogEntries.Last();
            Assert.False(entry.RequestMessage.Headers.ContainsKey("Authorization"));
            Assert.NotNull(entry.RequestMessage.Body);
            Assert.Contains("FirstName", entry.RequestMessage.Body);
            Assert.Contains("Dara", entry.RequestMessage.Body);
        }

        [Fact]
        public async Task PostAsync_WithToken()
        {
            var response = await HttpClientHelper.PostAsync(_route, Person.GetPerson(), _token);
            Assert.NotNull(response);
            Assert.IsType<HttpResponseMessage>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostAsync_WithToken_SendsBearerHeaderAndBody()
        {
            await HttpClientHelper.PostAsync(_route, Person.GetPerson(), _token);
            var entry = _server.LogEntries.Last();
            Assert.True(entry.RequestMessage.Headers.ContainsKey("Authorization"));
            Assert.Contains($"Bearer {_token}", entry.RequestMessage.Headers["Authorization"]);
            Assert.NotNull(entry.RequestMessage.Body);
            Assert.Contains("FirstName", entry.RequestMessage.Body);
        }

        [Fact]
        public async Task PostAsync_WithCustomHeaders_SendsHeadersAndBody()
        {
            var response = await HttpClientHelper.PostAsync(_route, Person.GetPerson(), _customHeaders);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var entry = _server.LogEntries.Last();
            Assert.True(entry.RequestMessage.Headers.ContainsKey("X-Custom"));
            Assert.Contains("custom-value", entry.RequestMessage.Headers["X-Custom"]);
            Assert.NotNull(entry.RequestMessage.Body);
            Assert.Contains("FirstName", entry.RequestMessage.Body);
        }

        [Fact]
        public async Task PostAsync_WithAuthorizationObject_SendsSchemeParameterAndBody()
        {
            var response = await HttpClientHelper.PostAsync(_route, Person.GetPerson(), _customHeaders, _auth);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var entry = _server.LogEntries.Last();
            Assert.True(entry.RequestMessage.Headers.ContainsKey("Authorization"));
            Assert.Contains($"Basic {_auth.Parameter}", entry.RequestMessage.Headers["Authorization"]);
            Assert.NotNull(entry.RequestMessage.Body);
            Assert.Contains("FirstName", entry.RequestMessage.Body);
        }

        [Fact]
        public async Task Post_GetResponseAsStringAsync()
        {
            var response = await HttpClientHelper.PostAndGetResponseAsStringAsync(_route, Person.GetPerson());
            Assert.NotNull(response);
            Assert.IsType<string>(response);
            Assert.Equal("created", response);
        }

        [Fact]
        public async Task Post_WithToken_GetResponseAsStringAsync()
        {
            var response = await HttpClientHelper.PostAndGetResponseAsStringAsync(_route, Person.GetPerson(), _token);
            Assert.NotNull(response);
            Assert.IsType<string>(response);
            var entry = _server.LogEntries.Last();
            Assert.True(entry.RequestMessage.Headers.ContainsKey("Authorization"));
            Assert.Contains($"Bearer {_token}", entry.RequestMessage.Headers["Authorization"]);
        }

        [Fact]
        public async Task PostAsync_NonOkResponse_Returns422()
        {
            var response = await HttpClientHelper.PostAsync($"{_route}/error", Person.GetPerson());
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }
    }
}
