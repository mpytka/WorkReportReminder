// -----------------------------------------------------------------------
// <copyright file="ApplicationCore.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkReportReminder.Common;
using WorkReportReminder.DataManagement;
using WorkReportReminder.SettingsManagement;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;

namespace WorkReportReminder.Core
{
    /// <summary>
    /// TODO: 
    /// ITimeGuard - BeginShift/EndShift;
    /// ISettingsManager;
    /// IDataManager;
    /// IWorkItemData as DTO instead of string parameters;
    /// </summary>
    public class ApplicationCore : ApplicationContext
    {
        private UICore _uiCore;
        private ITimeGuard _timeGuard;
        private IDataManager _dataManager;
        private IApplicationInitialiser _applicationInitialiser;


        public ApplicationCore()
        {
            Initialise();
        }

        private void Initialise()
        {
            var config = new ConfigurationManager();
            _applicationInitialiser = new ApplicationInitialiser(config);

            _uiCore = _applicationInitialiser.InitialiseUICore();
            _uiCore.PostponeReportReminder += OnPostponeReport;
            _uiCore.SaveReport += OnSaveReport;

            _timeGuard = _applicationInitialiser.InitialiseTimeGuard();
            _timeGuard.StartTimer();
            _timeGuard.TimerRaised += OnTimerRaised;

            _dataManager = _applicationInitialiser.InitialiseDataManager();
        }

        private void OnSaveReport(object sender, SaveReportEventArgs e)
        {
            _timeGuard.ResetTimer();

            _dataManager.Write(e.WorkItemData);
        }

        private void OnPostponeReport(object sender, EventArgs e)
        {
            _timeGuard.PostponeTimer();
        }

        private void OnTimerRaised(object sender, EventArgs eventArgs)
        {
            _uiCore.ShowMainForm();
        }
    }
}
