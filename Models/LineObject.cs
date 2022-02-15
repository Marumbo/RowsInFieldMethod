using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowsInFieldMethod.Models
{
   public class LineObject
    {
        public List<Point> Points { get; set; }

        public double Length { get; set; }

        public double AverageSpeed { get; set; }

    }
}
