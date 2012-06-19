using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkReportReminder.Common;

namespace WorkReportReminder.DataManagement
{
    interface IDataWriter
    {
        /// <summary>
        /// Write work items data to specified file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="workItemsData"></param>
        /// <returns></returns>
        bool Write(string filePath, List<WorkItemDto> workItemsData);
    }
}
