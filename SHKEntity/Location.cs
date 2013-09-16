using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHKEntity
{
    public class Location
    {

        public Location(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Location(double? x, double? y)
        {
            if (x == null || y == null)
                throw new Exception("Location can't have null coordinates");
            X = (double)x;
            Y = (double)y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
