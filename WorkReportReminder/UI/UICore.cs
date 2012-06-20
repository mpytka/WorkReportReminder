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


        public event EventHandler PostponeReportReminder;
        public event EventHandler<SaveReportEventArgs> SaveReport;

        public UICore()
        {
            InitialiseComponents();
            InternalInitialise();
            InitialiseMenuActions();
        }

        private void InitialiseMenuActions()
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
        }

        private void OnSaveReport(object sender, SaveReportEventArgs e)
        {
            EventHandler<SaveReportEventArgs> temp = SaveReport;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        private void OnPostponeReport(object sender, EventArgs e)
        {
            EventHandler temp = PostponeReportReminder;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        private void NotificationIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        public void ShowMainForm()
        {
            _mainViewController.Show();
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
