using Newtonsoft.Json;
using StravaConnect.Authentication;
using StravaConnect.Common;
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

                GetLimits(response);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return default(TResponse);                

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

                GetLimits(response);

                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<TResponse>(response.Content.ReadAsStringAsync().Result);
            }
        }

        private void GetLimits(HttpResponseMessage response)
        {
            HttpHeaders headers = response.Headers;

            IEnumerable<string> values;
            if (response.Headers.TryGetValues("X-RateLimit-Limit", out values))
            {
                var limits = values.First();
                Limit.ShortTerm = Int32.Parse(limits.Split(',')[0]);
                Limit.LongTerm = Int32.Parse(limits.Split(',')[1]);
            }

            if (response.Headers.TryGetValues("X-RateLimit-Usage", out values))
            {
                var usages = values.First();
                Usage.ShortTerm = Int32.Parse(usages.Split(',')[0]);
                Usage.LongTerm = Int32.Parse(usages.Split(',')[1]);
            }

        }
    }
}

