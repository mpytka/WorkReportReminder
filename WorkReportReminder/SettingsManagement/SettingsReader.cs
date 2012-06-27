using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace WorkReportReminder.SettingsManagement
{
    class SettingsReader
    {
        private readonly string SETTINGS_FILE_NAME;
        private XDocument _settingsFile;

        public SettingsReader(string settingsFilePath)
        {
            SETTINGS_FILE_NAME = settingsFilePath;
            _settingsFile = OpenSettingsFile();
        }

        /// <summary>
        /// Gets key value from settnigs xml file.
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public string GetValue(SettingKey keyName)
        {
            string keyValue;
            try
            {
                var query = from key in _settingsFile.Root.Elements()
                            where key.Name == keyName.ToString()
                            select key.Value;

                keyValue = query.First();
                return keyValue;
            }
            catch (InvalidOperationException e)
            {
                throw new ConfigurationException(string.Format("File: {0} does not contain key: {1}", SETTINGS_FILE_NAME, keyName.ToString()));
            }
        }

        /// <summary>
        /// Try to open settings xml file.
        /// </summary>
        /// <returns></returns>
        private XDocument OpenSettingsFile()
        {
            XDocument xmlSettings;
            try
            {
                return XDocument.Load(SETTINGS_FILE_NAME);
            }

            catch (FileNotFoundException e)
            {
                throw new ConfigurationException(string.Format("File: {0} does not exist.", SETTINGS_FILE_NAME));
            }
        }
    }
}
