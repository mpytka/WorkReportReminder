
using System;

namespace WorkReportReminder.UI
{
    public interface IReportReminderView
    {
        /// <summary>
        /// Shows view.
        /// </summary>
        void Show();

        /// <summary>
        /// Hides view.
        /// </summary>
        void Hide();

        /// <summary>
        /// Sets name and version info, that is displayed on form.
        /// </summary>
        string SetNameAndVersionInfo { set; }

        /// <summary>
        /// Displays error message.
        /// </summary>
        /// <param name="error"></param>
        void DisplayErrorMsg(string errorTitle, string errorMsg);

        /// <summary>
        /// Fills fields with work item's data.
        /// </summary>
        void Fill(string id, string title, string comment);
    }
}
