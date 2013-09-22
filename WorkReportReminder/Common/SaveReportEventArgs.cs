using System;

namespace WorkReportReminder.Common
{
    public class SaveReportEventArgs : EventArgs
    {
        public WorkItemDto WorkItemData { get; private set; }

        public SaveReportEventArgs(WorkItemDto wiData)
        {
            WorkItemData = wiData;
        }
    }
}
