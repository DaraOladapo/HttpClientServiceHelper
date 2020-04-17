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
        public static async Task<HttpResponseMessage> GetAsync(string Route)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.GetAsync(new Uri(Route));
                return httpResponse;
            }
        }
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
        public static async Task<HttpResponseMessage> DeleteAsync(string Route)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return httpResponse;
            }
        }

    }
}
