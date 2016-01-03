using System.Collections.Generic;
using MugenMvvmToolkit.Models;

namespace Thermometer.Projections
{
    public class DeviceProjection : NotifyPropertyChangedBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public float Distance { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public IList<SensorProjection> Sensors { get; set; }
    }
}