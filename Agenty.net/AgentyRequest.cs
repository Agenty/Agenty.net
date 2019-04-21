using Agenty.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Agenty.net
{
    public class AgentyRequest
    {
        public string ApiKey { get; }
        public HttpClient HttpClient { get; }
        public AgentyRequest(string apiKey, HttpClient httpClient)
        {
            ApiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            HttpClient = httpClient;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string apiKey, TRequest v2) where TRequest : AgentyRequestBase
        {
            throw new NotImplementedException();
        }
    }
}
