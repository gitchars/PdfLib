using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfLib
{
    public class Point
    {
        private double x;
        private double y;

        public double X { set { x = value; } get { return this.x; } }
        public double Y { set { y = value; } get { return this.y; } }

        public Point( double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
