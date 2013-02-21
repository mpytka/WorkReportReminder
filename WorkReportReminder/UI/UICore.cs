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

        public event EventHandler SavePostponeRequested;
        public event EventHandler<SaveReportEventArgs> ReportSaveRequest;
        public event EventHandler ApplicationCloseRequest;

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
            CloseMenuItem.Click += OnCloseMenuItemClick;
            ShowMenuItem.Click += OnShowMenuItemClick;
            SettingsMenuItem.Click += OnSettingsMenuItemClick;
        }

        private void InternalInitialise()
        {
            _mainViewController = new ReportReminderViewController();
            _mainViewController.PostponeSaving += OnReportSavePostponed;
            _mainViewController.Save += OnReportSaveRequested;

            _settingsViewController = new SettingsViewController();
        }

        /// <summary>
        /// Fired when user want to save a report.
        /// </summary>
        private void OnReportSaveRequested(object sender, SaveReportEventArgs e)
        {
            EventHandler<SaveReportEventArgs> temp = ReportSaveRequest;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        /// <summary>
        /// Fired when user postpone report saving.
        /// </summary>
        private void OnReportSavePostponed(object sender, EventArgs e)
        {
            EventHandler temp = SavePostponeRequested;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        #endregion

        /// <summary>
        /// Fired when user double click on notification icon.
        /// </summary>
        private void OnNotificationIconDoubleClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        #region MenuActions

        /// <summary>
        /// Fired when user selects "show" from context menu.
        /// </summary>
        private void OnShowMenuItemClick(object sender, EventArgs eventArgs)
        {
            _mainViewController.Show();
        }

        /// <summary>
        /// Fired when user selects "close" from context menu.
        /// </summary>
        private void OnCloseMenuItemClick(object sender, EventArgs e)
        {
            EventHandler temp = ApplicationCloseRequest;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        /// <summary>
        /// Fired when user selects "settings" from context menu.
        /// </summary>
        private void OnSettingsMenuItemClick(object sender, EventArgs eventArgs)
        {
            //settings are not supported at the moment.
            //_settingsViewController.Show();
        }

        #endregion
    }
}
