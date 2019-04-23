using Agenty.net.Models;
using Agenty.net.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest value) where TRequest : AgentyRequestBase
        {
            value.Key = ApiKey;

            var response = await PostAsJsonAsync(requestUri, value).ConfigureAwait(false);
            await EnsureSuccessAsync(response).ConfigureAwait(false);

            return await ReadAsJsonAsync<TResponse>(response.Content).ConfigureAwait(false);
        }

        private async Task<T> ReadAsJsonAsync<T>(HttpContent content)
        {
            using (var stream = await content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return AgentySerializer<T>.Deserialize(jsonReader);
            }
        }

        private async Task<HttpResponseMessage> EnsureSuccessAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                AgentyErrorResponse error = null;

                try
                {
                    error = await ReadAsJsonAsync<AgentyErrorResponse>(response.Content).ConfigureAwait(false);
                }
                catch (Exception)
                {
                }

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException inner)
                {
                    if (error != null)
                        thrown new 
                }
            }
        }

        private async Task<HttpResponseMessage> PostAsJsonAsync<T>(string requestUri, T value, CancellationToken c = default(CancellationToken))
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var content = GetStreamContent(value, writer))
            {
                return await HttpClient.PostAsync(requestUri, content, c).ConfigureAwait(false);
            }

        }

        private StreamContent GetStreamContent<T>(T value, StreamWriter writer)
        {
            using (var jsonWriter = new JsonTextWriter(writer) { CloseOutput = false })
            {
                AgentySerializer<T>.Serialize(jsonWriter, value);
                jsonWriter.Flush();
            }

            writer.BaseStream.Seek(0, SeekOrigin.Begin);
            var content = new StreamContent(writer.BaseStream);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return content;
        }
    }
}
