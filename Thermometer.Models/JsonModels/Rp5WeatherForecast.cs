using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Thermometer.JsonModels
{
    public class Temperature
    {
        [JsonProperty("c")]
        public double C { get; set; }

        [JsonProperty("f")]
        public int F { get; set; }
    }
    
}
