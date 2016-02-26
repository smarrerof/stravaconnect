using Newtonsoft.Json;
using StravaConnect.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StravaConnect.Clients
{
    public class HttpJsonClient
    {
        private string AccessToken { get; set; }

        public HttpJsonClient() { }
        public HttpJsonClient(string accessToken)
        {
            AccessToken = accessToken;
        }

        public async Task<TResponse> GetAsync<TResponse>(string endpoint, string query)
        {
            string requestUri = string.Format("{0}{1}", endpoint, string.IsNullOrEmpty(query) ? 
                string.Empty : 
                query.StartsWith("/") ? query : "?" + query);

            using (HttpClient httpClient = new HttpClient())
            {
                if (!string.IsNullOrEmpty(AccessToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                }

                var response = await httpClient.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<TResponse>(response.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<TResponse> PostAsync<TResponse>(string endpoint, string query)
        {
            string requestUri = string.Format("{0}{1}", endpoint, string.IsNullOrEmpty(query) ? string.Empty : "?" + query);

            using (HttpClient httpClient = new HttpClient())
            {
                if (!string.IsNullOrEmpty(AccessToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                }

                var response = await httpClient.PostAsync(requestUri, new StringContent(string.Empty, Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<TResponse>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}

