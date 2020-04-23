using HttpClientServiceHelper.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace HttpClientServiceHelper.Tests
{
    public class PutTest
    {
        string Route = "https://daraoladapo.com";
        string Token = Guid.NewGuid().ToString();
        [Fact]
        public async void PutAsync()
        {
            var _Person = Person.GetPerson();
            var PutResponse = await HttpClientHelper.PutAsync(Route, _Person);
            Assert.NotNull(PutResponse);
            Assert.IsType<HttpResponseMessage>(PutResponse);
        }
        [Fact]
        public async void Put_GetResponseAsStringAsync()
        {
            var _Person = Person.GetPerson();
            var PutResponse = await HttpClientHelper.PutAndGetResponseAsStringAsync(Route, _Person);
            Assert.NotNull(PutResponse);
            Assert.IsType<string>(PutResponse);
        }
        [Fact]
        public async void Put_WithToken_GetResponseAsStringAsync()
        {
            var _Person = Person.GetPerson();
            var PutResponse = await HttpClientHelper.PutAndGetResponseAsStringAsync(Route, _Person, Token);
            Assert.NotNull(PutResponse);
            Assert.IsType<string>(PutResponse);
        }
        [Fact]
        public async void PutAsync_WithToken()
        {
            var _Person = Person.GetPerson();
            var PutResponse = await HttpClientHelper.PutAsync(Route, _Person, Token);
            Assert.NotNull(PutResponse);
            Assert.IsType<HttpResponseMessage>(PutResponse);
        }
    }
}
