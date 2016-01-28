using Newtonsoft.Json;

namespace StravaConnect.Authentication
{
    public class AccessToken
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
