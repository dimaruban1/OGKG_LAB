using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGKG_LAB.Solver
{
    //public class MaxCircleFinder
    //{
    //    public static Circle FindLargestCircle(List<PointF> points)
    //    {
    //        VoronoiDiagram voronoi = BuildVoronoiDiagram(points);
    //        ConvexHull convexHull = BuildConvexHull(points);

    //        Circle maxCircle = new Circle { Radius = 0 };

    //        foreach (var vertex in voronoi.Vertices)
    //        {
    //            if (IsPointInsideConvexHull(vertex, convexHull))
    //            {
    //                float radius = ComputeCircleRadius(vertex, points);
    //                if (radius > maxCircle.Radius)
    //                {
    //                    maxCircle.Center = vertex;
    //                    maxCircle.Radius = radius;
    //                }
    //            }
    //        }

    //        foreach (var edge in voronoi.Edges)
    //        {
    //            var intersectionPoints = FindIntersections(edge, convexHull);
    //            foreach (var point in intersectionPoints)
    //            {
    //                float radius = ComputeCircleRadius(point, points);
    //                if (radius > maxCircle.Radius)
    //                {
    //                    maxCircle.Center = point;
    //                    maxCircle.Radius = radius;
    //                }
    //            }
    //        }

    //        return maxCircle;
    //    }

    //    private static VoronoiDiagram BuildVoronoiDiagram(List<PointF> points)
    //    {
    //        // Implement Voronoi diagram construction logic here
    //        return new VoronoiDiagram();
    //    }

    //    private static bool IsPointInsideConvexHull(PointF point, ConvexHull convexHull)
    //    {
    //        // Implement point-in-polygon test here
    //        return true;
    //    }

    //    private static float ComputeCircleRadius(PointF center, List<PointF> points)
    //    {
    //        // Compute the radius of the circle centered at 'center' and touching the nearest points
    //        float minDistance = float.MaxValue;
    //        foreach (var point in points)
    //        {
    //            float distance = Distance(center, point);
    //            if (distance < minDistance)
    //            {
    //                minDistance = distance;
    //            }
    //        }
    //        return minDistance;
    //    }

    //    private static List<PointF> FindIntersections((PointF, PointF) edge, ConvexHull convexHull)
    //    {
    //        // Implement intersection finding logic here
    //        return new List<PointF>();
    //    }

    //    private static float Distance(PointF p1, PointF p2)
    //    {
    //        return (float)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
    //    }
    //}
}
