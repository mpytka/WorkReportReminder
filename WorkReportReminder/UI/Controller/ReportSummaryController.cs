using System;
using WorkReportReminder.DataManagement;

namespace WorkReportReminder.UI.Controller
{
    public class ReportSummaryController
    {
        private IReportSummaryView _view;
        private WorkItemsList _summaryData; 

        public event EventHandler<DataRequestEventArgs> DataRequested;

        public ReportSummaryController()
        {
            InitialiseView();
        }

        private void InitialiseView()
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

        public void UpdateData(WorkItemsList workItems)
        {
            _summaryData = workItems;
        }

        public void Show()
        {
            if (_view == null)
            {
                InitialiseView();
            }

            _view.Show();
        }

        public WorkItemsList PullData()
        {
            return _summaryData;
        }
    }
}
