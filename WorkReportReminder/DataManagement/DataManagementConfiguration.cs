namespace WorkReportReminder.DataManagement
{
    /// <summary>
    /// Class used to initialise/configure data management module.
    /// </summary>
    public class DataManagementConfiguration
    {
        public DataManagementConfiguration(string outputFilePath)
        {
            OutputFile = outputFilePath;
        }

        public string OutputFile { get; private set; }
    }
}