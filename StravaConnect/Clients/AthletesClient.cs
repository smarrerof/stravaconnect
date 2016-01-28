using StravaConnect.Athletes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaConnect.Clients
{
    public class AthletesClient
    {
        private string AccessToken { get; set; }
        private HttpJsonClient HttpJsonClient { get; set; }

        public AthletesClient(string access_token)
        {
            AccessToken = access_token;
            HttpJsonClient = new HttpJsonClient(AccessToken);
        }

        public async Task<Athlete> GetCurrentAthleteAsync()
        {
            var response = await HttpJsonClient.GetAsync<Athlete>("https://www.strava.com/api/v3/athlete", string.Empty);

            return response;
        }
    }
}
