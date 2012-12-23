using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WorkReportReminder.Common;

namespace WorkReportReminder.DataManagement
{
    class XmlDataWriter : IDataWriter
    {
        private readonly IDataReader _reportFileReader;

        public XmlDataWriter(IDataReader reader)
        {
            _reportFileReader = reader;
        }

        #region Implementation of IDataWriter

        /// <summary>
        /// Write work items data to specified file.
        /// </summary>
        public void Write(string filePath, WorkItemDto singleWorkItemData)
        {
            var file = new FileInfo(filePath);
            if (!file.Exists)
            {
                CreateOutputFile(filePath);
            }

            var allWorkItemsData = _reportFileReader.ReadAllItems(filePath);
            var workItem = FindWorkItem(singleWorkItemData, allWorkItemsData);

            if (workItem == null)
            {
                var newWorkItem = new WorkItem(singleWorkItemData.Id, singleWorkItemData.Title,
                                                    singleWorkItemData.Time, singleWorkItemData.Comment);
                allWorkItemsData.Add(newWorkItem);
            }
            else
            {
                workItem.AddComment(singleWorkItemData.Comment, singleWorkItemData.Time);
                workItem.UpdateEndTime(singleWorkItemData.Time);
            }

            UpdateReportFile(filePath, allWorkItemsData);
        }

        private WorkItem FindWorkItem(WorkItemDto item, List<WorkItem> allItems)
        {
            //var workItem = allItems.Find( (long id, string title) => { return (id == item.Id && title == item.Title); });
            var workItem = allItems.Find(wi => wi.Id == item.Id && wi.Title == item.Title);
            return workItem;
        }

        #endregion

        /// <summary>
        /// Update file, using data of all existing work items.
        /// </summary>
        private static void UpdateReportFile(string filePath, IEnumerable<WorkItem> workItemsData)
        {
            var workItemsDocument = new XDocument(
                new XElement("WorkItems",
                             from workItem in workItemsData
                             select new XElement(
                                 "WorkItem",
                                 new XElement("ID", workItem.Id),
                                 new XElement("Title", workItem.Title),
                                 from comment in workItem.Comments
                                     select new XElement("Comment", new XAttribute("Time", comment.Time), comment.Content),
                                 new XElement("StartTime", workItem.StartTime),
                                 new XElement("EndTime", workItem.EndTime)
                                 )
                    )
                );

            workItemsDocument.Save(filePath);
        }

        /// <summary>
        /// Creates empty report file.
        /// </summary>
        private void CreateOutputFile(string filePath)
        {
            var newXml = new XDocument(
                new XElement("WorkItems"));
            newXml.Save(filePath, SaveOptions.None);
        }


    }
}
