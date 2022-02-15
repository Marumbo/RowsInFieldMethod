using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using RowsInFieldMethod.Models;

namespace RowsInFieldMethod.CSVMapper
{
   public class CSVObjectMapper : ClassMap<CSVObject>
    {
        public CSVObjectMapper()
        {
            Map(m => m.MeasurementTime).Name("measurement_time");
            Map(m => m.Latitude).Name("latitude");
            Map(m => m.Longitude).Name("longitude");
            Map(m => m.SpeedKmh).Name("speed_kmh");
            Map(m => m.Profile).Name("profil");
            Map(m => m.ZoneId).Name("zone_id");
            Map(m => m.ZoneName).Name("zone_name");
            
        }
    }
}
