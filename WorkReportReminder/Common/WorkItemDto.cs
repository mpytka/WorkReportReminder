using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkReportReminder.Common
{
    public class WorkItemDto
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Comment { get; private set; }

        public DateTime Time { get; set; }

        public WorkItemDto(long id, string title, string comment, DateTime time)
        {
            Id = id;
            Title = title;
            Comment = comment;
            Time = time;
        }
    }
}
