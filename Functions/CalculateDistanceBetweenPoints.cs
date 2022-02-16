using RowsInFieldMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowsInFieldMethod.Functions
{
    public class CalculateDistanceBetweenPoints
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }


        public CalculateDistanceBetweenPoints(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public CalculateDistanceBetweenPoints()
        {
        }

        public double GetDistance()
        {
            if ((Point1.Latitude == Point2.Latitude) && (Point1.Longitude == Point2.Longitude))
            {
                return 0;
            }
            else
            {
                double theta = Point1.Longitude - Point2.Longitude;
                double distance = Math.Sin(deg2rad(Point1.Latitude)) * Math.Sin(deg2rad(Point2.Latitude)) + Math.Cos(deg2rad(Point1.Latitude)) * Math.Cos(deg2rad(Point2.Latitude)) * Math.Cos(deg2rad(theta));
                distance = Math.Acos(distance);
                distance = rad2deg(distance);
                distance = distance * 60 * 1.1515;
                distance = distance * 1.609344;
                distance = Math.Round(distance, 2);
                return (distance);
            }
        }

        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);

        }
    }
}
