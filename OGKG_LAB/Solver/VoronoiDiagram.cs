using MIConvexHull;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGKG_LAB.Solver
{
    public class DoubleArrayComparer : IEqualityComparer<double[]>
    {
        public bool Equals(double[] x, double[] y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(double[] obj)
        {
            int hash = 17;
            foreach (var val in obj)
            {
                hash = hash * 23 + val.GetHashCode();
            }
            return hash;
        }
    }
    public class Vertex : IVertex
    {
        public double[] Position { get; set; }

        public Vertex(double x, double y)
        {
            Position = new double[] { x, y };
        }
    }
    static class VoronoiDiagram
    {
        public static List<double[]> GetVoronoiVertices(List<(double[] Start, double[] End)>  voronoiEdges)
        {
            return voronoiEdges
                .SelectMany(edge => new[] { edge.Start, edge.End })
                .Distinct(new DoubleArrayComparer())
                .ToList();
        }
        public static List<(double[], double[])> GetVoronoiEdges(List<Vertex> points)
        {
            var delaunayTriangulation = DelaunayTriangulation<Vertex, DefaultTriangulationCell<Vertex>>.Create(points, 0.001);
            var voronoiEdges = getVoronoiEdges(delaunayTriangulation);
            return voronoiEdges;
        }

        public static List<(double[] Start, double[] End)> getVoronoiEdges(DelaunayTriangulation<Vertex, DefaultTriangulationCell<Vertex>> delaunayTriangulation)
        {
            var edges = new List<(double[] Start, double[] End)>();

            foreach (var cell in delaunayTriangulation.Cells)
            {
                foreach (var neighbor in cell.Adjacency)
                {
                    if (neighbor != null)
                    {
                        var circumcenter1 = GetCircumcenter(cell.Vertices);
                        var circumcenter2 = GetCircumcenter(neighbor.Vertices);

                        edges.Add((circumcenter1, circumcenter2));
                    }
                }
            }

            return edges;
        }

        public static double[] GetCircumcenter(IList<Vertex> vertices)
        {
            double ax = vertices[0].Position[0];
            double ay = vertices[0].Position[1];
            double bx = vertices[1].Position[0];
            double by = vertices[1].Position[1];
            double cx = vertices[2].Position[0];
            double cy = vertices[2].Position[1];

            double d = 2 * (ax * (by - cy) + bx * (cy - ay) + cx * (ay - by));
            double ux = ((ax * ax + ay * ay) * (by - cy) + (bx * bx + by * by) * (cy - ay) + (cx * cx + cy * cy) * (ay - by)) / d;
            double uy = ((ax * ax + ay * ay) * (cx - bx) + (bx * bx + by * by) * (ax - cx) + (cx * cx + cy * cy) * (bx - ax)) / d;

            return new double[] { ux, uy };
        }
    }
}
