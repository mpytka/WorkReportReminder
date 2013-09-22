using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkReportReminder.Common;
using WorkReportReminder.SettingsManagement;

namespace WorkReportReminder.UI.View
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            DisplaySettings();
        }

        private void DisplaySettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings.Add("One", "1");
            settings.Add("Two", "2");
            settings.Add("Three", "3");
            settings.Add("Four", "4");

            object[] settingsDto = {new SettingsDto(DateTime.Now, DateTime.Now, new TimeSpan(0,0,0,1), new TimeSpan(2,3,4,5) )};

            settingsGrid.SelectedObjects = settingsDto;
            settingsGrid.Enabled = true;
        }
    }
}
