using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<WorkItemDto> ReadAllItems(string filePath)
        {
            XDocument workItemsDocument = XDocument.Load(filePath);
            var fileData = new List<WorkItemDto>(0);
            if (workItemsDocument != null)
            {
                fileData = (
                                                        from workItem in workItemsDocument.Root.Elements("WorkItem")
                                                        select new WorkItemDto
                                                            (
                                                            int.Parse(workItem.Element("ID").Value),
                                                            workItem.Element("Title").Value,
                                                            workItem.Element("Comment").Value,
                                                            DateTime.Parse(workItem.Element("Time").Value)
                                                            )
                                                    ).ToList<WorkItemDto>();
            }

            return fileData;
        }

        /// <summary>
        /// Reads work items data from specified file and date.
        /// </summary>
        public List<WorkItemDto> ReadAllItems(string filePath, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<WorkItemDto> ReadItemsFromRangeOfTime(string filePath, DateTime begining, DateTime end)
        {
            throw new NotImplementedException();
        }

        public WorkItemDto ReadLastItem(string filePath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
