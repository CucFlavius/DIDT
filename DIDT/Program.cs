using System;
using System.Windows.Forms;

namespace DIDT
{
    static class Program
    {
        public static MainWindow window;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window = new MainWindow();
            Application.Run(window);
        }
    }
}
