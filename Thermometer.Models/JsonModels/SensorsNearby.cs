namespace Thermometer.JsonModels
{
    internal class SensorsNearbyRequest
    {
        public string cmd { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public int radius { get; set; }
        public int[] types { get; set; }
        public string uuid { get; set; }
        public string api_key { get; set; }
        public string lang { get; set; }
    }

    internal class SensorsNearbyResponse
    {
        public SensorsNearbyResponseDevice[] devices { get; set; }
    }

    internal class SensorsNearbyResponseDevice
    {
        public int id { get; set; }
        public int my { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public float distance { get; set; }
        public int time { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public int liked { get; set; }
        public int uptime { get; set; }
        public SensorsNearbyResponseSensor[] sensors { get; set; }
    }

    internal class SensorsNearbyResponseSensor
    {
        public int id { get; set; }
        public int pub { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public float value { get; set; }
        public string unit { get; set; }
        public int time { get; set; }
    }
}