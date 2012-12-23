using System;
using System.Collections.Generic;

namespace WorkReportReminder.DataManagement
{
    /// <summary>
    /// Represents work item added by user.
    /// </summary>
    public class WorkItem
    {
        public long Id { get; private set; }
        public string Title { get; private set; }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public List<WorkItemComment> Comments { get; private set; }
 
        public static WorkItem Empty 
        {
            get
            {
                return new WorkItem(0, string.Empty, DateTime.Now, string.Empty);
            }
        }

        public WorkItem(long id, string title, DateTime startTime, string comment)
        {
            Id = id;
            Title = title;
            //when creating new item, end time is the same as start time.
            StartTime = EndTime = startTime;
            Comments = new List<WorkItemComment>{new WorkItemComment(comment, startTime)};
        }

        public WorkItem(long id, string title, DateTime startTime, DateTime endTime, List<WorkItemComment> workItemComments)
        {
            Id = id;
            Title = title;
            StartTime = startTime;
            EndTime = endTime;
            Comments = workItemComments;
        }

        /// <summary>
        /// Adds new comment to work item data.
        /// </summary>
        public void AddComment(string content, DateTime time)
        {
            var comment = new WorkItemComment(content, time);
            Comments.Add(comment);
        }

        /// <summary>
        /// Updates work items end time (time when work item has been resolved).
        /// </summary>
        public void UpdateEndTime(DateTime time)
        {
            EndTime = time;
        }
    }
}