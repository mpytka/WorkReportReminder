using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkReportReminder.UI.View;

namespace WorkReportReminder.UI.Controller
{
    public class SettingsViewController
    {
        private SettingsForm _view;

        public SettingsViewController()
        {
            _view = new SettingsForm();
        }

        public void Show()
        {
            _view.Show();
        }

        public void Save()
        {
            
        }

        public void Read()
        {
            
        }
    }
}
