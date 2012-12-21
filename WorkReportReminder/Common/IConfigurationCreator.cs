namespace WorkReportReminder.SettingsManagement
{
    public interface IConfigurationCreator
    {
        /// <summary>
        /// Creates configuration obect used to initialise time management service.
        /// </summary>
        TimeGuardConfiguration TimeGuardConfiguration();
    }
}