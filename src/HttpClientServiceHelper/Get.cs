using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientServiceHelper
{
    /// <summary>
    /// HTTP Client Helper Library
    /// </summary>
    public partial class HttpClientHelper
    {
        /// <summary>
        /// Triggers a GET request to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns>An HTTP Reponse Message</returns>
        public static async Task<HttpResponseMessage> GetAsync(string Route)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync(new Uri(Route));
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a GET request to the specified route with a Bearer Token and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Token"></param>
        /// <returns>An HTTP Reponse Message</returns>
        public static async Task<HttpResponseMessage> GetAsync(string Route, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                var httpResponse = await httpClient.GetAsync(new Uri(Route));
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a GET request to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns>a string format of the HTTP Response message</returns>
        public static async Task<string> GetAsStringAsync(string Route)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync(new Uri(Route));
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Triggers a GET request to the specified route with a Bearer Token and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Token"></param>
        /// <returns>An HTTP Reponse Message</returns>
        public static async Task<string> GetAsStringAsync(string Route, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                var httpResponse = await httpClient.GetAsync(new Uri(Route));
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
    }
}
