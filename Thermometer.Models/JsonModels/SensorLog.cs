using System.Collections.Generic;
using Newtonsoft.Json;

namespace Thermometer.JsonModels
{
    internal class SensorLogRequest
    {
        [JsonProperty("cmd")]
        public string Cmd { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }

    internal class SensorLogResponse
    {
        [JsonProperty("data")]
        public IList<SensorLogResponseData> Data { get; set; }
    }

    internal class SensorLogResponseData
    {
        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }
}