using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AverageTemperatureResponse
    {
        public double Temperature { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateOnly StartDay { get; set; }
        public DateOnly EndDay { get; set; }
    }
}
