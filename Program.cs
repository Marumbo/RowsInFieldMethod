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
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
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

            CSVObject previousRecord = new CSVObject();

            Point currentPoint = new Point();

            Point previousPoint = new Point();

            Point lastPoint = new Point();

            List<Point> bearingPoints = new List<Point>();

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
                currentPoint = new Point(record.Longitude, record.Latitude);

                //Console.WriteLine($"Current Point, lat: {currentPoint.Latitude}, lng {currentPoint.Longitude}");
               // Console.WriteLine($"Previous Point, lat: {previousPoint.Latitude}, lng {previousPoint.Longitude}");
                //Console.WriteLine($"Last Point, lat: {lastPoint.Latitude}, lng {lastPoint.Longitude}");

                pointCheck = new CheckIfPointInPolygon(currentPoint, polygon);

                var isPointInPolygon = pointCheck.IsPointInPolygon();

                if (isPointInPolygon)
                {


                    if (bearingPoints.Count < 3)
                    {
                        Console.WriteLine("Bearing Less than in polygon or equal to 3");
                        bearingPoints.Add(currentPoint);
                        
                    }

                    if (bearingPoints.Count == 3 )
                    {

                        var checkVehicleMovement = new CheckVehicleMovement(bearingPoints);

                        var vehicleMovement = checkVehicleMovement.VehicleMovementCheck();

                        if(vehicleMovement == VehicleMovementEnum.Stationary || record.SpeedKmh == 0)
                        {
                            Console.WriteLine("Vehicle is STATIONARY");
                          //previousState = true;
                        }


                        if (vehicleMovement == VehicleMovementEnum.Straight)
                        {
                            if(record.SpeedKmh > 0)
                            {

                            Console.WriteLine("line is straight");

                            lineCoordinates.Add(previousPoint);

                            // lineCoordinates.Add(currentPoint);

                            distanceCalculator = new CalculateDistanceBetweenPoints(previousPoint, currentPoint);

                            distance = distanceCalculator.GetDistance();

                            totalDistance += distance;

                            totalSpeed += record.SpeedKmh;

                            averageSpeed = totalSpeed / lineCoordinates.Count;

                            previousState = true;

                            }
                        }

                        if (vehicleMovement == VehicleMovementEnum.Turning)
                        {
                            Console.WriteLine("line is turning");
                            
                            if (previousState == true && lineCoordinates.Count > 1 && totalDistance != 0 && record.SpeedKmh > 0)
                            {
                                Console.WriteLine("New line from turning");

                                //add prvious point into line coordinate, adnjust final distance and average speed 


                                lineCoordinates.Add(previousPoint);

                                // lineCoordinates.Add(currentPoint);

                                distanceCalculator = new CalculateDistanceBetweenPoints(previousPoint, currentPoint);

                                distance = distanceCalculator.GetDistance();

                                totalDistance += distance;

                                totalSpeed += record.SpeedKmh;

                                averageSpeed = totalSpeed / lineCoordinates.Count;


                                LineObject line = new LineObject
                                {
                                    Points = lineCoordinates,
                                    AverageSpeed = Math.Round(averageSpeed, 2),
                                    Length = Math.Round(totalDistance, 2)
                                };

                                finalOutput.Add(line);
                            }

                            totalDistance = 0.0;
                            totalSpeed = 0.0;
                            //previousState = true;
                            previousState = false;
                            lineCoordinates = new List<Point>();

                          //  Console.WriteLine("in polygon but turning so we continue points and check for next straight line, ");
                      

                        }


                    }


                    bearingPoints.RemoveAt(0);
                    bearingPoints.Add(currentPoint);
                    lastPoint = previousPoint;
                    previousPoint = currentPoint;
                    //currentPoint = new Point();
                   

                }

                else
                {
              
                    // save state of line and then reset values.
                    if (previousState == true && lineCoordinates.Count > 1 && totalDistance != 0)
                    {
                        Console.WriteLine("New line from not in polygon");
                        
                        lineCoordinates.Add(previousPoint);

                        //lineCoordinates.Add(currentPoint);

                        distanceCalculator = new CalculateDistanceBetweenPoints(previousPoint, currentPoint);

                        distance = distanceCalculator.GetDistance();

                        totalDistance += distance;

                        totalSpeed += record.SpeedKmh;

                        averageSpeed = totalSpeed / lineCoordinates.Count;


                        LineObject line = new LineObject
                        {
                            Points = lineCoordinates,
                            AverageSpeed = Math.Round(averageSpeed, 2),
                            Length = Math.Round(totalDistance, 2)
                        };

                        finalOutput.Add(line);
                    }

                    totalDistance = 0.0;
                    totalSpeed = 0.0;
                    previousState = false;
                    lineCoordinates = new List<Point>();

                    if (bearingPoints.Count < 3 )
                    {
                        
                        bearingPoints.Add(currentPoint);

                    }

                    if(bearingPoints.Count == 3)
                    {

                        bearingPoints.RemoveAt(0);
                        bearingPoints.Add(currentPoint);
                        lastPoint = previousPoint;
                        previousPoint = currentPoint;
                        //currentPoint = new Point();
                    }


                }
                //Console.ReadLine();

            }
            
            Console.WriteLine($"Done with all points");

            Console.WriteLine($"Final line count from system {finalOutput.Count}");

            int count = 1;

            foreach (var lineObject in finalOutput)
            {
                foreach (var point in lineObject.Points)
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
