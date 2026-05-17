using HttpClientServiceHelper.Models;
using Authorization = HttpClientServiceHelper.Models.Authorization;
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
    public class GetTest : IDisposable
    {
        private readonly WireMockServer _server;
        private readonly string _route;
        private readonly string _token = Guid.NewGuid().ToString();
        private readonly List<Header> _customHeaders = new() { new Header { Name = "X-Custom", Value = "custom-value" } };
        private readonly Authorization _auth = new() { Scheme = "Basic", Parameter = "dXNlcjpwYXNz" };

        public GetTest()
        {
            _server = WireMockServer.Start();
            _route = _server.Urls[0];
            _server.Given(Request.Create().WithPath("/").UsingAnyMethod())
                   .RespondWith(Response.Create().WithStatusCode(200).WithBody("ok"));
            _server.Given(Request.Create().WithPath("/error").UsingAnyMethod())
                   .RespondWith(Response.Create().WithStatusCode(404).WithBody("not found"));
        }

        public void Dispose() => _server.Dispose();

        [Fact]
        public async Task GetAsync()
        {
            var response = await HttpClientHelper.GetAsync(_route);
            Assert.NotNull(response);
            Assert.IsType<HttpResponseMessage>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAsync_NoAuth_DoesNotSendAuthHeader()
        {
            await HttpClientHelper.GetAsync(_route);
            var entry = _server.LogEntries.Last();
            Assert.False(entry.RequestMessage.Headers.ContainsKey("Authorization"));
        }

        [Fact]
        public async Task GetAsync_WithToken()
        {
            var response = await HttpClientHelper.GetAsync(_route, _token);
            Assert.NotNull(response);
            Assert.IsType<HttpResponseMessage>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAsync_WithToken_SendsBearerHeader()
        {
            await HttpClientHelper.GetAsync(_route, _token);
            var entry = _server.LogEntries.Last();
            Assert.True(entry.RequestMessage.Headers.ContainsKey("Authorization"));
            Assert.Contains($"Bearer {_token}", entry.RequestMessage.Headers["Authorization"]);
        }

        [Fact]
        public async Task GetAsync_WithCustomHeaders_SendsHeaders()
        {
            var response = await HttpClientHelper.GetAsync(_route, _customHeaders);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var entry = _server.LogEntries.Last();
            Assert.True(entry.RequestMessage.Headers.ContainsKey("X-Custom"));
            Assert.Contains("custom-value", entry.RequestMessage.Headers["X-Custom"]);
        }

        [Fact]
        public async Task GetAsync_WithAuthorizationObject_SendsSchemeAndParameter()
        {
            var response = await HttpClientHelper.GetAsync(_route, _customHeaders, _auth);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var entry = _server.LogEntries.Last();
            Assert.True(entry.RequestMessage.Headers.ContainsKey("Authorization"));
            Assert.Contains($"Basic {_auth.Parameter}", entry.RequestMessage.Headers["Authorization"]);
        }

        [Fact]
        public async Task Get_GetResponseAsStringAsync()
        {
            var response = await HttpClientHelper.GetAsStringAsync(_route);
            Assert.NotNull(response);
            Assert.IsType<string>(response);
            Assert.Equal("ok", response);
        }

        [Fact]
        public async Task Get_WithToken_GetResponseAsStringAsync()
        {
            var response = await HttpClientHelper.GetAsStringAsync(_route, _token);
            Assert.NotNull(response);
            Assert.IsType<string>(response);
            var entry = _server.LogEntries.Last();
            Assert.True(entry.RequestMessage.Headers.ContainsKey("Authorization"));
            Assert.Contains($"Bearer {_token}", entry.RequestMessage.Headers["Authorization"]);
        }

        [Fact]
        public async Task GetAsync_NonOkResponse_Returns404()
        {
            var response = await HttpClientHelper.GetAsync($"{_route}/error");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
