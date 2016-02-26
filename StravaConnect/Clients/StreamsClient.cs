using StravaConnect.Activities;
using StravaConnect.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaConnect.Clients
{
    public class StreamsClient
    {
        private string AccessToken { get; set; }
        private HttpJsonClient HttpJsonClient { get; set; }

        public StreamsClient(string access_token)
        {
            AccessToken = access_token;
            HttpJsonClient = new HttpJsonClient(AccessToken);
        }

        public async Task<List<Stream>> GetActityStreamAsync(int id, string types = "")
        {
            var query = $"/{id}/streams";
            if (!string.IsNullOrEmpty(types))
                query += $"/{types}";

            var response = await HttpJsonClient.GetAsync<List<Stream>>("https://www.strava.com/api/v3/activities", query);

            return response;
        }
        
    }
}
