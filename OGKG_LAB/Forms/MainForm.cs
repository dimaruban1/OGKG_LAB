using MIConvexHull;
using OGKG_LAB.Forms;
using OGKG_LAB.Solver;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Drawing;
using System.Text;
using KdTree;
using KdTree.Math;

namespace OGKG_LAB
{
    public partial class MainForm : Form
    {
        private PlotModel plotModel;
        private ScatterSeries pointSeries;
        private LineSeries convexHullLineSeries;
        private ScatterSeries voronoiPointSeries;
        private ScatterSeries resultPointSeries;

        private List<Solver.Point> dataPoints;
        private List<Solver.Point> dataPointsByX;
        private List<Solver.Point> dataPointsByY;
        private KdTree<double, int> kd_tree;

        private Solver.ConvexHull _convexHull;


        public MainForm(Solver.ConvexHull convexHull)
        {
            kd_tree = new KdTree<double, int>(2, new DoubleMath());
            
            InitializeComponent();

            plotModel = new PlotModel();

            pointSeries = new ScatterSeries
            {
                Title = "Sample Data",
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                MarkerStroke = OxyColors.Black
            };
            voronoiPointSeries = new ScatterSeries
            {
                Title = "diagram",
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Blue
            };

            resultPointSeries = new ScatterSeries
            {
                Title = "result",
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.Red
            };
            convexHullLineSeries = new LineSeries { LineStyle = LineStyle.Solid, Color = OxyColors.Green };

            InitializePlot();
            _convexHull = convexHull;
        }
        private void InitializePlot()
        {
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                AbsoluteMinimum = -100,
                AbsoluteMaximum = 100,
                Title = "X Axis"
            };

            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                AbsoluteMinimum = -100,
                AbsoluteMaximum = 100,
                Title = "Y Axis"
            };

            dataPoints = new List<Solver.Point>()
            {
                new Solver.Point(0, 4),
                new Solver.Point(1, 7),
                new Solver.Point(2, 2),
                new Solver.Point(3, 9),
                new Solver.Point(4, 5)
            };
            foreach (var point in dataPoints)
            {
                kd_tree.Add(new double[] { point.X, point.Y }, 0);
            }
            pointSeries.Points.AddRange(dataPoints.Select(p => new ScatterPoint(p.X, p.Y)));


            plotModel.Series.Add(pointSeries);
            plotModel.Series.Add(convexHullLineSeries);
            plotModel.Series.Add(voronoiPointSeries);
            plotModel.Series.Add(resultPointSeries);

            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);

            plotView1.Model = plotModel;
            plotView1.MouseDown += AddPointButton_click;
        }
        private void AddPoint(double x, double y)
        {

            pointSeries.Points.Add(new ScatterPoint(x, y));
            dataPoints.Add(new Solver.Point(x, y));
            plotView1.InvalidatePlot(true);
            kd_tree.Add(new double[] { x, y }, 0);
        }
        private void AddPointButton_click(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var d = plotModel.Axes.Count;
                d++;
                var xAxis = plotModel.Axes[0] as LinearAxis;
                var yAxis = plotModel.Axes[1] as LinearAxis;

                if (xAxis != null && yAxis != null)
                {
                    double x = xAxis.InverseTransform(e.Location.X);
                    double y = yAxis.InverseTransform(e.Location.Y);
                    AddPoint(x, y);
                }
            }
        }

        private void AddCircle(ScatterPoint center, double radius)
        {
            Func<double, double> parametricCircleX = t => center.X + radius * Math.Cos(t);
            Func<double, double> parametricCircleY = t => center.Y + radius * Math.Sin(t);

            double tStart = 0;
            double tEnd = 2 * Math.PI;
            double tStep = 0.01;

            var circleSeries = new FunctionSeries(
                (t) => parametricCircleX(t),
                (t) => parametricCircleY(t),
                tStart,
                tEnd,
                tStep)
            {
                Color = OxyColors.Red
            };
            
            plotModel.Series.Add(circleSeries);
        }

        private void GeneratePointsButton_Click(object sender, EventArgs e)
        {
            int xLeftBound = int.Parse(xFromTxt.Text);
            int xRightBound = int.Parse(xToTxt.Text);
            int yLeftBound = int.Parse(yFromTxt.Text);
            int yRightBound = int.Parse(yToTxt.Text);

            int numberOfPoints = int.Parse(numberOfPointsTxt.Text);

            var xAxis = plotModel.Axes[0] as LinearAxis;
            var yAxis = plotModel.Axes[1] as LinearAxis;

            if (xAxis != null && yAxis != null)
            {
                Random random = new Random();

                for (int i = 0; i < numberOfPoints; i++)
                {
                    double x = random.NextDouble() * (xRightBound - xLeftBound) + xLeftBound;
                    double y = random.NextDouble() * (yRightBound - yLeftBound) + yLeftBound;

                    AddPoint(x, y);
                }

                plotView1.InvalidatePlot(true);
            }
        }

        private void DeleteAllPointsButton_Click(object sender, EventArgs e)
        {
            pointSeries.Points.Clear();
            plotModel.Annotations.Clear();
            convexHullLineSeries.Points.Clear();
            resultPointSeries.Points.Clear();
            
            plotModel.Series.Clear();

            plotModel.Series.Add(pointSeries);
            plotModel.Series.Add(convexHullLineSeries);
            plotModel.Series.Add(voronoiPointSeries);
            plotModel.Series.Add(resultPointSeries);
            plotView1.InvalidatePlot(true);
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            
            dataPointsByX = dataPoints.OrderBy(p => p.X).ToList();
            dataPointsByY = dataPoints.OrderBy(p => p.Y).ToList();

            GenerateConvexHullButton_Click(sender, e);

            var vertexPoints = pointSeries.Points.Select(point => new Vertex(point.X, point.Y)).ToList();
            var voronoiEdges = VoronoiDiagram.GetVoronoiEdges(vertexPoints);
            //StringBuilder t = new StringBuilder();
            //foreach (var point in convexHullLineSeries.Points) 
            //{
            //    t.AppendLine("x:" + point.X + "   y:" + point.Y);
            //}
            //testBox.Text = t.ToString();
            var vertices = VoronoiDiagram.GetVoronoiVertices(voronoiEdges);
            foreach (var vertice in vertices)
            {
                voronoiPointSeries.Points.Add(new ScatterPoint(vertice[0], vertice[1]));
            }
            foreach (var edge in voronoiEdges)
            {
                var point1 = new ScatterPoint(edge.Item1[0], edge.Item1[1]);
                var point2 = new ScatterPoint(edge.Item2[0], edge.Item2[1]);

                var intersections = Solver.ConvexHull.FindIntersection(convexHullLineSeries.Points.Select(p => new Solver.Point(p)).ToList(),
                    new Solver.Point(point1),
                    new Solver.Point(point2));
                foreach (var p in intersections)
                {
                    voronoiPointSeries.Points.Add(new ScatterPoint(p.X, p.Y));
                }
            }


            double maxRadius = 0;
            ScatterPoint result = new ScatterPoint(0,0);
            foreach (var vertex in voronoiPointSeries.Points)
            {
                if (Solver.ConvexHull.IsPointInsideConvexHull(new DataPoint(vertex.X, vertex.Y), convexHullLineSeries))
                {
                    double radius = ComputeRadius(vertex);
                    
                    var prevMaxRad = maxRadius;
                    maxRadius = Math.Max(maxRadius, radius);
                    if (prevMaxRad < maxRadius)
                    {
                        result = new ScatterPoint(vertex.X, vertex.Y);
                    }
                }
            }



            AddCircle(result, maxRadius);
            voronoiPointSeries.Points.Clear();
            resultPointSeries.Points.Add(result);

            plotModel.InvalidatePlot(true);
            testBox.Text = result.ToString();

        }

        public double ComputeRadius(ScatterPoint vertex)
        {
            double minDistance = double.MaxValue;
            var closestNodes = kd_tree.GetNearestNeighbours(new double[] { vertex.X, vertex.Y }, 3);
            foreach (var node in closestNodes)
            {
                double distance = Math.Sqrt(Math.Pow(vertex.X - node.Point[0], 2) + Math.Pow(vertex.Y - node.Point[1], 2));
                minDistance = Math.Min(minDistance, distance);
            }

            //for (int i = 0; i < convexHullLineSeries.Points.Count; i++)
            //{
            //    int index = i;
            //    int nextIndex = (i + 1) % convexHullLineSeries.Points.Count;

            //    var lineStart = convexHullLineSeries.Points[index];
            //    var lineEnd = convexHullLineSeries.Points[nextIndex];
            //    var distance = Geometry.DistanceToPointFromLine(new Solver.Point(vertex), new Solver.Point(lineStart), new Solver.Point(lineEnd));
            //    if (distance < minDistance)
            //        minDistance = distance;
            //}
            return minDistance;
        }

        private void GenerateConvexHullButton_Click(object sender, EventArgs e)
        {
            convexHullLineSeries.Points.Clear();

            var points = pointSeries.Points.Select(scatterPoint => new Solver.Point(scatterPoint.X, scatterPoint.Y)).ToList();
            if (points == null)
            {
                return;
            }
            var convexHull = _convexHull.GetConvexHull(points);
            if (convexHull == null)
            {
                return;
            }
            foreach (var p in convexHull)
            {
                convexHullLineSeries.Points.Add(new DataPoint(p.X, p.Y));
            }
            convexHullLineSeries.Points.Add(new DataPoint(convexHull[0].X, convexHull[0].Y));
            plotModel.InvalidatePlot(true);
        }
    }
}
