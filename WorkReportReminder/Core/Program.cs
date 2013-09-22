using System;
using System.Windows.Forms;

namespace WorkReportReminder.Core
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var core = new Core.ApplicationCore();
            core.Initialise();
            core.Close += OnClose;
            Application.Run(core);
        }

        static void OnClose(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
