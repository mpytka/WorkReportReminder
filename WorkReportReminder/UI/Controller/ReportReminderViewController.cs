// -----------------------------------------------------------------------
// <copyright file="MainController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Reflection;
using WorkReportReminder.Common;

namespace WorkReportReminder.UI.Controller
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ReportReminderViewController
    {
        private IReportReminderView _view;

        #region Events

        public event EventHandler PostponeReportReminder;
        public event EventHandler<SaveReportEventArgs> SaveReportData;

        #endregion

        public ReportReminderViewController()
        {
            _view = new ReportReminderForm(this);
            Initialise();
        }

        public void PostponeReport()
        {
            EventHandler temp = PostponeReportReminder;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }

            _view.Hide();
        }

        /// <summary>
        /// If validation pass fires SaveReport event and hide view, else shows error message.
        /// </summary>
        /// <param name="workItemId"></param>
        /// <param name="workItemTitle"></param>
        /// <param name="workItemComment"></param>
        /// <returns></returns>
        public void SaveReport(string workItemId, string workItemTitle, string workItemComment)
        {
            try
            {
                ValidateWorkItemID(workItemId);
                ValidateWorkItemTitle(workItemTitle);

                EventHandler<SaveReportEventArgs> temp = SaveReportData;
                if (temp != null)
                {
                    temp(this,
                         new SaveReportEventArgs(
                             new WorkItemDto(
                                 int.Parse(workItemId), 
                                 workItemTitle, 
                                 workItemComment,
                                 DateTime.Now)));
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
            string name;
            string version;

            Assembly assembly = Assembly.GetEntryAssembly();

            name = assembly.GetName().Name;
            version = assembly.GetName().Version.ToString();

            return name + " " + version;
        }

        /// <summary>
        /// Shows form.
        /// </summary>
        public void Show()
        {
            _view.Show();
        }


    }
}
