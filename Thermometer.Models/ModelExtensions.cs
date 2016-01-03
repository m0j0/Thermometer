using System;

namespace Thermometer
{
    public static class ModelExtensions
    {
        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}