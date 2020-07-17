using HttpClientServiceHelper.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace HttpClientServiceHelper.Tests
{
    public class DeleteTest
    {
        string Route = "https://daraoladapo.com";
        string Token = Guid.NewGuid().ToString();
        List<Header> Headers = new List<Header>() { new Header() { Name = "SomeHeaderName", Value = "SomeHeaderValue" } };

        [Fact]
        public async void DeleteAsync()
        {
            var DeleteResponse = await HttpClientHelper.DeleteAsync(Route);
            Assert.NotNull(DeleteResponse);
            Assert.IsType<HttpResponseMessage>(DeleteResponse);
        }
        [Fact]
        public async void Delete_DeleteResponseAsStringAsync()
        {
            var DeleteResponse = await HttpClientHelper.DeleteAndGetResponseAsStringAsync(Route);
            Assert.NotNull(DeleteResponse);
            Assert.IsType<string>(DeleteResponse);
        }
        [Fact]
        public async void Delete_WithToken_DeleteResponseAsStringAsync()
        {
            var DeleteResponse = await HttpClientHelper.DeleteAndGetResponseAsStringAsync(Route, Token);
            Assert.NotNull(DeleteResponse);
            Assert.IsType<string>(DeleteResponse);
        }
        [Fact]
        public async void DeleteAsync_WithToken()
        {
            var DeleteResponse = await HttpClientHelper.DeleteAsync(Route, Token);
            Assert.NotNull(DeleteResponse);
            Assert.IsType<HttpResponseMessage>(DeleteResponse);
        }
        [Fact]
        public async void DeleteAsync_WithHeaders()
        {
            var DeleteResponse = await HttpClientHelper.DeleteAsync(Route, Headers);
            Assert.NotNull(DeleteResponse);
            Assert.IsType<HttpResponseMessage>(DeleteResponse);
        }
    }
}
