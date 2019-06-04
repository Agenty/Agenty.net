using Agenty.net.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Agenty.net
{
    public class AgentyApi : IDisposable
    {
        private readonly AgentyRequest _request;
        private AgentyTeamApi _teams;
        private AgentyAgentApi _agents;

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

        public string ApiKey => _request.ApiKey;
        public IAgentyTeamApi Teams => _teams ?? (_teams = new AgentyTeamApi(this));
        public IAgentyAgentApi Agents => _agents ?? (_agents = new AgentyAgentApi(this));

        public void Dispose()
        {
            if (HttpClient is DefaultHttpClient)
                HttpClient.Dispose();
        }

        internal Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest value) where TRequest : AgentyRequestBase
        {
            return _request.PostAsync<TRequest, TResponse>(requestUri, value);
        }

        internal Task<TResponse> GetAsync<TResponse>(string requestUri)
        {
            return _request.GetAsync<TResponse>(requestUri);
        }
        internal Task<TResponse> DeleteAsync<TResponse>(string requestUri)
        {
            return _request.DeleteAsync<TResponse>(requestUri);
        }
        internal Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest value) where TRequest : AgentyRequestBase
        {
            return _request.PutAsync<TRequest, TResponse>(requestUri, value);
        } 
    }
}
