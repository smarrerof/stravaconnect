using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaConnect.Clients
{
    public class StravaClient
    {
        public string AccessToken { get; private set; } 
        public AthletesClient Athletes { get; private set; }
        public ActivitiesClient Activities { get; private set; }
        public StreamsClient Streams { get; private set; }

        public StravaClient(string access_token)
        {
            AccessToken = access_token;
            Athletes = new AthletesClient(AccessToken);
            Activities = new ActivitiesClient(AccessToken);
            Streams = new StreamsClient(AccessToken);
        }

    }
}
