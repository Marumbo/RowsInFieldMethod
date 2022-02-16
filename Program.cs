using CsvHelper;
using RowsInFieldMethod.CSVMapper;
using RowsInFieldMethod.Functions;
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
            
            //initialize variables and objects
            var distanceCalculator = new CalculateDistanceBetweenPoints();

            var pointCheck = new CheckIfPointInPolygon();

            double distance = 0.0;

            Point previousPoint = new Point();

          

            double totalDistance = 0.0;

            double totalSpeed = 0.0;

            double averageSpeed = 0.0;

            bool previousState = false;

            List<Point> lineCoordinates = new List<Point>();

            List<LineObject> finalOutput = new List<LineObject>();

            //go through each record in csv
            foreach (var record in records)
            {
                

                // check if record point is in polygon function
                Point currentPoint = new Point(record.Longitude, record.Latitude);

                pointCheck = new CheckIfPointInPolygon(currentPoint, polygon);

                var isPointInPolygon = pointCheck.IsPointInPolygon();

                if (isPointInPolygon)
                {
                    if (record.SpeedKmh > 0 )
                    {
                        lineCoordinates.Add(previousPoint);
                       
                       // lineCoordinates.Add(currentPoint);

                         distanceCalculator = new CalculateDistanceBetweenPoints(previousPoint, currentPoint);

                       distance = distanceCalculator.GetDistance();

                        totalDistance += distance;

                        totalSpeed += record.SpeedKmh;

                        averageSpeed = totalSpeed / lineCoordinates.Count;

                    }
                    
                    //Console.WriteLine($"Point in Polygon {record.Latitude}, {record.Longitude}");
                   // Console.WriteLine($"Distance between ({currentPoint.Latitude}, {currentPoint.Longitude}) and ({previousPoint.Latitude},{previousPoint.Latitude} = {distance})");
                    //Console.WriteLine($" total Distance = {totalDistance}");

                    previousPoint = currentPoint;
                    previousState = true;
                }
                else
                {
                    if(previousState == true && lineCoordinates.Count > 1 && totalDistance !=0 )
                    {
                        lineCoordinates.Add(previousPoint);

                        LineObject line = new LineObject
                        {
                            Points = lineCoordinates,
                            AverageSpeed = Math.Round(averageSpeed,2),
                            Length = Math.Round(totalDistance,2)
                        };

                        finalOutput.Add(line);
                    }


                    previousPoint = currentPoint;
                    totalDistance = 0.0;
                    totalSpeed = 0.0;
                    previousState = false;
                    lineCoordinates = new List<Point>();

                   // Console.WriteLine($"Point not in Polygon {record.Latitude}, {record.Longitude}");
                    //Console.WriteLine($" total Distance after not in polygon = {totalDistance}");
                }
                //Console.ReadLine();

            }
            Console.WriteLine($"Final line count from system {finalOutput.Count}");

            int count = 1;

            foreach(var lineObject in finalOutput)
            {
                foreach(var point in lineObject.Points)
                {
                    Console.WriteLine($"Coordinates lat: {point.Latitude}, lng:{point.Longitude}");
                }
                Console.WriteLine($"line {count}, line length = {lineObject.Length}Km, average speed = {lineObject.AverageSpeed}Kmh  ");
                Console.WriteLine("-----------------------------------------------------------------");
                count++;
            }
            Console.ReadLine();
        }
    }
}
