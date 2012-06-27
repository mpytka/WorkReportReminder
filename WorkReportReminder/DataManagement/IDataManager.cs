using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkReportReminder.Common;

namespace WorkReportReminder.DataManagement
{
    public interface IDataManager
    {
        /// <summary>
        /// Writes work item data.
        /// </summary>
        /// <param name="workItemData"></param>
        /// <returns></returns>
        bool Write(WorkItemDto workItemData);

        /// <summary>
        /// Writes a list of work items data.
        /// </summary>
        /// <param name="workItemsData"></param>
        /// <returns></returns>
        bool Write(List<WorkItemDto> workItemsData);

        /// <summary>
        /// Reads all work items data.
        /// </summary>
        /// <returns></returns>
        List<WorkItemDto> Read();

        /// <summary>
        /// Reads work items data from specified date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<WorkItemDto> Read(DateTime date);
    }
}
