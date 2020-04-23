using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientServiceHelper
{
    public partial class HttpClientHelper
    {
        /// <summary>
        /// Triggers a DELETE request to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns>an HTTP Response Message</returns>
        public static async Task<HttpResponseMessage> DeleteAsync(string Route)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a DELETE request to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns>an HTTP Response Message</returns>
        public static async Task<string> DeleteAndGetResponseAsStringAsync(string Route)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Triggers a DELETE request to the specified route with a Bearer token and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Token"></param>
        /// <returns>an HTTP Response Message</returns>
        public static async Task<HttpResponseMessage> DeleteAsync(string Route, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a DELETE request to the specified route with a Bearer token and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Token"></param>
        /// <returns>an HTTP Response Message</returns>
        public static async Task<string> DeleteAndGetResponseAsStringAsync(string Route, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
    }
}
