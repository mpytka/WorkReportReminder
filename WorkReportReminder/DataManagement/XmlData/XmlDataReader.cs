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
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<WorkItemDto> Read(string filePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads work items data from specified file and date.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<WorkItemDto> Read(string filePath, DateTime date)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
