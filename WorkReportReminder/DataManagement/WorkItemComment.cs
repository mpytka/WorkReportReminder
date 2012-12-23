using System;

namespace WorkReportReminder.DataManagement
{
    /// <summary>
    /// Represents comment added to work item.
    /// </summary>
    public class WorkItemComment
    {
        public DateTime Time { get; private set; }
        public string Content { get; private set; }

        public WorkItemComment(string content, DateTime time)
        {
            Content = content;
            Time = time;
        }
    }
}