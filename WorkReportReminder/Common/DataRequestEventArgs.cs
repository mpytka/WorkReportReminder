using System;

namespace WorkReportReminder.UI.Controller
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