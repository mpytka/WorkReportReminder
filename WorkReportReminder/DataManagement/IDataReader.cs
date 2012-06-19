using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkReportReminder.Common;

namespace WorkReportReminder.DataManagement
{
    interface IDataReader
    {
        /// <summary>
        /// Reads work items data from specified file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        List<WorkItemDto> Read(string filePath);

        /// <summary>
        /// Reads work items data from specified file and date.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<WorkItemDto> Read(string filePath, DateTime date);
    }
}
