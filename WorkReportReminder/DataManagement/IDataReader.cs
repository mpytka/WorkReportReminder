using System;

namespace WorkReportReminder.DataManagement
{
    public interface IDataReader
    {
        /// <summary>
        /// Reads work items data from specified file.
        /// </summary>
        WorkItemsList ReadAllItems(string filePath);

        /// <summary>
        /// Reads work items data from specified file and date.
        /// </summary>
        WorkItemsList ReadAllItems(string filePath, DateTime date);

        /// <summary>
        /// Reads all work items from file that match to time range.
        /// Each work item in file has start and end time.
        /// It will reads all items that has at least one date in specified range.
        /// </summary>
        WorkItemsList ReadItemsFromRangeOfTime(string filePath, DateTime begining, DateTime end);

        /// <summary>
        /// Reads data of last (newest) item from specified file.
        /// </summary>
        WorkItem ReadLastItem(string filePath);
    }
}
