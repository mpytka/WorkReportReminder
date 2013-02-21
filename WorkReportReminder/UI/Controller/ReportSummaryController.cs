

using WorkReportReminder.UI.Layout;

namespace WorkReportReminder.UI.Controller
{
    public class ReportSummaryController
    {
        private IReportSummaryView m_view;

        public ReportSummaryController()
        {
            m_view = new ReportSummary();
        }

       
    }
}
