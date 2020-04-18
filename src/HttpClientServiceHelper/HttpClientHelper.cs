using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientServiceHelper
{
    public class HttpClientHelper
    {
        #region Get
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
        #endregion
        #region Post
        /// <summary>
        /// Triggers a POST request to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <returns>An HTTP Response Message</returns>
        public static async Task<HttpResponseMessage> PostAsync(string Route, object Model)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PostAsync(uri, jsonPayload);
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a POST request to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <returns></returns> 
        public static async Task<string> PostAsyncGetAsStringResponseAsync(string Route, object Model)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PostAsync(uri, jsonPayload);
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        #endregion
        #region Put
        /// <summary>
        /// Triggers a PUT request to the specified route and retrieves the result as an HTTP Response Message
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PutAsync(string Route, object Model)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a PUT request to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PutAsyncGetAsStringResponseAsync(string Route, object Model)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                return httpResponse;
            }
        }
        #endregion
        #region Delete
        /// <summary>
        /// Triggers a DELETE request to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeleteAsync(string Route)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return httpResponse;
            }
        }
        #endregion

    }
}
