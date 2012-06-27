using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WorkReportReminder.SettingsManagement
{
    class SettingsWritter
    {
        private readonly string SETTINGS_FILE_NAME;

        public SettingsWritter(string settingsFilePath)
        {
            SETTINGS_FILE_NAME = settingsFilePath;
        }

        /// <summary>
        /// Generates default - empty - settings file.
        /// </summary>
        public void GenerateDefaultSettingsFile()
        {
            XDocument settingsXml = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XComment("Work report reminder settings file."),
                new XElement("Settings",
                             from key in Enum.GetNames(typeof (SettingKey))
                             select new XElement(
                                 key.ToString(), string.Empty
                                 )
                    )
                );

            settingsXml.Save(SETTINGS_FILE_NAME);
        }
    }
}
