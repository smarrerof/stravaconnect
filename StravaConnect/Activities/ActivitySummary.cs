using Newtonsoft.Json;
using StravaConnect.Athletes;
using System;

namespace StravaConnect.Activities
{
    public class ActivitySummary
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public int resource_state { get; set; }
        public string external_id { get; set; }
        public int upload_id { get; set; }

        [JsonProperty("athlete")]
        public AthleteMeta Athlete { get; set; }

        public string name { get; set; }
        public float distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public float total_elevation_gain { get; set; }
        public string type { get; set; }
        public DateTime start_date { get; set; }
        public DateTime start_date_local { get; set; }
        public string timezone { get; set; }
        public float[] start_latlng { get; set; }
        public float[] end_latlng { get; set; }
        public int achievement_count { get; set; }
        public int kudos_count { get; set; }
        public int comment_count { get; set; }
        public int athlete_count { get; set; }
        public int photo_count { get; set; }
        public int total_photo_count { get; set; }
        public Map map { get; set; }
        public bool trainer { get; set; }
        public bool commute { get; set; }
        public bool manual { get; set; }
        public bool _private { get; set; }
        public bool flagged { get; set; }
        public float average_speed { get; set; }
        public float max_speed { get; set; }
        public float average_watts { get; set; }
        public int max_watts { get; set; }
        public int weighted_average_watts { get; set; }
        public float kilojoules { get; set; }
        public bool device_watts { get; set; }
        public float average_heartrate { get; set; }
        public float max_heartrate { get; set; }
    }
}
