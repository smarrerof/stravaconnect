using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaConnect.Streams
{
    public class Stream
    {
        /// <summary>
        /// Streams are available in 11 different types. If the stream is not available for a particular activity it will be left out of the request results.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Array of stream values
        /// </summary>
        [JsonProperty("data")]
        public List<object> Data { get; set; }

        /// <summary>
        /// Series type used for down sampling, will be present even if not used
        /// </summary>
        [JsonProperty("series_type")]
        public string SeriesType { get; set; }

        /// <summary>
        /// Complete stream length
        /// </summary>
        [JsonProperty("original_size")]
        public int OriginalSize { get; set; }

        /// <summary>
        /// ‘low’, ‘medium’ or ‘high’
        /// </summary>
        [JsonProperty("resolution")]
        public string Resolution { get; set; }
    }
}
