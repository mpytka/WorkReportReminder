using WorkReportReminder.DataManagement;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;

namespace WorkReportReminder.Common
{
    public interface IApplicationBuilder
    {
        /// <summary>
        /// Creates ui core service.
        /// </summary>
        UICore CreateUICore();

        /// <summary>
        /// Creates data manager service.
        /// </summary>
        IDataManager CreateDataManager();

        /// <summary>
        /// Creates time guard service.
        /// </summary>
        ITimeGuard CreateTimeGuard();
    }
}
