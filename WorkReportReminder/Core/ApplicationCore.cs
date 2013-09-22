using System;
using System.Windows.Forms;
using WorkReportReminder.Common;
using WorkReportReminder.Common.Logger;
using WorkReportReminder.SettingsManagement;

namespace WorkReportReminder.Core
{
    /// <summary>
    /// Core of an application.
    /// </summary>
    public class ApplicationCore : ApplicationContext
    {
        public event EventHandler Close;

        public ApplicationCore()
        {
            // creates logger service - it has to be the first thing we do
            var logger = new Logger();
            logger.Configure(true);
            Log.Initialise(logger);
        }

        /// <summary>
        /// Initialises core services.
        /// </summary>
        public void Initialise()
        {
            Log.Instance.Info(string.Format("\r\nAppName: {0} \r\nAppVersion: {1}", ApplicationInfo.Name, ApplicationInfo.Version));

            var config = new ConfigurationFactory(new ConfigurationParser());
            var builder = new ApplicationBuilder(config);

            // creating core services
            var dataManager = builder.CreateDataManager();
            var uiCore = builder.CreateUICore();
            var timeGuard = builder.CreateTimeGuard();
            timeGuard.StartTimer();

            var mediator = builder.CreateMediator();
            mediator.Initialise(uiCore, timeGuard, dataManager);
            
            //first we hook up to events.
            mediator.HookUpToEvents();
            //next we initialises UI to catch all events.
            uiCore.Initialise();
            uiCore.ApplicationCloseRequest += OnCloseRequested;

            Log.Instance.Info("Initialisation completed.");
        }

        private void OnCloseRequested(object sender, EventArgs e)
        {
            EventHandler temp = Close;
            if (temp != null)
            {
                temp(sender, e);
            }
        }
    }
}
