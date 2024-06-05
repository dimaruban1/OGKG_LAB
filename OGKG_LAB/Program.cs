using OGKG_LAB.Solver;

namespace OGKG_LAB
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var convexHull = new ConvexHull();


            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(convexHull));
        }
    }
}