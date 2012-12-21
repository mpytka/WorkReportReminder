using WorkReportReminder.DataManagement;
using WorkReportReminder.SettingsManagement;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;

namespace WorkReportReminder.Common
{
    public interface IApplicationInitialiser
    {
        UICore InitialiseUICore();

        IDataManager InitialiseDataManagemer();

        ITimeGuard InitialiseTimeGuard();
    }
}
