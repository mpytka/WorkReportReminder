using System.Reflection;

namespace WorkReportReminder.Common
{
    public static class ApplicationInfo
    {
        public static string NameAndVersionInfo
        {
            get
            {
                return Name +" "+ Version;
            }
        }

        public static string Name
        {
            get
            {
                Assembly assembly = Assembly.GetEntryAssembly();
                return assembly.GetName().Name;
            }
        }

        public static string Version
        {
            get
            {
                Assembly assembly = Assembly.GetEntryAssembly();
                return assembly.GetName().Version.ToString();
            }
        }
    }
}
