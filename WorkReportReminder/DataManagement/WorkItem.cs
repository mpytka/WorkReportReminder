using System;
using System.Collections.Generic;

namespace WorkReportReminder.DataManagement
{
    /// <summary>
    /// Represents work item.
    /// It contains list of comments added while solving WI.
    /// </summary>
    public class WorkItem
    {
        private const int FIRST_ITEM_INDEX = 0;

        public long Id { get; private set; }
        public string Title { get; private set; }

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
            Comments = new List<WorkItemComment>{new WorkItemComment(comment, startTime)};
        }

        public WorkItem(long id, string title, List<WorkItemComment> workItemComments)
        {
            Id = id;
            Title = title;
            Comments = workItemComments;
        }

        /// <summary>
        /// Adds new comment to work item data.
        /// </summary>
        public void AddComment(string content, DateTime startTime)
        {
            var comment = new WorkItemComment(content, startTime);
            Comments.Add(comment);
        }

        public WorkItemComment LastComment
        {
            get
            {
                return Comments[Comments.Count - 1];
            }
        }

        public WorkItemComment FirstComment
        {
            get
            {
                return Comments[FIRST_ITEM_INDEX];
            }
        }
    }
}