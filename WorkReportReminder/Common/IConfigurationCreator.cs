using WorkReportReminder.DataManagement;
using WorkReportReminder.TimeManagement;

namespace WorkReportReminder.Common
{
    public interface IConfigurationCreator
    {
        /// <summary>
        /// Creates configuration object used to initialise time management service.
        /// </summary>
        TimeGuardConfiguration TimeGuardConfiguration();

        /// <summary>
        /// Creates configuration object.
        /// </summary>
        DataManagementConfiguration DataManagementConfiguration();
    }
}