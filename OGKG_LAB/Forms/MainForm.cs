using OGKG_LAB.Forms;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace OGKG_LAB
{
    public partial class MainForm : Form
    {
        private PlotModel plotModel;
        private ScatterSeries pointSeries;
        public MainForm()
        {
            InitializeComponent();
            InitializePlot();

        }
        private void InitializePlot()
        {
            this.plotModel = new PlotModel();
            var dataPoints = new[]
            {
                new ScatterPoint(0, 4),
                new ScatterPoint(1, 7),
                new ScatterPoint(2, 2),
                new ScatterPoint(3, 9),
                new ScatterPoint(4, 5)
            };

            // Create a line series
            pointSeries = new ScatterSeries
            {
                Title = "Sample Data",
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.Black
            };
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "X Axis"
            };

            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Y Axis"
            };

            pointSeries.Points.AddRange(dataPoints);


            plotModel.Series.Add(pointSeries);

            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);

            plotView1.Model = plotModel;
            plotView1.MouseDown += PlotView_MouseDown;
        }
            private void PlotView_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var d = plotModel.Axes.Count;
                d++;
                var xAxis = plotModel.Axes[0] as LinearAxis;
                var yAxis = plotModel.Axes[1] as LinearAxis;

                if (xAxis != null && yAxis != null)
                {
                    // Get the coordinates of the mouse click relative to the plot area
                    double x = xAxis.InverseTransform(e.Location.X);
                    double y = yAxis.InverseTransform(e.Location.Y);

                    // Add a new data point to the series
                    pointSeries.Points.Add(new ScatterPoint(x, y));

                    // Refresh the plot
                    plotView1.InvalidatePlot(true);
                }
            }
        }
    }
}
