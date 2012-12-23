using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkReportReminder.Common;

namespace WorkReportReminder.DataManagement
{
    public class XmlDataManager : IDataManager
    {
        private string _writableFilePath = "writableFile.xml";
        private string _readableFilePath = "readableFile.xml";

        private XmlDataReader _reader;
        private XmlDataWriter _writter;

        public XmlDataManager()
        {
            Initialise();
        }

        private void Initialise()
        {
            _reader = new XmlDataReader();
            _writter = new XmlDataWriter(_reader);
        }

        #region Implementation of IDataManager

        /// <summary>
        /// Writes work item data.
        /// </summary>
        public void Write(WorkItemDto workItemData)
        {
            _writter.Write(_writableFilePath, workItemData);
        }

        /// <summary>
        /// Reads data of newest work item.
        /// </summary>
        public WorkItem ReadLastItem()
        {
            return _reader.ReadLastItem(_readableFilePath);
        }

        /// <summary>
        /// Reads work items data from specified date.
        /// </summary>
        public List<WorkItem> Read(DateTime date)
        {
            return _reader.ReadAllItems(_readableFilePath, date);
        }

        #endregion
    }
}
