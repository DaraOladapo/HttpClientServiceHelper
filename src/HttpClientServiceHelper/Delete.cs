using HttpClientServiceHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        /// Triggers a DELETE request with headers to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <returns>an HTTP Response Message</returns>
        public static async Task<HttpResponseMessage> DeleteAsync(string Route, List<Header> Headers)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a DELETE request with headers and authorization to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <param name="Authorization"></param>
        /// <returns>an HTTP Response Message</returns>
        public static async Task<HttpResponseMessage> DeleteAsync(string Route, List<Header> Headers, Authorization Authorization)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Authorization.Parameter) ?
                     new AuthenticationHeaderValue(Authorization.Scheme) : new AuthenticationHeaderValue(Authorization.Scheme, Authorization.Parameter);
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return httpResponse;
            }
        }

        /// <summary>
        /// Triggers a DELETE request to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns>a string format of the HTTP Response message</returns>
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
        /// <returns>a string format of the HTTP Response message</returns>
        public static async Task<string> DeleteAndGetResponseAsStringAsync(string Route, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Triggers a DELETE request with headers to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <returns>a string format of the HTTP Response message</returns>
        public static async Task<string> DeleteAndGetResponseAsStringAsync(string Route, List<Header> Headers)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Triggers a DELETE request with headers and authorization to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <param name="Authorization"></param>
        /// <returns>a string format of the HTTP Response message</returns>
        public static async Task<string> DeleteAndGetResponseAsStringAsync(string Route, List<Header> Headers, Authorization Authorization)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Authorization.Parameter) ?
                    new AuthenticationHeaderValue(Authorization.Scheme) : new AuthenticationHeaderValue(Authorization.Scheme, Authorization.Parameter);
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Triggers a DELETE request to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns>a string format of the Generic Model of Type T</returns>
        public static async Task<GenericModel<T>> DeleteAndGetResponseAsGenericModelAsync<T>(string Route)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
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
        /// Triggers a DELETE request to the specified route with a Bearer token and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Token"></param>
        /// <returns>a string format of the Generic Model of Type T</returns>
        public static async Task<GenericModel<T>> DeleteAndGetResponseAsGenericModelAsync<T>(string Route, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
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
        /// Triggers a DELETE request with headers to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <returns>a string format of the Generic Model of Type T</returns>
        public static async Task<GenericModel<T>> DeleteAndGetResponseAsGenericModelAsync<T>(string Route, List<Header> Headers)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
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
        /// Triggers a DELETE request with headers and authorization to the specified route and retrieves the result as a string which you can serialize.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <param name="Authorization"></param>
        /// <returns>a string format of the Generic Model of Type T</returns>
        public static async Task<GenericModel<T>> DeleteAndGetResponseAsGenericModelAsync<T>(string Route, List<Header> Headers, Authorization Authorization)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Authorization.Parameter) ?
                    new AuthenticationHeaderValue(Authorization.Scheme) : new AuthenticationHeaderValue(Authorization.Scheme, Authorization.Parameter);
                var httpResponse = await httpClient.DeleteAsync(new Uri(Route));
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
