using System;
using WorkReportReminder.Common;
using WorkReportReminder.DataManagement;
using WorkReportReminder.UI.Controller;

namespace WorkReportReminder.UI.Layout
{
    public partial class UICore
    {
        private ReportReminderViewController _mainViewController;
        private SettingsViewController _settingsViewController;
        private ReportSummaryController _reportSummary;

        public event EventHandler SavePostponeRequest;
        public event EventHandler<SaveReportEventArgs> ReportSaveRequest;
        public event EventHandler<DataRequestEventArgs> DataRequest;
        public event EventHandler DataUpdateRequest;
        public event EventHandler ApplicationCloseRequest;

        public UICore()
        {
            InitialiseComponents();
        }

        public void ShowMainForm()
        {
            _mainViewController.Show();
        }

        #region Private

        private void HookUpToMenuActions()
        {
            CloseMenuItem.Click += OnCloseMenuItemClick;
            ShowMenuItem.Click += OnShowMenuItemClick;
            SettingsMenuItem.Click += OnSettingsMenuItemClick;
            ShowSummaryMenuItem.Click += ShowSummaryMenuItemClick;
        }

        private void RequestMainFormDataUpdate()
        {
            EventHandler temp = DataUpdateRequest;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }

        }

        private void OnDataRequested(object sender, DataRequestEventArgs e)
        {
            EventHandler<DataRequestEventArgs> temp = DataRequest;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        private void OnReportSaveRequested(object sender, SaveReportEventArgs e)
        {
            EventHandler<SaveReportEventArgs> temp = ReportSaveRequest;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        private void OnReportSavePostponed(object sender, EventArgs e)
        {
            EventHandler temp = SavePostponeRequest;
            if(temp != null)
            {
                temp(sender, e);
            }
        }

        #endregion

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
            NotificationIcon.Visible = false;

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

        private void ShowSummaryMenuItemClick(object sender, EventArgs e)
        {
            _reportSummary.Show();
        }

        #endregion

        /// <summary>
        /// Initialises ui core.
        /// </summary>
        public void Initialise()
        {
            _mainViewController = new ReportReminderViewController();
            _mainViewController.PostponeSaving += OnReportSavePostponed;
            _mainViewController.Save += OnReportSaveRequested;

            _settingsViewController = new SettingsViewController();

            _reportSummary = new ReportSummaryController();
            _reportSummary.DataRequested += OnDataRequested;

            RequestMainFormDataUpdate();

            HookUpToMenuActions();
        }

        /// <summary>
        /// Updates summary view with list of work items.
        /// </summary>
        public void UpdateSummaryView(WorkItemsList workItems)
        {
            _reportSummary.UpdateData(workItems);
        }

        /// <summary>
        /// Updates main view (form) with work item data.
        /// </summary>
        public void UpdateView(WorkItemDto workItem)
        {
            _mainViewController.UpdateWorkItemData(workItem);
        }
    }
}
