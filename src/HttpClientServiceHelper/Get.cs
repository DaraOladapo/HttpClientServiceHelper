using HttpClientServiceHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientServiceHelper
{
    /// <summary>
    /// HTTP Client Helper Library
    /// </summary>
    public partial class HttpClientHelper
    {
        #region TODO
        /// <summary>
        /// Triggers a GET request to the specified route and retrieves the result as a generic object response.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns>An object</returns>
        //public static async Task<GenericModel<T>> GetAsGenericModelAsync<T>(string Route)
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        var httpResponse = await httpClient.GetAsync(new Uri(Route));
        //        if (httpResponse.IsSuccessStatusCode)
        //        {
        //            if (typeof(T) == typeof(string))
        //            {
        //                return new GenericModel<T>()
        //                {
        //                    Response = (T)Convert.ChangeType(await httpResponse.Content.ReadAsStringAsync(), typeof(T)),
        //                    StatusCode = (int)httpResponse.StatusCode
        //                };
        //            }
        //            else
        //            {
        //                return new GenericModel<T>()
        //                {
        //                    Response = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync()),
        //                    StatusCode = (int)httpResponse.StatusCode
        //                };
        //            }
        //        }
        //        else
        //        {
        //            return new GenericModel<T>()
        //            {
        //                StatusCode = (int)httpResponse.StatusCode,
        //                ErrorMessage = await httpResponse.Content.ReadAsStringAsync()
        //            };
        //        }
        //    }
        //}
        /// <summary>
        /// Triggers a GET request with bearer token to the specified route and retrieves the result as a generic object response.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns>An object</returns>
        //public static async Task<GenericModel<T>> GetAsGenericModelAsync<T>(string Route, string Token)
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
        //        var httpResponse = await httpClient.GetAsync(new Uri(Route));
        //        if (httpResponse.IsSuccessStatusCode)
        //        {
        //            if (typeof(T) == typeof(string))
        //            {
        //                return new GenericModel<T>()
        //                {
        //                    Response = (T)Convert.ChangeType(await httpResponse.Content.ReadAsStringAsync(), typeof(T)),
        //                    StatusCode = (int)httpResponse.StatusCode
        //                };
        //            }
        //            else
        //            {
        //                return new GenericModel<T>()
        //                {
        //                    Response = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync()),
        //                    StatusCode = (int)httpResponse.StatusCode
        //                };
        //            }
        //        }
        //        else
        //        {
        //            return new GenericModel<T>()
        //            {
        //                StatusCode = (int)httpResponse.StatusCode,
        //                ErrorMessage = await httpResponse.Content.ReadAsStringAsync()
        //            };
        //        }
        //    }
        //}
        /// <summary>
        /// Triggers a GET request with headers to the specified route and retrieves the result as a generic object response.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <returns>An object</returns>
        //public static async Task<GenericModel<T>> GetAsGenericModelAsync<T>(string Route, List<Header> Headers)
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        foreach (var Header in Headers)
        //        {
        //            httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
        //        }
        //        var httpResponse = await httpClient.GetAsync(new Uri(Route));
        //        if (httpResponse.IsSuccessStatusCode)
        //        {
        //            if (typeof(T) == typeof(string))
        //            {
        //                return new GenericModel<T>()
        //                {
        //                    Response = (T)Convert.ChangeType(await httpResponse.Content.ReadAsStringAsync(), typeof(T)),
        //                    StatusCode = (int)httpResponse.StatusCode
        //                };
        //            }
        //            else
        //            {
        //                return new GenericModel<T>()
        //                {
        //                    Response = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync()),
        //                    StatusCode = (int)httpResponse.StatusCode
        //                };
        //            }
        //        }
        //        else
        //        {
        //            return new GenericModel<T>()
        //            {
        //                StatusCode = (int)httpResponse.StatusCode,
        //                ErrorMessage = await httpResponse.Content.ReadAsStringAsync()
        //            };
        //        }
        //    }
        //}
        /// <summary>
        /// Triggers a GET request with headers and authorization to the specified route and retrieves the result as a generic object response.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <param name="Authorization"></param>
        /// <returns>An object</returns>
        //public static async Task<GenericModel<T>> GetAsGenericModelAsync<T>(string Route, List<Header> Headers, Authorization Authorization)
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Authorization.Parameter) ?
        //               new AuthenticationHeaderValue(Authorization.Scheme) : new AuthenticationHeaderValue(Authorization.Scheme, Authorization.Parameter);
        //        foreach (var Header in Headers)
        //        {
        //            httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
        //        }
        //        var httpResponse = await httpClient.GetAsync(new Uri(Route));
        //        if (httpResponse.IsSuccessStatusCode)
        //        {
        //            if (typeof(T) == typeof(string))
        //            {
        //                return new GenericModel<T>()
        //                {
        //                    Response = (T)Convert.ChangeType(await httpResponse.Content.ReadAsStringAsync(), typeof(T)),
        //                    StatusCode = (int)httpResponse.StatusCode
        //                };
        //            }
        //            else
        //            {
        //                return new GenericModel<T>()
        //                {
        //                    Response = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync()),
        //                    StatusCode = (int)httpResponse.StatusCode
        //                };
        //            }
        //        }
        //        else
        //        {
        //            return new GenericModel<T>()
        //            {
        //                StatusCode = (int)httpResponse.StatusCode,
        //                ErrorMessage = await httpResponse.Content.ReadAsStringAsync()
        //            };
        //        }
        //    }
        //}
        #endregion
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
        /// Triggers a GET request with headers to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <returns>An HTTP Reponse Message</returns>
        public static async Task<HttpResponseMessage> GetAsync(string Route, List<Header> Headers)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                var httpResponse = await httpClient.GetAsync(new Uri(Route));
                return httpResponse;
            }
        }
        /// <summary>
        /// Triggers a GET request with headers and authorization to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <param name="Authorization"></param>
        /// <returns>An HTTP Reponse Message</returns>
        public static async Task<HttpResponseMessage> GetAsync(string Route, List<Header> Headers, Authorization Authorization)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Authorization.Parameter) ?
                    new AuthenticationHeaderValue(Authorization.Scheme) : new AuthenticationHeaderValue(Authorization.Scheme, Authorization.Parameter);
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
        /// <returns>a string format of the HTTP Response message</returns>
        public static async Task<string> GetAsStringAsync(string Route, string Token = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Token) ? new AuthenticationHeaderValue("Bearer", Token) : null;
                var httpResponse = await httpClient.GetAsync(new Uri(Route));
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Triggers a GET request with headers to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <returns>a string format of the HTTP Response message</returns>
        public static async Task<string> GetAsStringAsync(string Route, List<Header> Headers)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                var httpResponse = await httpClient.GetAsync(new Uri(Route));
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Triggers a GET request with headers and authorization to the specified route and retrieves the result as an HTTP Response Message.
        /// </summary>
        /// <param name="Route"></param>
        /// <param name="Headers"></param>
        /// <param name="Authorization"></param>
        /// <returns>a string format of the HTTP Response message</returns>
        public static async Task<string> GetAsStringAsync(string Route, List<Header> Headers, Authorization Authorization)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var Header in Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(Header.Name, Header.Value);
                }
                httpClient.DefaultRequestHeaders.Authorization = string.IsNullOrEmpty(Authorization.Parameter) ?
                    new AuthenticationHeaderValue(Authorization.Scheme) : new AuthenticationHeaderValue(Authorization.Scheme, Authorization.Parameter);
                var httpResponse = await httpClient.GetAsync(new Uri(Route));
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
    }
}
