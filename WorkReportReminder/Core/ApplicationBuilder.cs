using WorkReportReminder.Common;
using WorkReportReminder.DataManagement;
using WorkReportReminder.DataManagement.XmlData;
using WorkReportReminder.TimeManagement;
using WorkReportReminder.UI.Layout;

namespace WorkReportReminder.Core
{
    internal class ApplicationBuilder : IApplicationBuilder
    {
        private readonly IConfigurationCreator _configurationCreator;

        public ApplicationBuilder(IConfigurationCreator configurationCreator)
        {
            _configurationCreator = configurationCreator;
        }

        /// <summary>
        /// Creates ui core service.
        /// </summary>
        public UICore CreateUICore()
        {
            return new UICore();
        }

        /// <summary>
        /// Creates data manager service.
        /// </summary>
        public IDataManager CreateDataManager()
        {
            // some kind of library loader to load plugin dll
            // at the moment loading only xml reader/writer.
            IDataReader reader = new XmlDataReader();
            IDataWriter writer = new XmlDataWriter(reader);
            var config = _configurationCreator.DataManagementConfiguration();
            return new DataManager(writer, reader, config);
        }

        /// <summary>
        /// Creates time guard service.
        /// </summary>
        public ITimeGuard CreateTimeGuard()
        {
            var config = _configurationCreator.TimeGuardConfiguration();

            ITimeGuard timeGuard = new TimeGuard();
            timeGuard.InitialiseTimer(config);
            return timeGuard;
        }

        /// <summary>
        /// Creates core mediator user to mediate between UI and other parts of application.
        /// </summary>
        public CoreMediator CreateMediator()
        {
            return new CoreMediator();
        }
    }
}
