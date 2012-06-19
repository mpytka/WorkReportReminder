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
            _writter = new XmlDataWriter();
        }

        #region Implementation of IDataManager

        /// <summary>
        /// Writes work item data.
        /// </summary>
        /// <param name="workItemData"></param>
        /// <returns></returns>
        public bool Write(WorkItemDto workItemData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a list of work items data.
        /// </summary>
        /// <param name="workItemsData"></param>
        /// <returns></returns>
        public bool Write(List<WorkItemDto> workItemsData)
        {
            return _writter.Write(_writableFilePath, workItemsData);
        }

        /// <summary>
        /// Reads all work items data.
        /// </summary>
        /// <returns></returns>
        public List<WorkItemDto> Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads work items data from specified date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<WorkItemDto> Read(DateTime date)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
