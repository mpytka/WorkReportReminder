// -----------------------------------------------------------------------
// <copyright file="ApplicationCore.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Forms;
using WorkReportReminder.Common;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;

namespace WorkReportReminder.Core
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ApplicationCore : ApplicationContext
    {
        private UICore _uiCore;
        private ITimeManager _timeManager;

        public ApplicationCore()
        {
            Initialise();
        }

        private void Initialise()
        {
            _uiCore = new UICore();
            _uiCore.PostponeReportReminder += OnPostponeReport;
            _uiCore.SaveReport += OnSaveRepor;

            _timeManager = new MainTimeManager();
            _timeManager.InitialiseTimer();
            _timeManager.StartTimer();
            _timeManager.TimeElapsed += MainTimerElapsed;

        }

        private void OnSaveRepor(object sender, SaveReportEventArgs e)
        {
            _timeManager.ResetTimer();
        }

        private void OnPostponeReport(object sender, EventArgs e)
        {
            _timeManager.PostponeTimer();
        }

        private void MainTimerElapsed(object sender, EventArgs eventArgs)
        {
            _uiCore.ShowMainForm();
        }
    }
}
