
namespace WorkReportReminder.UI.Common
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
        /// <param name="errorTitle"></param>
        /// <param name="errorMsg"></param>
        void DisplayErrorMsg(string errorTitle, string errorMsg);

        /// <summary>
        /// Fills fields with work item's data.
        /// </summary>
        void Fill(string id, string title, string comment);
    }
}
