// -----------------------------------------------------------------------
// <copyright file="MainController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using WorkReportReminder.Common;
using WorkReportReminder.UI;

namespace WorkReportReminder
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ReportReminderController
    {
        private IReportReminderView _view;

        #region Events

        public event EventHandler PostponeReportReminder;
        public event EventHandler<SaveReportEventArgs> SaveReportData;

        #endregion

        public ReportReminderController()
        {
            _view = new ReportReminderForm(this);
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
        /// If validation pass fires SaveReport event, return true and hide view. Else return false.
        /// </summary>
        /// <param name="workItemId"></param>
        /// <param name="workItemTitle"></param>
        /// <param name="workItemComment"></param>
        /// <returns></returns>
        public bool SaveReport(string workItemId, string workItemTitle, string workItemComment)
        {
            if(ValidateWorkItemID(workItemId))
            {
                if(ValidateWorkItemTitle(workItemTitle))
                {
                    EventHandler<SaveReportEventArgs> temp = SaveReportData;
                    if(temp != null)
                    {
                        temp(this, new SaveReportEventArgs(workItemId, workItemTitle, workItemComment));
                    }

                    _view.Hide();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates work item title.
        /// </summary>
        /// <param name="workItemTitle"></param>
        /// <returns></returns>
        private bool ValidateWorkItemTitle(string workItemTitle)
        {
            if(workItemTitle != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Validates work item ID.
        /// </summary>
        /// <param name="workItemId"></param>
        /// <returns></returns>
        private bool ValidateWorkItemID(string workItemId)
        {
            if (workItemId != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
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
