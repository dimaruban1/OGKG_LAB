using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGKG_LAB.Solver
{
    internal class Geometry
    {
        public static double DistanceToPointFromLine(Point point, Point lineStart, Point lineEnd)
        {
            var x0 = point.X;
            var y0 = point.Y;
            var x1 = lineStart.X;
            var y1 = lineStart.Y;
            var x2 = lineEnd.X;
            var y2 = lineEnd.Y;
            var res = Math.Abs((y2 - y1) * x0 - (x2 - x1) * y0 + x2 * y1 - y2 * x1) / Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));
            return res;
        }

        private static double VectorDotProduct(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        private static double GetDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        private static bool IsPointOnLineSegment(Point point, Point lineStart, Point lineEnd)
        {
            return Math.Abs(point.X - lineStart.X) <= Math.Abs(lineEnd.X - lineStart.X) + 1e-6 &&
                   Math.Abs(point.Y - lineStart.Y) <= Math.Abs(lineEnd.Y - lineStart.Y) + 1e-6;
        }
    }
}
