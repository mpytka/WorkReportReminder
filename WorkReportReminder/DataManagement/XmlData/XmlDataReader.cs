using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using WorkReportReminder.Common;

namespace WorkReportReminder.DataManagement
{
    class XmlDataReader : IDataReader
    {
        #region Implementation of IDataReader

        /// <summary>
        /// Reads work items data from specified file.
        /// </summary>
        public List<WorkItem> ReadAllItems(string filePath)
        {
            XDocument workItemsDocument = XDocument.Load(filePath);
            var fileData = new List<WorkItem>(0);
            if (workItemsDocument != null)
            {
                fileData = (
                                                        from workItem in workItemsDocument.Root.Elements("WorkItem")
                                                        select new WorkItem
                                                            (
                                                            int.Parse(workItem.Element("ID").Value),
                                                            workItem.Element("Title").Value,
                                                            DateTime.Parse(workItem.Element("StartTime").Value),
                                                            DateTime.Parse(workItem.Element("EndTime").Value),
                                                            //reads a list of comments
                                                            (from comment in workItem.Elements("Comment")
                                                            select new WorkItemComment(
                                                                comment.Value, DateTime.Parse(comment.Attribute("Time").Value)
                                                                )).ToList<WorkItemComment>()
                                                            )
                                                    ).ToList<WorkItem>();
            }

            return fileData;
        }

        /// <summary>
        /// Reads work items data from specified file and date.
        /// </summary>
        public List<WorkItem> ReadAllItems(string filePath, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<WorkItem> ReadItemsFromRangeOfTime(string filePath, DateTime begining, DateTime end)
        {
            throw new NotImplementedException();
        }

        public WorkItem ReadLastItem(string filePath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
