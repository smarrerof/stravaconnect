using Newtonsoft.Json;

namespace StravaConnect.Activities
{
    public class Map
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("summary_polyline")]
        public string SummaryPolyline { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }
    }
}
