using HttpClientServiceHelper.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Xunit;

namespace HttpClientServiceHelper.Tests
{
    public class PostTest
    {
        string Route = "https://daraoladapo.com";
        string Token = Guid.NewGuid().ToString();
        [Fact]
        public async void PostAsync()
        {
            var _Person = Person.GetPerson();
            var PostResponse = await HttpClientHelper.PostAsync(Route, _Person);
            Assert.NotNull(PostResponse);
            Assert.IsType<HttpResponseMessage>(PostResponse);
        }
        [Fact]
        public async void Post_GetResponseAsStringAsync()
        {
            var _Person = Person.GetPerson();
            var PostResponse = await HttpClientHelper.PostAndGetResponseAsStringAsync(Route, _Person);
            Assert.NotNull(PostResponse);
            Assert.IsType<string>(PostResponse);
        }
        [Fact]
        public async void Post_WithToken_GetResponseAsStringAsync()
        {
            var _Person = Person.GetPerson();
            var PostResponse = await HttpClientHelper.PostAndGetResponseAsStringAsync(Route, _Person, Token);
            Assert.NotNull(PostResponse);
            Assert.IsType<string>(PostResponse);
        }
        [Fact]
        public async void PostAsync_WithToken()
        {
            var _Person = Person.GetPerson();
            var PostResponse = await HttpClientHelper.PostAsync(Route, _Person, Token);
            Assert.NotNull(PostResponse);
            Assert.IsType<HttpResponseMessage>(PostResponse);
        }
    }
}
