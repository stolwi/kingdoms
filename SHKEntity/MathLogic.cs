using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHKEntity
{
    public class MathLogic
    {
        // Yeah, I made up the term bilaterate. Kinda like trilaterate, but with two points and the distances to a third point, 
        // assuming that the y direction is known.

        // Given the distance between points 1 and 2 (x),
        // The distance between point 1 and point 3 (u),
        // And the distance between point 2 and point 3 (t),
        // return the distance between the point 3 and the line formed by points 1 and 2 (y)
        // and the distance between point 2 and closest point on that line
        public static Location Bilaterate(double x, double u, double t) 
        {
            double b = (x * x + t * t - u * u) / (2 * x);
            double y = Math.Sqrt(t * t - b * b);

            return new Location(b, y);
        }

        // given 3 known points, and distances from those points to a fourth point,
        // solve for the x,y of the fourth point.
        public static Location Trilaterate(Location p1, Location p2, Location p3, double r1, double r2, double r3)
        {
            
            double y = solveY(p1, p2, p3, r1, r2, r3);
            double x = solveX(p1, p2, p3, r1, r2, r3, y);

            return new Location (x, y);
        }

        private static double solveY(Location p1, Location p2, Location p3, double r1, double r2, double r3)
        {
            double a1 = p1.X;
            double a2 = p2.X;
            double a3 = p3.X;
            double b1 = p1.Y;
            double b2 = p2.Y;
            double b3 = p3.Y;

            double numerator = (a2 - a1) * (a3 * a3 + b3 * b3 - r3 * r3) +
                            (a1 - a3) * (a2 * a2 + b2 * b2 - r2 * r2) +
                            (a3 - a2) * (a1 * a1 + b1 * b1 - r1 * r1);
            double denom = 2 * (b3 * (a2 - a1) + b2 * (a1 - a3) + b1 * (a3 - a2));
            return numerator / denom;
        }

        private static double solveX(Location p1, Location p2, Location p3, double r1, double r2, double r3, double y)
        {
            double a1 = p1.X;
            double a2 = p2.X;
            double a3 = p3.X;
            double b1 = p1.Y;
            double b2 = p2.Y;
            double b3 = p3.Y;

            double numerator = r2 * r2 + a1 * a1 + b1 * b1 - r1 * r1 - a2 * a2 - b2 * b2 - 2 * (b1 - b2) * y;
            double denom = 2 * (a1 - a2);
            return numerator / denom;
        }
    }
}
