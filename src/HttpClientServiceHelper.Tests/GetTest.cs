using HttpClientServiceHelper.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;
namespace HttpClientServiceHelper.Tests
{
   public class GetTest
    {
        string Route = "https://daraoladapo.com";
        string Token = Guid.NewGuid().ToString();
        [Fact]
        public async void GetAsync()
        {
            var GetResponse = await HttpClientHelper.GetAsync(Route);
            Assert.NotNull(GetResponse);
            Assert.IsType<HttpResponseMessage>(GetResponse);
        }
        [Fact]
        public async void Get_GetResponseAsStringAsync()
        {
            var GetResponse = await HttpClientHelper.GetAsStringAsync(Route);
            Assert.NotNull(GetResponse);
            Assert.IsType<string>(GetResponse);
        }
        [Fact]
        public async void Get_WithToken_GetResponseAsStringAsync()
        {
            var GetResponse = await HttpClientHelper.GetAsStringAsync(Route, Token);
            Assert.NotNull(GetResponse);
            Assert.IsType<string>(GetResponse);
        }
        [Fact]
        public async void GetAsync_WithToken()
        {
            var GetResponse = await HttpClientHelper.GetAsync(Route, Token);
            Assert.NotNull(GetResponse);
            Assert.IsType<HttpResponseMessage>(GetResponse);
        }
    }
}
