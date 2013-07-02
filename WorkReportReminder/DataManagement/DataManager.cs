using System;
using WorkReportReminder.Common;

namespace WorkReportReminder.DataManagement
{
    public class DataManager : IDataManager
    {
        private readonly string _filePath;

        private IDataReader _reader;
        private IDataWriter _writer;

        public DataManager(IDataWriter writer, IDataReader reader, DataManagementConfiguration config)
        {
            _writer = writer;
            _reader = reader;
            _filePath = config.OutputFile;
            Initialise();
        }

        private void Initialise()
        {
            _reader = new XmlDataReader();
            _writer = new XmlDataWriter(_reader);
        }

        #region Implementation of IDataManager

        /// <summary>
        /// Writes work item data.
        /// </summary>
        public void Write(WorkItemDto workItemData)
        {
            _writer.Write(_filePath, workItemData);
        }

        /// <summary>
        /// Reads data of newest work item.
        /// </summary>
        public WorkItem ReadLastItem()
        {
            return _reader.ReadLastItem(_filePath);
        }

        /// <summary>
        /// Reads work items data from specified date.
        /// </summary>
        public WorkItemsList Read(DateTime date)
        {
            return _reader.ReadAllItems(_filePath, date);
        }

        /// <summary>
        /// Reads work items data from specified file.
        /// </summary>
        public WorkItemsList Read(string fileName)
        {
            return _reader.ReadAllItems(fileName);
        }

        #endregion
    }
}
