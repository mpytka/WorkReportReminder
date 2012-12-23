using WorkReportReminder.Common;

namespace WorkReportReminder.DataManagement
{
    interface IDataWriter
    {
        /// <summary>
        /// Add work item data to file.
        /// </summary>
        void Write(string filePath, WorkItemDto singleWorkItemData);
    }
}
