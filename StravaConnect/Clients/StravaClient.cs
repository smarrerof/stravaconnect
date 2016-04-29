using StravaConnect.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaConnect.Clients
{
    public class StravaClient
    {
        #region Limits & Usage

        public int LimitShortTerm
        {
            get
            {
                return Limit.ShortTerm;
            }
        }

        public int LimitLongTerm
        {
            get
            {
                return Limit.LongTerm;
            }
        }

        public int UsageShortTerm
        {
            get
            {
                return Usage.ShortTerm;
            }
        }

        public int UsageLongTerm
        {
            get
            {
                return Usage.LongTerm;
            }
        }

        public bool ShortTermExceeded
        {
            get { return UsageLongTerm >= LimitShortTerm; }
        }

        public bool LongTermExceeded
        {
            get { return UsageLongTerm >= LimitLongTerm; }
        }

        #endregion

        #region Clients

        public string AccessToken { get; private set; } 
        public AthletesClient Athletes { get; private set; }
        public ActivitiesClient Activities { get; private set; }
        public StreamsClient Streams { get; private set; }

        #endregion

        public StravaClient(string access_token)
        {
            AccessToken = access_token;
            Athletes = new AthletesClient(AccessToken);
            Activities = new ActivitiesClient(AccessToken);
            Streams = new StreamsClient(AccessToken);
        }

    }
}
