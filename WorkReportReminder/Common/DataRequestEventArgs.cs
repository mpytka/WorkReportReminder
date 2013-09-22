using System;

namespace WorkReportReminder.Common
{
    public class DataRequestEventArgs : EventArgs
    {
        public DataRequestEventArgs(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }
    }
}