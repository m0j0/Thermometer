using System.Collections.Generic;
using MugenMvvmToolkit.Models;

namespace Thermometer.Projections
{
    public class DeviceProjection : NotifyPropertyChangedBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public double Distance { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public IList<SensorProjection> Sensors { get; set; }
    }
}