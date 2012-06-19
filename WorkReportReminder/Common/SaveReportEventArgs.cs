using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
