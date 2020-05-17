using HttpClientServiceHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientServiceHelper
{
    public partial class HttpClientHelper
    {
        /// <summary>
        /// Triggers a PUT request to the specified route and retrieves the result as an HTTP Response Message
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <returns>an HTTP Response Message</returns>
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
        /// Triggers a PUT request to the specified route and retrieves the result as an HTTP Response Message
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Token"></param>
        /// <returns>an HTTP Response Message</returns>
        public static async Task<HttpResponseMessage> PutAsync(string Route, object Model, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a PUT request to the specified route with headers and retrieves the result as an HTTP Response Message
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Headers"></param>
        /// <returns>an HTTP Response Message</returns>
        public static async Task<HttpResponseMessage> PutAsync(string Route, object Model, List<Header> Headers)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a PUT request to the specified route with headers and authorization and retrieves the result as an HTTP Response Message
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Headers"></param>
        /// <param name="Authorization"></param>
        /// <returns>an HTTP Response Message</returns>
        public static async Task<HttpResponseMessage> PutAsync(string Route, object Model, List<Header> Headers, Authorization Authorization)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Authorization.Parameter) ?
                    new AuthenticationHeaderValue(Authorization.Scheme) : new AuthenticationHeaderValue(Authorization.Scheme, Authorization.Parameter);
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
        /// <returns>an HTTP Response Message as string</returns>
        public static async Task<string> PutAndGetResponseAsStringAsync(string Route, object Model)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Triggers a PUT request to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Token"></param>
        /// <returns>an HTTP Response Message as string</returns>
        public static async Task<string> PutAndGetResponseAsStringAsync(string Route, object Model, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Triggers a PUT request to the specified route with headers and retrieves the result as an HTTP Response Message
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Headers"></param>
        /// <returns>an HTTP Response Message as string</returns>
        public static async Task<string> PutAndGetResponseAsStringAsync(string Route, object Model, List<Header> Headers)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Triggers a PUT request to the specified route with headers and authorization and retrieves the result as an HTTP Response Message
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Headers"></param>
        /// <param name="Authorization"></param>
        /// <returns>an HTTP Response Message as string</returns>
        public static async Task<string> PutAndGetResponseAsStringAsync(string Route, object Model, List<Header> Headers, Authorization Authorization)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Authorization.Parameter) ?
                    new AuthenticationHeaderValue(Authorization.Scheme) : new AuthenticationHeaderValue(Authorization.Scheme, Authorization.Parameter);
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
       
        /// <summary>
        /// Triggers a PUT request to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <returns>an HTTP Response Message as GenericModel of type T</returns>
        public static async Task<GenericModel<T>> PutAndGetResponseAsGenericModelAsync<T>(string Route, object Model)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                if (httpResponse.IsSuccessStatusCode)
                {
                    if (typeof(T) == typeof(string))
                    {
                        return new GenericModel<T>()
                        {
                            Response = (T)Convert.ChangeType(await httpResponse.Content.ReadAsStringAsync(), typeof(T)),
                            StatusCode = (int)httpResponse.StatusCode
                        };
                    }
                    else
                    {
                        return new GenericModel<T>()
                        {
                            Response = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync()),
                            StatusCode = (int)httpResponse.StatusCode
                        };
                    }
                }
                else
                {
                    return new GenericModel<T>()
                    {
                        StatusCode = (int)httpResponse.StatusCode,
                        ErrorMessage = await httpResponse.Content.ReadAsStringAsync()
                    };
                }
            }
        }
        /// <summary>
        /// Triggers a PUT request to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Token"></param>
        /// <returns>an HTTP Response Message as GenericModel of type T</returns>
        public static async Task<GenericModel<T>> PutAndGetResponseAsGenericModelAsync<T>(string Route, object Model, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                if (httpResponse.IsSuccessStatusCode)
                {
                    if (typeof(T) == typeof(string))
                    {
                        return new GenericModel<T>()
                        {
                            Response = (T)Convert.ChangeType(await httpResponse.Content.ReadAsStringAsync(), typeof(T)),
                            StatusCode = (int)httpResponse.StatusCode
                        };
                    }
                    else
                    {
                        return new GenericModel<T>()
                        {
                            Response = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync()),
                            StatusCode = (int)httpResponse.StatusCode
                        };
                    }
                }
                else
                {
                    return new GenericModel<T>()
                    {
                        StatusCode = (int)httpResponse.StatusCode,
                        ErrorMessage = await httpResponse.Content.ReadAsStringAsync()
                    };
                }
            }
        }
        /// <summary>
        /// Triggers a PUT request to the specified route with headers and retrieves the result as an HTTP Response Message
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Headers"></param>
        /// <returns>an HTTP Response Message as GenericModel of type T</returns>
        public static async Task<GenericModel<T>> PutAndGetResponseAsGenericModelAsync<T>(string Route, object Model, List<Header> Headers)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                if (httpResponse.IsSuccessStatusCode)
                {
                    if (typeof(T) == typeof(string))
                    {
                        return new GenericModel<T>()
                        {
                            Response = (T)Convert.ChangeType(await httpResponse.Content.ReadAsStringAsync(), typeof(T)),
                            StatusCode = (int)httpResponse.StatusCode
                        };
                    }
                    else
                    {
                        return new GenericModel<T>()
                        {
                            Response = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync()),
                            StatusCode = (int)httpResponse.StatusCode
                        };
                    }
                }
                else
                {
                    return new GenericModel<T>()
                    {
                        StatusCode = (int)httpResponse.StatusCode,
                        ErrorMessage = await httpResponse.Content.ReadAsStringAsync()
                    };
                };
            }
        }
        /// <summary>
        /// Triggers a PUT request to the specified route with headers and authorization and retrieves the result as an HTTP Response Message
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Model"></param>
        /// <param name="Headers"></param>
        /// <param name="Authorization"></param>
        /// <returns>an HTTP Response Message as GenericModel of type T</returns>
        public static async Task<GenericModel<T>> PutAndGetResponseAsGenericModelAsync<T>(string Route, object Model, List<Header> Headers, Authorization Authorization)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var uri = new Uri(Route);
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Authorization.Parameter) ?
                    new AuthenticationHeaderValue(Authorization.Scheme) : new AuthenticationHeaderValue(Authorization.Scheme, Authorization.Parameter);
                string jsonTransport = JsonConvert.SerializeObject(Model);
                var jsonPayload = new StringContent(jsonTransport, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PutAsync(uri, jsonPayload);
                if (httpResponse.IsSuccessStatusCode)
                {
                    if (typeof(T) == typeof(string))
                    {
                        return new GenericModel<T>()
                        {
                            Response = (T)Convert.ChangeType(await httpResponse.Content.ReadAsStringAsync(), typeof(T)),
                            StatusCode = (int)httpResponse.StatusCode
                        };
                    }
                    else
                    {
                        return new GenericModel<T>()
                        {
                            Response = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync()),
                            StatusCode = (int)httpResponse.StatusCode
                        };
                    }
                }
                else
                {
                    return new GenericModel<T>()
                    {
                        StatusCode = (int)httpResponse.StatusCode,
                        ErrorMessage = await httpResponse.Content.ReadAsStringAsync()
                    };
                }
            }
        }
    }
}
