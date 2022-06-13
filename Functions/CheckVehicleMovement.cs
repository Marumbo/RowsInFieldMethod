using RowsInFieldMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowsInFieldMethod.Functions
{
   public class CheckVehicleMovement
    {
        private Point _startPoint { get; set; }
        private Point _middlePoint { get; set; }
        private Point _endPoint { get; set; }

        public CheckVehicleMovement(List<Point> points)
        {
            _startPoint = points[0];
            _middlePoint = points[1];
            _endPoint = points[2];

        }

        private double CalcuateBearing(Point start, Point end)
        {
            double startLatitudeRad = start.Latitude * Math.PI / 180; // φ, λ in radians
            double endLatitudeRad = end.Latitude * Math.PI / 180;
            double latitudeDifference = (end.Latitude - start.Latitude) * Math.PI / 180;
             double longitudeDifference = (end.Longitude - start.Longitude) * Math.PI / 180;

            double y = Math.Sin(longitudeDifference) * Math.Cos(latitudeDifference);
            double x = Math.Cos(startLatitudeRad) * Math.Sin(endLatitudeRad) -
                      Math.Sin(startLatitudeRad) * Math.Cos(endLatitudeRad) * Math.Cos(longitudeDifference);
            double θ = Math.Atan2(y, x);
            double bearing = (θ * 180 / Math.PI + 360) % 360; // in degrees

            return bearing;
        }

        public VehicleMovementEnum VehicleMovementCheck()
        {
            Console.WriteLine("Start bearing check---------------------------------");

            var startBearing = CalcuateBearing(_startPoint, _middlePoint);
            Console.WriteLine($"Start bearing {startBearing}");

            var endBearing = CalcuateBearing(_middlePoint, _endPoint);
            Console.WriteLine($"End bearing {endBearing}");


            var differenceInBearing = Math.Abs(endBearing - startBearing);
             Console.WriteLine($"Bearing difference ******* {differenceInBearing}  **********");

             Console.WriteLine("End bearing check---------------------------------");

            var threshold = 45;

            var quadrantCheck = new QuadrantCheck();

            var startQuad = quadrantCheck.ReturnQuad(startBearing);
            var endQuad = quadrantCheck.ReturnQuad(endBearing);

            if ((startBearing == 0.0) || (endBearing == 0.0))
            {
                //Console.WriteLine("Straight stationary");

                return VehicleMovementEnum.Stationary;
            }

            if (differenceInBearing >= threshold)
            {

                return VehicleMovementEnum.Turning;
            }


            return VehicleMovementEnum.Straight;
        }
    }
}
