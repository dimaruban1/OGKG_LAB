using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGKG_LAB.Solver
{
    public class Point
    {
        public double X;
        public double Y;
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point(DataPoint point)
        {
            X = point.X;
            Y = point.Y;
        }
        public Point(ScatterPoint point)
        {
            X = point.X;
            Y = point.Y;
        }
        public double GetLengthSquared()
        {
            return X * X + Y * Y;
        }
    }
}
