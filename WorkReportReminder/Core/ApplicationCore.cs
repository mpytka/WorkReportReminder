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
using WorkReportReminder.UI.Controller;

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
            var logger = new Logger();
            logger.Configure(true);
            Log.Initialise(logger);

            Log.Instance.Info(string.Format("\r\nAppName: {0} \r\nAppVersion: {1}", ApplicationInfo.Name, ApplicationInfo.Version));

            var config = new ConfigurationManager();
            _applicationInitialiser = new ApplicationInitialiser(config);
            _dataManager = _applicationInitialiser.InitialiseDataManager();

            _uiCore = _applicationInitialiser.InitialiseUICore();
            _uiCore.PostponeReportReminder += OnPostponeReport;
            _uiCore.SaveReport += OnSaveReport;
            _uiCore.DataRequest += OnDataRequested;

            var item = _dataManager.ReadLastItem();
            _uiCore.InitialiseViewData(new WorkItemDto(item.Id, item.Title, item.Comments[item.Comments.Count - 1].Content, item.EndTime));

            _timeGuard = _applicationInitialiser.InitialiseTimeGuard();
            _timeGuard.StartTimer();
            _timeGuard.TimerRaised += OnTimerRaised;

            Log.Instance.Info("Initialisation completed.");
        }

        private void OnDataRequested(object sender, DataRequestEventArgs e)
        {
            var workItems = _dataManager.Read(e.FileName);
            _uiCore.UpdateSummaryData(workItems);
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
