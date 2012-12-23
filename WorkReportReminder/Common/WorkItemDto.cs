using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkReportReminder.Common
{
    public class WorkItemDto
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public Dictionary<DateTime, string> Comment { get; private set; }

        public DateTime Time { get; set; }
        
        public WorkItemDto(int id, string title, string comment, DateTime time)
        {
            Id = id;
            Title = title;
            Comment = new Dictionary<DateTime, string> {{time, comment}};
            Time = time;
        }
    }
}
