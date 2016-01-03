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
}