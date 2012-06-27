using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using WorkReportReminder.TimeManagement;

namespace WorkReportReminder.SettingsManagement
{
    public enum SettingKey
    {
        ShiftStart,
        ShiftEnd,
        ReportReminderInterval,
        PostponeReportReminderInterval
    }

    //TODO: possibility to write settings file
    public class ConfigurationManager
    {
        private const string CONFIG_FILE_NAME = "settings.xml";

        private SettingsReader _reader;
        private SettingsWritter _writter;

        public ConfigurationManager()
        {
            _reader = new SettingsReader(CONFIG_FILE_NAME);
            _writter = new SettingsWritter(CONFIG_FILE_NAME);
        }

        public string GetStringValue(SettingKey key)
        {
            string value = _reader.GetValue(key);
            return value;
        }

        public int GetIntValue(SettingKey key)
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

        public DateTime GetDateTimeValue(SettingKey key)
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

        public TimeSpan GetTimeSpanValue(SettingKey key)
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

        private string ErrorMessage(object sender, SettingKey key)
        {
            string error = string.Format("Key \"{0}\" does not contain {1} value.", key.ToString(), sender);
            return error;
        }
        
    }
}
