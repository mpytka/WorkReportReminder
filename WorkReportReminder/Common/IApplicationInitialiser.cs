using WorkReportReminder.DataManagement;
using WorkReportReminder.SettingsManagement;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;

namespace WorkReportReminder.Common
{
    public interface IApplicationInitialiser
    {
        /// <summary>
        /// Creates and initialises ui core service.
        /// </summary>
        UICore InitialiseUICore();

        /// <summary>
        /// Creates and initialises data manager service.
        /// </summary>
        IDataManager InitialiseDataManager();

        /// <summary>
        /// Creates and initialises time guard service.
        /// </summary>
        ITimeGuard InitialiseTimeGuard();
    }
}
