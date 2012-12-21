using System;
using System.Configuration;

namespace WorkReportReminder.SettingsManagement
{
    internal enum SettingKey
    {
        ShiftStart,
        ShiftEnd,
        ReportReminderInterval,
        PostponeReportReminderInterval
    }

    //TODO: possibility to write settings file
    public class ConfigurationManager : IConfigurationCreator
    {
        private const string CONFIG_FILE_NAME = "settings.xml";

        private SettingsReader _reader;
        private SettingsWritter _writter;

        public ConfigurationManager()
        {
            _reader = new SettingsReader(CONFIG_FILE_NAME);
            _writter = new SettingsWritter(CONFIG_FILE_NAME);
        }

        /// <summary>
        /// Create configuration obect used to initialise time guard service.
        /// </summary>
        public TimeGuardConfiguration TimeGuardConfiguration()
        {
            var normalTimeSpan = GetTimeSpanValue(SettingKey.ReportReminderInterval);
            var postponeTimeSpan = GetTimeSpanValue(SettingKey.PostponeReportReminderInterval);

            var timeConfig = new TimeGuardConfiguration(normalTimeSpan, postponeTimeSpan);
            return timeConfig;
        }

        /// <summary>
        /// Get configuration value for specified key name and try to parse it as Int.
        /// </summary>
        private int GetIntValue(SettingKey key)
        {
            string value = _reader.GetValue(key);
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                throw new ConfigurationException(ErrorMessage(typeof(int), key)); 
            }
        }

        /// <summary>
        /// Get configuration value for specified key name and try to parse it as DateTime.
        /// </summary>
        private DateTime GetDateTimeValue(SettingKey key)
        {
            string value = _reader.GetValue(key);
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                throw new ConfigurationException(ErrorMessage(typeof(DateTime), key));
            }
        }

        /// <summary>
        /// Get configuration value for specified key name and try to parse it as TimeSpan.
        /// </summary>
        private TimeSpan GetTimeSpanValue(SettingKey key)
        {
            string value = _reader.GetValue(key);
            try
            {
                return TimeSpan.Parse(value);
            }
            catch
            {
                throw new ConfigurationException(ErrorMessage(typeof(TimeSpan), key));
            }
        }

        /// <summary>
        /// Error message shown (in exception) when try to read key with invalid value.
        /// </summary>
        private string ErrorMessage(object sender, SettingKey key)
        {
            string error = string.Format("Key \"{0}\" does not contain {1} value.", key.ToString(), sender);
            return error;
        }
        
    }
}
