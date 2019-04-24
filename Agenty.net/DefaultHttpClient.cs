using System;
using System.Net.Http;
using System.Reflection;

namespace Agenty.net
{
    class DefaultHttpClient : HttpClient
    {
        private DefaultHttpClient()
        {
        }

        private static readonly Lazy<Version> UserAgentVersionLazy = new Lazy<Version>(() => new AssemblyName(typeof(AgentyRequest).GetTypeInfo().Assembly.FullName).Version);
        private static readonly Uri BaseUrl = new Uri("https://api.agenty.com/v1");

        public static HttpClient CreateDefault()
        {
            var httpClient = new DefaultHttpClient();
            return ApplyDefaults(httpClient);
        }

        public static HttpClient ApplyDefaults(HttpClient httpClient)
        {
            httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            httpClient.BaseAddress = httpClient.BaseAddress ?? BaseUrl;

            if (httpClient.DefaultRequestHeaders.UserAgent.Count == 0)
                httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("Agenty.net", UserAgentVersionLazy.Value.ToString(3)));

            if (httpClient.DefaultRequestHeaders.Accept.Count == 0)
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
