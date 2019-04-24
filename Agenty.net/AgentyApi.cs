using Agenty.net.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Agenty.net
{
    public class AgentyApi : IDisposable
    {
        private readonly AgentyRequest _request;
        public HttpClient HttpClient => _request.HttpClient;
        public AgentyApi(string apiKey) : this(new AgentyRequest(apiKey, DefaultHttpClient.CreateDefault()))
        {
        }
        public AgentyApi(string apiKey, HttpClient client) : this(new AgentyRequest(apiKey, DefaultHttpClient.ApplyDefaults(client)))
        {
        }
        private AgentyApi(AgentyRequest request)
        {
            _request = request;
        }

        public void Dispose()
        {
            if (HttpClient is DefaultHttpClient)
                HttpClient.Dispose();
        }

        internal Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest value) where TRequest : AgentyRequestBase
        {
            return _request.PostAsync<TRequest, TResponse>(requestUri, value);
        }
    }
}
