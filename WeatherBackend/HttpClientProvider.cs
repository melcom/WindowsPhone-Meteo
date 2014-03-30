using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherBackend
{
    public class HttpClientProvider : IDisposable
    {
        #region Fields

        protected readonly HttpClient client;

        #endregion

        #region Constructors and Destructors

        public HttpClientProvider(string baseUri, string token)
            : this(baseUri)
        {
            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("GoogleLogin auth=" + token);
        }

        public HttpClientProvider(string baseUri)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
            client.DefaultRequestHeaders.Add("User-Agent", "Indexification URL Adder 1.0");
        }

        #endregion

        #region Public Methods and Operators

        public void Dispose()
        {
            client.Dispose();
        }

        public async Task<string> Get(string uri)
        {
            HttpResponseMessage response = await client.GetAsync(uri);

            string result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return result;
            }

            throw new HttpRequestException(result);
        }

        public async Task<T> Get<T>(string uri)
        {
            string result = await Get(uri);
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<HttpResponseMessage> Post(string uri, HttpContent content)
        {
            return await client.PostAsync(uri, content);
        }

        #endregion
    }
}