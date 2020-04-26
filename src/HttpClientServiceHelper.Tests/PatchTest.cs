using System;
using System.Net.Http;
using HttpClientServiceHelper.Tests.Mock;
using Xunit;

namespace HttpClientServiceHelper.Tests
{
    public class PatchTest
    {
        string Route = "https://daraoladapo.com";
        string Token = Guid.NewGuid().ToString();
        [Fact]
        public async void PatchAsync()
        {
            var _Person = Person.GetPerson();
            var PatchResponse = await HttpClientHelper.PatchAsync(Route, _Person);
            Assert.NotNull(PatchResponse);
            Assert.IsType<HttpResponseMessage>(PatchResponse);
        }
        [Fact]
        public async void Patch_GetResponseAsStringAsync()
        {
            var _Person = Person.GetPerson();
            var PatchResponse = await HttpClientHelper.PatchAndGetResponseAsStringAsync(Route, _Person);
            Assert.NotNull(PatchResponse);
            Assert.IsType<string>(PatchResponse);
        }
        [Fact]
        public async void Patch_WithToken_GetResponseAsStringAsync()
        {
            var _Person = Person.GetPerson();
            var PatchResponse = await HttpClientHelper.PatchAndGetResponseAsStringAsync(Route, _Person, Token);
            Assert.NotNull(PatchResponse);
            Assert.IsType<string>(PatchResponse);
        }
        [Fact]
        public async void PatchAsync_WithToken()
        {
            var _Person = Person.GetPerson();
            var PatchResponse = await HttpClientHelper.PatchAsync(Route, _Person, Token);
            Assert.NotNull(PatchResponse);
            Assert.IsType<HttpResponseMessage>(PatchResponse);
        }
    }
}
