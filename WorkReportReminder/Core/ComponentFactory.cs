using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkReportReminder.Common;
using WorkReportReminder.DataManagement;
using WorkReportReminder.SettingsManagement;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;

namespace WorkReportReminder.Core
{
    public class ComponentFactory : IComponentFactory
    {
        private ConfigurationManager _configurationManager;

        public ComponentFactory()
        {
            _configurationManager = new ConfigurationManager();
        }

        public UICore CreateUICore()
        {
            return new UICore();
        }

        public IDataManager CreateDataManager()
        {
            ///some kind of library loader to load plugin dll
            return new XmlDataManager();
        }

        public ITimeManager CreateTimeManager()
        {
            ///some kind of library loader to load plugin dll
            ITimeManager timeManager = new MainTimeManager();
            timeManager.InitialiseTimer(_configurationManager);
            return timeManager;
        }
    }
}
