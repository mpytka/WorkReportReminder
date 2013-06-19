using System;

namespace WorkReportReminder.DataManagement
{
    /// <summary>
    /// Represents comment added to work item.
    /// </summary>
    public class WorkItemComment
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string Title { get; private set; }

        public WorkItemComment(string content, DateTime startTime):this(content, startTime, startTime)
        {
        }

        public WorkItemComment(string content, DateTime startTime, DateTime endTime)
        {
            Title = content;
            StartTime = startTime;
            EndTime = endTime;
        }

        public void SetEndTime(DateTime endTime)
        {
            EndTime = endTime;
        }
    }
}