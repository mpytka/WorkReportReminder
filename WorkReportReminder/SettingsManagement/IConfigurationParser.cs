using System;

namespace WorkReportReminder.SettingsManagement
{
    /// <summary>
    /// API used to parse configuration keys.
    /// </summary>
    public interface IConfigurationParser
    {
        /// <summary>
        /// Gets configuration value for specified key name and try to parse it as Int.
        /// </summary>
        int GetIntValue(SettingKeys key);

        /// <summary>
        /// Gets configuration value for specified key name and try to parse it as DateTime.
        /// </summary>
        DateTime GetDateTimeValue(SettingKeys key);

        /// <summary>
        /// Gets configuration value for specified key name and try to parse it as TimeSpan.
        /// </summary>
        TimeSpan GetTimeSpanValue(SettingKeys key);

        /// <summary>
        /// Gets file path.
        /// </summary>
        string GetPath(SettingKeys key);
    }
}
