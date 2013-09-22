using System;
using WorkReportReminder.DataManagement;

namespace WorkReportReminder.Common
{
    public interface IDataManager
    {
        /// <summary>
        /// Writes work item data.
        /// </summary>
        void Write(WorkItemDto workItemData);

        /// <summary>
        /// Reads data of last work item from file (the newest one).
        /// </summary>
        WorkItem ReadLastItem();

        /// <summary>
        /// Reads work items data from specified date.
        /// </summary>
        WorkItemsList Read(DateTime date);

        /// <summary>
        /// Reads work items data from specified file.
        /// </summary>
        WorkItemsList Read(string fileName);
    }
}
