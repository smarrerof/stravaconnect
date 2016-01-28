using StravaConnect.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaConnect.Clients
{
    public class ActivitiesClient
    {
        private string AccessToken { get; set; }
        private HttpJsonClient HttpJsonClient { get; set; }

        public ActivitiesClient(string access_token)
        {
            AccessToken = access_token;
            HttpJsonClient = new HttpJsonClient(AccessToken);
        }

        /// <summary>
        /// Returns an array of activity summary representations sorted newest first by default. Will be sorted oldest first if the after parameter is used.
        /// before, after or page can not be used in combination. They are independent ways of indicating where in the list of activities to begin the results.
        /// </summary>
        /// <param name="before">Seconds since UNIX epoch, result will start with activities whose start_date is before this value</param>
        /// <param name="after">Seconds since UNIX epoch, result will start with activities whose start_date is after this value, sorted oldest first</param>
        /// <param name="page"></param>
        /// <param name="per_page"></param>
        /// <returns>Returns a list of activities for the authenticated user.</returns>
        public async Task<List<ActivitySummary>> GetActivities(int? before = null, int? after = null, int? page = null, int? per_page = null)
        {
            var query = string.Empty;
            if (before.HasValue)
                query = "before=" + before.Value;
            else if (after.HasValue)
                query = "after=" + after.Value;
            else if (page.HasValue)
                query = "page=" + page.Value;

            if (per_page.HasValue)
                query += "per_page=" + per_page.Value;

            var response = await HttpJsonClient.GetAsync<List<ActivitySummary>>("https://www.strava.com/api/v3/athlete/activities", query);

            return response;
        }
    }
}
