using System.Collections.Generic;
using Newtonsoft.Json;

namespace Thermometer.JsonModels
{
    internal class SensorsNearbyRequest
    {
        [JsonProperty("cmd")]
        public string Cmd { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }

        [JsonProperty("radius")]
        public int Radius { get; set; }

        [JsonProperty("types")]
        public IList<int> Types { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

    internal class SensorsNearbyResponseSensor
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("pub")]
        public int Pub { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }

    internal class SensorsNearbyResponseDevice
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("my")]
        public int My { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }

        [JsonProperty("liked")]
        public int Liked { get; set; }

        [JsonProperty("uptime")]
        public int Uptime { get; set; }

        [JsonProperty("sensors")]
        public IList<SensorsNearbyResponseSensor> Sensors { get; set; }
    }

    internal class SensorsNearbyResponse
    {
        [JsonProperty("devices")]
        public IList<SensorsNearbyResponseDevice> Devices { get; set; }
    }
}