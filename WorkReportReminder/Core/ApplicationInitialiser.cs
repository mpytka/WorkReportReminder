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
    public class ApplicationInitialiser : IApplicationInitialiser
    {
        private readonly IConfigurationCreator _configurationManager;

        public ApplicationInitialiser()
        {
            _configurationManager = new ConfigurationManager();
        }

        public UICore InitialiseUICore()
        {
            return new UICore();
        }

        public IDataManager InitialiseDataManagemer()
        {
            ///some kind of library loader to load plugin dll
            return new XmlDataManager();
        }

        public ITimeGuard InitialiseTimeGuard()
        {
            var config = _configurationManager.TimeGuardConfiguration();

            ITimeGuard timeGuard = new MainTimeGuard();
            timeGuard.InitialiseTimer(config);
            return timeGuard;
        }
    }
}
