using WorkReportReminder.Common;
using WorkReportReminder.DataManagement;
using WorkReportReminder.SettingsManagement;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI;

namespace WorkReportReminder.Core
{
    public class ApplicationInitialiser : IApplicationInitialiser
    {
        private readonly IConfigurationCreator _configurationCreator;

        public ApplicationInitialiser(IConfigurationCreator configurationCreator)
        {
            _configurationCreator = configurationCreator;
        }

        /// <summary>
        /// Creates and initialises ui core service.
        /// </summary>
        public UICore InitialiseUICore()
        {
            return new UICore();
        }

        /// <summary>
        /// Creates and initialises data manager service.
        /// </summary>
        public IDataManager InitialiseDataManager()
        {
            ///some kind of library loader to load plugin dll
            //at the moment loading only xml reader/writer.
            IDataReader reader = new XmlDataReader();
            IDataWriter writer = new XmlDataWriter(reader);
            var config = _configurationCreator.DataManagementConfiguration();
            return new DataManager(writer, reader, config);
        }

        /// <summary>
        /// Creates and initialises time guard service.
        /// </summary>
        public ITimeGuard InitialiseTimeGuard()
        {
            var config = _configurationCreator.TimeGuardConfiguration();

            ITimeGuard timeGuard = new TimeGuard();
            timeGuard.InitialiseTimer(config);
            return timeGuard;
        }
    }
}
