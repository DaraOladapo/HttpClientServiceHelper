using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HttpClientServiceHelper.Models
{
    public class Authorization
    {
        public string Scheme { get; set; }
        public string Parameter { get; set; }
    }
}
