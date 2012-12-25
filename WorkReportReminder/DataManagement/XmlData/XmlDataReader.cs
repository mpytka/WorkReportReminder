﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

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
            var fileData = new List<WorkItem>(0);
            var file = new FileInfo(filePath);
            if (file.Exists)
            {
                XDocument workItemsDocument = XDocument.Load(filePath);

                if (workItemsDocument != null)
                {
                    fileData = (
                                   from workItem in workItemsDocument.Root.Elements(XmlElements.WorkItem.ToString())
                                   select new WorkItem
                                       (
                                       int.Parse(workItem.Element(XmlElements.Id.ToString()).Value),
                                       workItem.Element(XmlElements.Title.ToString()).Value,
                                       DateTime.Parse(workItem.Element(XmlElements.StartTime.ToString()).Value),
                                       DateTime.Parse(workItem.Element(XmlElements.EndTime.ToString()).Value),
                                       //reads a list of comments
                                       (from comment in workItem.Elements(XmlElements.Comment.ToString())
                                        select new WorkItemComment(
                                            comment.Value,
                                            DateTime.Parse(comment.Attribute(XmlElements.Time.ToString()).Value)
                                            )).ToList<WorkItemComment>()
                                       )
                               ).ToList<WorkItem>();
                }
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
            //TODO: only temporarly, it can be done better with linq
            var allItems = ReadAllItems(filePath);
            if (allItems.Count > 0)
            {
                return allItems[allItems.Count - 1];
            }
            else
            {
                return WorkItem.Empty;
            }
        }

        #endregion
    }
}
