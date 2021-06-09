using System;
using System.Net.Http;

namespace ServiceRequest.Services
{
    public class HttpClientBase : HttpClient
    {
        public HttpClientBase()
        {
            DefaultRequestHeaders.Add("Acept", "application/json");
            DefaultRequestHeaders.Add("ContentType", "application/json");
            Timeout = TimeSpan.FromMinutes(30);
        }
    }
}
