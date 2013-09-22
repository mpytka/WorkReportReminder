using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WorkReportReminder.Common.Logger;

namespace WorkReportReminder.DataManagement.XmlData
{
    class XmlDataReader : IDataReader
    {
        #region Implementation of IDataReader

        /// <summary>
        /// Reads work items data from specified file.
        /// </summary>
        public WorkItemsList ReadAllItems(string filePath)
        {
            IEnumerable<WorkItem> fileData = new List<WorkItem>();
            var file = new FileInfo(filePath);
            if (file.Exists)
            {
                XDocument workItemsDocument = XDocument.Load(filePath);

                if (workItemsDocument != null)
                {
                    try
                    {
                        fileData = (
                                       from workItem in workItemsDocument.Root.Elements(XmlElements.WorkItem)
                                       select new WorkItem
                                           (
                                           int.Parse(workItem.Element(XmlElements.Id).Value),
                                           workItem.Element(XmlElements.Title).Value,
                                           //reads a list of comments
                                           (from comment in workItem.Elements(XmlElements.Comment)
                                            select new WorkItemComment(
                                                comment.Value,
                                                DateTime.Parse(comment.Attribute(XmlElements.StartTime).Value),
                                                DateTime.Parse(comment.Attribute(XmlElements.EndTime).Value)
                                                )).ToList<WorkItemComment>()
                                           )
                                   ).ToList<WorkItem>();
                    }
                    catch(Exception e)
                    {
                        Log.Instance.Error("Reading file unsuccessful"+e.Message);
                    }
                }
            }

            WorkItemsList workItemsData = new WorkItemsList(fileData);
            Log.Instance.Info(string.Format("Loaded {0} items", workItemsData.Count));
            return workItemsData;
        }

        /// <summary>
        /// Reads work items data from specified file and date.
        /// </summary>
        public WorkItemsList ReadAllItems(string filePath, DateTime date)
        {
            return ReadAllItems(filePath).Filter(date, date);
        }

        public WorkItemsList ReadItemsFromRangeOfTime(string filePath, DateTime start, DateTime end)
        {
            return ReadAllItems(filePath).Filter(start, end);
        }

        public WorkItem ReadLastItem(string filePath)
        {
            //TODO: only temporarly, it can be done better with linq
            var allItems = ReadAllItems(filePath);
            return allItems[allItems.Count - 1];
        }

        #endregion
    }
}
