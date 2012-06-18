
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
    }
}
