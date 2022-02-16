using RowsInFieldMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowsInFieldMethod.Functions
{
   public  class CheckIfPointInPolygon
    {
        public Point Point { get; set; }
        public List<Point> Polygon { get; set; }

        public CheckIfPointInPolygon()
        {

        }

        public CheckIfPointInPolygon(Point point, List<Point> polygon)
        {
            Point = point;
            Polygon = polygon;
        }

        public bool IsPointInPolygon()
        {
            double minX = Polygon[0].Latitude;
            double maxX = Polygon[0].Latitude;
            double minY = Polygon[0].Longitude;
            double maxY = Polygon[0].Longitude;
            for (int i = 1; i < Polygon.Count; i++)
            {
                Point q = Polygon[i];
                minX = Math.Min(q.Latitude, minX);
                maxX = Math.Max(q.Latitude, maxX);
                minY = Math.Min(q.Longitude, minY);
                maxY = Math.Max(q.Longitude, maxY);
            }
            if (Point.Latitude < minX || Point.Latitude > maxX || Point.Longitude < minY || Point.Longitude > maxY)
            {
                return false;
            }
            
            bool inside = false;
            for (int i = 0, j = Polygon.Count - 1; i < Polygon.Count; j = i++)
            {
                if ((Polygon[i].Longitude > Point.Longitude) != (Polygon[j].Longitude > Point.Longitude) &&
                     Point.Latitude < (Polygon[j].Latitude - Polygon[i].Latitude) * (Point.Longitude - Polygon[i].Longitude) / (Polygon[j].Longitude - Polygon[i].Longitude) + Polygon[i].Latitude)
                {
                    inside = !inside;
                }
            }
            return inside;
        }
    }
}
