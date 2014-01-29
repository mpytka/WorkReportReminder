using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkReportReminder.SettingsManagement;
using WorkReportReminder.Common.Logger;

namespace UnitTests
{
    [TestClass]
    public class ConfigurationParserTests
    {
        [Ignore]
        [TestMethod]
        public void ShouldCheckIfKeyWasConvertedProperly()
        {
            var logger = new Logger();
            logger.Configure(true);
            Log.Initialise(logger);

            ConfigurationParser cp = new ConfigurationParser();
            int result = cp.GetIntValue(SettingKeys.PostponeReportReminderInterval);
        }
    }
}
