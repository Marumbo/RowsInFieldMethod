using RowsInFieldMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowsInFieldMethod.Functions
{
   public class QuadrantCheck
    {
       // public double Bearing { get; set; }
      // public QuandrantValue QuadValue { get; set; }

        public QuadrantCheck()
        {
            
        }
    
        public QuandrantValue ReturnQuad(double bearing)
        {
            if(bearing>=0 && bearing <= 90)
            {
                return QuandrantValue.Quad1;

            }
            if (bearing >= 91 && bearing <= 180)
            {
                return QuandrantValue.Quad2;

            }
            if (bearing >= 181 && bearing <= 270)
            {
                return QuandrantValue.Quad3;

            }

            return QuandrantValue.Quad4;
        }
        
    }
}
