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

        public event EventHandler Close;

        public ApplicationCore()
        {
            ///creates logger service - it have to be the first thing we do
            var logger = new Logger();
            logger.Configure(true);
            Log.Initialise(logger);

            var config = new ConfigurationFactory(new ConfigurationParser());
            _applicationInitialiser = new ApplicationInitialiser(config);

            Initialise();
        }

        /// <summary>
        /// Initialises core services.
        /// </summary>
        private void Initialise()
        {
            Log.Instance.Info(string.Format("\r\nAppName: {0} \r\nAppVersion: {1}", ApplicationInfo.Name, ApplicationInfo.Version));

            _dataManager = _applicationInitialiser.InitialiseDataManager();
            _uiCore = _applicationInitialiser.InitialiseUICore();
            _timeGuard = _applicationInitialiser.InitialiseTimeGuard();
            
            _timeGuard.StartTimer();

            HookUpToEvents();
            FillFormWithInitialData();

            Log.Instance.Info("Initialisation completed.");
        }

        /// <summary>
        /// Hooks up to events.
        /// </summary>
        private void HookUpToEvents()
        {
            _uiCore.SavePostponeRequested += OnSavePostponeReport;
            _uiCore.ReportSaveRequest += OnReportSaveRequest;
            _uiCore.ApplicationCloseRequest += OnCloseRequested;
            _uiCore.DataRequest += OnDataRequested;

            _timeGuard.TimerRaised += OnTimerRaised;
        }

        /// <summary>
        /// Fills layout with data of last entered/used work item.
        /// </summary>
        private void FillFormWithInitialData()
        {
            var lastUsedWorkItem = _dataManager.ReadLastItem();
            var workItemDto = new WorkItemDto(lastUsedWorkItem.Id, lastUsedWorkItem.Title, lastUsedWorkItem.LastComment.Title, lastUsedWorkItem.LastComment.EndTime);
            _uiCore.InitialiseViewData(workItemDto);
        }

        private void OnDataRequested(object sender, DataRequestEventArgs e)
        {
            var workItems = _dataManager.Read(e.FileName);
            _uiCore.UpdateSummaryData(workItems);
        }

        private void OnCloseRequested(object sender, EventArgs e)
        {
            EventHandler temp = Close;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        private void OnReportSaveRequest(object sender, SaveReportEventArgs e)
        {
            _timeGuard.ResetTimer();
            _dataManager.Write(e.WorkItemData);
        }

        private void OnSavePostponeReport(object sender, EventArgs e)
        {
            _timeGuard.PostponeTimer();
        }

        private void OnTimerRaised(object sender, EventArgs eventArgs)
        {
            _uiCore.ShowMainForm();
        }
    }
}
