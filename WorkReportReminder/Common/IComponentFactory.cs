using WorkReportReminder.DataManagement;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;

namespace WorkReportReminder.Common
{
    public interface IComponentFactory
    {
        UICore CreateUICore();

        IDataManager CreateDataManager();

        ITimeManager CreateTimeManager();
    }
}
