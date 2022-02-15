using CsvHelper;
using RowsInFieldMethod.CSVMapper;
using RowsInFieldMethod.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RowsInFieldMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read data from CSV and store in list
            var records = new List<CSVObject>();
           
           using (var streamReader = new StreamReader(@"C:\Users\USER717\Documents\Rwanda school\Internship\agricultural work.csv"))
            {
                using(var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<CSVObjectMapper>();

                    records = csvReader.GetRecords<CSVObject>().ToList();

                }
            }

           //polygon stored in class
            var polygon = Point.FarmPolygon;

            // check if record point is in polygon function


        }
    }
}
