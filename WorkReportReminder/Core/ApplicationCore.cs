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
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;

namespace WorkReportReminder.Core
{
    /// <summary>
    /// TODO: 
    /// ITimeManager - BeginShift/EndShift;
    /// ISettingsManager;
    /// IDataManager;
    /// IWorkItemData as DTO instead of string parameters;
    /// </summary>
    public class ApplicationCore : ApplicationContext
    {
        private UICore _uiCore;
        private ITimeManager _timeManager;
        private IDataManager _dataManager;

        public ApplicationCore()
        {
            Initialise();
        }

        private void Initialise()
        {
            _uiCore = new UICore();
            _uiCore.PostponeReportReminder += OnPostponeReport;
            _uiCore.SaveReport += OnSaveReport;

            _timeManager = new MainTimeManager();
            _timeManager.InitialiseTimer();
            _timeManager.StartTimer();
            _timeManager.TimeElapsed += MainTimerElapsed;

            _dataManager = new XmlDataManager();
        }

        private void OnSaveReport(object sender, SaveReportEventArgs e)
        {
            _timeManager.ResetTimer();
            List<WorkItemDto> tempWiList = new List<WorkItemDto>();
            tempWiList.Add(e.WorkItemData);

            _dataManager.Write(tempWiList);
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
