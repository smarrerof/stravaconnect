using Newtonsoft.Json;
using StravaConnect.Athletes;
using System;

namespace StravaConnect.Activities
{
    public class ActivitySummary
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Indicates level of detail
        /// </summary>
        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        /// <summary>
        /// Provided at upload
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("upload_id")]
        public int? UploadId { get; set; }

        [JsonProperty("athlete")]
        public AthleteMeta Athlete { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// In meters
        /// </summary>
        [JsonProperty("distance")]
        public float Distance { get; set; }

        /// <summary>
        /// In seconds
        /// </summary>
        [JsonProperty("moving_time")]
        public int MovingTime { get; set; }

        /// <summary>
        /// In seconds
        /// </summary>
        [JsonProperty("elapsed_time")]
        public int ElapsedTime { get; set; }

        public float total_elevation_gain { get; set; }


        /// <summary>
        /// Activity type, ie. ride, run, swim, etc.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The type of the activity as enum <see cref="ActivityType"/>.
        /// </summary>
        public ActivityType TypeAsEnum
        {
            get { return (ActivityType)Enum.Parse(typeof(ActivityType), Type); }
        }

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
