// -----------------------------------------------------------------------
// <copyright file="ApplicationCore.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Forms;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;

namespace WorkReportReminder.Core
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ApplicationCore : ApplicationContext
    {
        private UICore m_uiCore;
        private ITimeManager m_timeManager;

        public ApplicationCore()
        {
            Initialise();
        }

        private void Initialise()
        {
            m_uiCore = new UICore();
            m_uiCore.PostponeReportReminder += OnReportPostponed;

            m_timeManager = new MainTimeManager();
            m_timeManager.InitialiseTimer();
            m_timeManager.StartTimer();
            m_timeManager.TimeElapsed += MainTimerElapsed;

        }

        private void OnReportPostponed(object sender, EventArgs e)
        {
            m_timeManager.PostponeTimer();
        }

        private void MainTimerElapsed(object sender, EventArgs eventArgs)
        {
            m_uiCore.ShowMainForm();
        }
    }
}
