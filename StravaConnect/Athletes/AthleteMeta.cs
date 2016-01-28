using Newtonsoft.Json;

namespace StravaConnect.Athletes
{
    public class AthleteMeta
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }
    }
}
