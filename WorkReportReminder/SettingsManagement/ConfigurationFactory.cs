using System;
using System.Configuration;
using WorkReportReminder.Common;
using WorkReportReminder.DataManagement;
using WorkReportReminder.TimeManagement;

namespace WorkReportReminder.SettingsManagement
{
    public class ConfigurationFactory : IConfigurationCreator
    {
        

        private IConfigurationParser _parser;

        public ConfigurationFactory(IConfigurationParser parser)
        {
            _parser = parser;
        }

        /// <summary>
        /// Create configuration obect used to initialise time guard service.
        /// </summary>
        public TimeGuardConfiguration TimeGuardConfiguration()
        {
            var normalTimeSpan = _parser.GetTimeSpanValue(SettingKeys.ReportReminderInterval);
            var postponeTimeSpan = _parser.GetTimeSpanValue(SettingKeys.PostponeReportReminderInterval);

            return new TimeGuardConfiguration(normalTimeSpan, postponeTimeSpan);
        }

        /// <summary>
        /// Creates configuration object.
        /// </summary>
        public DataManagementConfiguration DataManagementConfiguration()
        {
            var outputFile = _parser.GetPath(SettingKeys.OutputFilePath);

            return new DataManagementConfiguration(outputFile);
        }
    }
}
