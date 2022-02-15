using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowsInFieldMethod.Models
{
   public class CSVObject
    {
        public DateTime MeasurementTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int SpeedKmh { get; set; }
        public int Profile { get; set; }
        public string ZoneId { get; set; }
        public string ZoneName { get; set; }


    }
}
