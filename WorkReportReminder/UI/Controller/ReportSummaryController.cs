using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorkReportReminder.DataManagement;
using WorkReportReminder.UI.Layout;

namespace WorkReportReminder.UI.Controller
{
    public class ReportSummaryController
    {
        private IReportSummaryView _view;
        private List<WorkItem> _summaryData; 

        public event EventHandler<DataRequestEventArgs> DataRequested;

        public ReportSummaryController()
        {
            _view = new ReportSummary(this);
        }

        public void GetDataFromFile(string fileName)
        {
            EventHandler<DataRequestEventArgs> temp = DataRequested;
            if(temp != null)
            {
                temp(this, new DataRequestEventArgs(fileName));
            }
        }

        public void UpdateData(List<WorkItem> workItems)
        {
            _summaryData = workItems;
        }

        public void Show()
        {
            _view.Show();
        }

        public ReadOnlyCollection<WorkItem> PullData()
        {
            return _summaryData.AsReadOnly();
        }
    }
}
