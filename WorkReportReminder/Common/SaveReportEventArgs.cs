using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkReportReminder.Common
{
    public class SaveReportEventArgs : EventArgs
    {
        public string WorkItemId { get; private set; }
        public string WorkItemTitle { get; private set; }
        public string WorkItemComment { get; private set; }

        public SaveReportEventArgs(string workItemId, string workItemTitle, string workItemComment)
        {
            WorkItemId = workItemId;
            WorkItemTitle = workItemTitle;
            WorkItemComment = workItemComment;
        }
    }
}
