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

            allWorkItemsData.Add(singleWorkItemData);

            UpdateReportFile(filePath, allWorkItemsData);
        }

        #endregion

        /// <summary>
        /// Update file, using data of all existing work items.
        /// </summary>
        private static void UpdateReportFile(string filePath, IEnumerable<WorkItemDto> workItemsData)
        {
            var workItemsDocument = new XDocument(
                new XElement("WorkItems",
                             from workItem in workItemsData
                             select new XElement(
                                 "WorkItem",
                                 new XElement("ID", workItem.Id),
                                 new XElement("Title", workItem.Title),
                                 new XElement("Comment", workItem.Comment),
                                 new XElement("Time", workItem.Time)
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
