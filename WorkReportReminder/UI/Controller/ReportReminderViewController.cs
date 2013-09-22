using System;
using WorkReportReminder.Common;
using WorkReportReminder.UI.Common;
using WorkReportReminder.UI.View;

namespace WorkReportReminder.UI.Controller
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ReportReminderViewController
    {
        private readonly IReportReminderView _view;

        #region Events

        public event EventHandler PostponeSaving;
        public event EventHandler<SaveReportEventArgs> Save;

        #endregion

        /// <summary>
        /// Fills fields with work item's data.
        /// It is usable while application initialisation, to not leave fields empty.
        /// </summary>
        public void UpdateWorkItemData(WorkItemDto item)
        {
            _view.Fill(item.Id.ToString(), item.Title, item.Comment);
        }

        /// <summary>
        /// Initialises view.
        /// </summary>
        public ReportReminderViewController()
        {
            _view = new ReportReminderForm(this);
            Initialise();
        }

        /// <summary>
        /// Fires PostponeReportRequest event.
        /// </summary>
        public void OnSavePostponed()
        {
            EventHandler temp = PostponeSaving;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }

            _view.Hide();
        }

        /// <summary>
        /// Shows form.
        /// </summary>
        public void Show()
        {
            _view.Show();
        }

        /// <summary>
        /// If validation pass fires OnReportSaveRequested event and hide view, else shows error message.
        /// </summary>
        public void OnReportSaveRequested(string workItemId, string workItemTitle, string workItemComment)
        {
            try
            {
                ValidateWorkItemID(workItemId);
                ValidateWorkItemTitle(workItemTitle);

                EventHandler<SaveReportEventArgs> temp = Save;
                if (temp != null)
                {
                    temp(this,
                         new SaveReportEventArgs(
                             new WorkItemDto(
                                 int.Parse(workItemId), 
                                 workItemTitle, 
                                 workItemComment)));
                }

                _view.Hide();
            }
            catch(Exception e)
            {
                _view.DisplayErrorMsg("Entered value error.", e.Message);
            }
        }

        /// <summary>
        /// Validates work item title.
        /// </summary>
        /// <param name="workItemTitle"></param>
        /// <returns></returns>
        private void ValidateWorkItemTitle(string workItemTitle)
        {
            if(workItemTitle == string.Empty)
            {
                throw new FormatException("Title field cannot be empty.");
            }
        }

        /// <summary>
        /// Validates work item ID.
        /// </summary>
        /// <param name="workItemId"></param>
        /// <returns></returns>
        private void ValidateWorkItemID(string workItemId)
        {
            try
            {
                Convert.ToInt32(workItemId);
            }
            catch(FormatException)
            {
                throw new FormatException("ID must be integer value.");
            }
            catch(OverflowException)
            {
                throw new OverflowException("ID has incorrect value.");
            }
        }

        private void Initialise()
        {
            _view.SetNameAndVersionInfo = NameAndVersionInfo();
        }

        /// <summary>
        /// Returns name and version information.
        /// </summary>
        /// <returns></returns>
        private string NameAndVersionInfo()
        {
            return ApplicationInfo.NameAndVersionInfo;
        }
    }
}
