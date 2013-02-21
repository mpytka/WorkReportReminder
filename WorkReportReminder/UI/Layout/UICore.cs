// -----------------------------------------------------------------------
// <copyright file="UICore.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Drawing;
using WorkReportReminder.Common;
using WorkReportReminder.UI.Controller;

namespace WorkReportReminder.UI
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class UICore
    {
        private ReportReminderViewController _mainViewController;
        private SettingsViewController _settingsViewController;
        private ReportSummaryController _reportSummary;

        public event EventHandler PostponeReportReminder;
        public event EventHandler<SaveReportEventArgs> SaveReport;

        public UICore()
        {
            InitialiseComponents();
            InternalInitialise();
            HookToMenuActions();
        }

        public void ShowMainForm()
        {
            _mainViewController.Show();
        }

        public void InitialiseViewData(WorkItemDto item)
        {
            _mainViewController.FillViewWithWorkItemData(item);
        }

        #region Private

        private void HookToMenuActions()
        {
            CloseMenuItem.Click += CloseMenuItemOnClick;
            ShowMenuItem.Click += ShowMenuItemOnClick;
            SettingsMenuItem.Click += SettingsMenuItemOnClick;
        }

        private void InternalInitialise()
        {
            _mainViewController = new ReportReminderViewController();
            _mainViewController.PostponeReportReminder += OnPostponeReport;
            _mainViewController.SaveReportData += OnSaveReport;

            _settingsViewController = new SettingsViewController();

            _reportSummary = new ReportSummaryController();
        }

        /// <summary>
        /// Fired when user want to save a report.
        /// </summary>
        private void OnSaveReport(object sender, SaveReportEventArgs e)
        {
            EventHandler<SaveReportEventArgs> temp = SaveReport;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        /// <summary>
        /// Fired when user postpone report saving.
        /// </summary>
        private void OnPostponeReport(object sender, EventArgs e)
        {
            EventHandler temp = PostponeReportReminder;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        #endregion

        private void NotificationIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        #region MenuActions

        private void ShowMenuItemOnClick(object sender, EventArgs eventArgs)
        {
            _mainViewController.Show();
        }

        private void CloseMenuItemOnClick(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        private void SettingsMenuItemOnClick(object sender, EventArgs eventArgs)
        {
            _settingsViewController.Show();
        }

        #endregion
    }
}
