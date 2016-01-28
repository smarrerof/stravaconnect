using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaConnect.Athletes
{
    public class Athlete
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// URL to a 62x62 pixel profile picture
        /// </summary>
        [JsonProperty("profile_medium")]
        public string ProfileMedium { get; set; }

        /// <summary>
        /// URL to a 124x124 pixel profile picture
        /// </summary>
        [JsonProperty("profile")]
        public string Profile { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// ‘pending’, ‘accepted’, ‘blocked’ or ‘null’ the authenticated athlete’s following status of this athlete
        /// </summary>
        [JsonProperty("friend")]
        public object Friend { get; set; }

        /// <summary>
        /// ‘pending’, ‘accepted’, ‘blocked’ or ‘null’ this athlete’s following status of the authenticated athlete
        /// </summary>
        [JsonProperty("Follower")]
        public object follower { get; set; }

        [JsonProperty("premium")]
        public bool Premium { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("follower_count")]
        public int FollowerCount { get; set; }

        [JsonProperty("FriendCount")]
        public int friend_count { get; set; }

        [JsonProperty("mutual_friend_count")]
        public int MutualFriendCount { get; set; }

        [JsonProperty("date_preference")]
        public string DatePreference { get; set; }

        /// <summary>
        /// ‘feet’ or ‘meters’
        /// </summary>
        [JsonProperty("measurement_preference")]
        public string MeasurementPreference { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// array of summary representations of the athlete’s clubs
        /// </summary>
        [JsonProperty("clubs")]
        public object[] Clubs { get; set; }

        /// <summary>
        /// array of summary representations of the athlete’s bikes
        /// </summary>
        [JsonProperty("Bikes")]
        public object[] bikes { get; set; }

        /// <summary>
        /// array of summary representations of the athlete’s shoes
        /// </summary>
        [JsonProperty("shoes")]
        public object[] Shoes { get; set; }
    }
}
