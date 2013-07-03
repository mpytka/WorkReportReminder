using System;
using WorkReportReminder.Common;
using WorkReportReminder.DataManagement;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;
using WorkReportReminder.UI.Controller;

namespace WorkReportReminder.Core
{
    internal class CoreMediator
    {
        private UICore _uiCore;
        private ITimeGuard _timeGuard;
        private IDataManager _dataManager;

        public void Initialise(UICore uiCore, ITimeGuard timeGuard, IDataManager dataManager)
        {
            _uiCore = uiCore;
            _timeGuard = timeGuard;
            _dataManager = dataManager;
        }

        public void HookUpToEvents()
        {
            _uiCore.SavePostponeRequest += OnSavePostponeReport;
            _uiCore.ReportSaveRequest += OnReportSaveRequest;
            _uiCore.DataRequest += OnDataRequested;
            _uiCore.DataUpdateRequest += OnDataUpdateRequested;

            _timeGuard.TimerRaised += OnTimerRaised;
        }

        private void OnDataUpdateRequested(object sender, EventArgs e)
        {
            var lastItemData = _dataManager.ReadLastItem();
            _uiCore.UpdateView(new WorkItemDto(lastItemData.Id, lastItemData.Title, lastItemData.LastComment.Title));
        }
 
        private void OnDataRequested(object sender, DataRequestEventArgs e)
        {
            var workItems = _dataManager.Read(e.FileName);
            _uiCore.UpdateSummaryView(workItems);
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
