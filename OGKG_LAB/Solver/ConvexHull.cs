

using MIConvexHull;
using OxyPlot;
using OxyPlot.Series;

namespace OGKG_LAB.Solver
{
    public class ConvexHull
    {
        public ConvexHull()
        {
        }
        public double cross(Point O, Point A, Point B)
        {
            return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
        }

        public List<Point> GetConvexHull(List<Point> points)
        {
            if (points.Count <= 1)
                return new List<Point>(points);

            points = points.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();

            // Build the lower hull
            List<Point> lower = new List<Point>();
            foreach (var p in points)
            {
                while (lower.Count >= 2 && cross(lower[lower.Count - 2], lower[lower.Count - 1], p) <= 0)
                {
                    lower.RemoveAt(lower.Count - 1);
                }
                lower.Add(p);
            }

            // Build the upper hull
            List<Point> upper = new List<Point>();
            for (int i = points.Count - 1; i >= 0; i--)
            {
                var p = points[i];
                while (upper.Count >= 2 && cross(upper[upper.Count - 2], upper[upper.Count - 1], p) <= 0)
                {
                    upper.RemoveAt(upper.Count - 1);
                }
                upper.Add(p);
            }

            lower.RemoveAt(lower.Count - 1);
            upper.RemoveAt(upper.Count - 1);

            return lower.Concat(upper).ToList();
        }

        public static bool IsPointInsideConvexHull(DataPoint point, LineSeries convexHullLines)
        {
            bool isInside = true;

            for (int i = 0; i < convexHullLines.Points.Count; i++)
            {
                int index = i;
                int nextIndex = (i + 1) % convexHullLines.Points.Count;

                var lineStart = convexHullLines.Points[index];
                var lineEnd = convexHullLines.Points[nextIndex];

                var orientation = Orientation(lineStart, lineEnd, point);

                // The point is outside if the orientation is counter-clockwise (left turn)
                if (orientation == 2)
                {
                    isInside = false;
                    break;
                }
            }
            return isInside;
        }

        // Helper function to check orientation of a point relative to a line segment
        public static int Orientation(DataPoint p0, DataPoint p1, DataPoint p2)
        {
            var value = (p1.X - p0.X) * (p2.Y - p0.Y) - (p2.X - p0.X) * (p1.Y - p0.Y);
            if (value == 0) return 0; // colinear
            return value > 0 ? 1 : 2; // clock-wise : counter-clockwise
        }

        public static List<Point> FindIntersection(List<Point> hull, Point linePoint1, Point linePoint2)
        {
            List<Point> intersections = new List<Point>();

            for (int i = 0; i < hull.Count; i++)
            {
                var hullP1 = hull[i];
                var hullP2 = hull[(i + 1) % hull.Count];
                var intersection = ComputeIntersection(linePoint1, linePoint2, hullP1, hullP2);
                if (intersection != null)
                {
                    intersections.Add(intersection);
                }
            }

            return intersections;
        }

        private static Point ComputeIntersection(Point p1, Point p2, Point q1, Point q2)
        {
            double denominator = (q2.Y - q1.Y) * (p2.X - p1.X) - (q2.X - q1.X) * (p2.Y - p1.Y);
            if (denominator == 0)
            {
                return new Point(0,0);
            }

            double t = ((q1.X - p1.X) * (q2.Y - q1.Y) - (q1.Y - p1.Y) * (q2.X - q1.X)) / denominator;
            double s = ((q1.X - p1.X) * (p2.Y - p1.Y) - (q1.Y - p1.Y) * (p2.X - p1.X)) / denominator;

            if (t >= 0 && t <= 1 && s >= 0 && s <= 1)
            {
                double x = p1.X + t * (p2.X - p1.X);
                double y = p1.Y + t * (p2.Y - p1.Y);
                return new Point(x, y);
            }

            return new Point(0,0);
        }
    }
}
