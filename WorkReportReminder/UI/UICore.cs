// -----------------------------------------------------------------------
// <copyright file="UICore.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Drawing;
using WorkReportReminder.Common;

namespace WorkReportReminder.UI
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class UICore
    {
        private ReportReminderController _mainController;

        public event EventHandler PostponeReportReminder;
        public event EventHandler<SaveReportEventArgs> SaveReport;

        public UICore()
        {
            InitialiseComponents();
            InternalInitialise();
        }

        private void InternalInitialise()
        {
            _mainController = new ReportReminderController();
            _mainController.PostponeReportReminder += OnPostponeReport;
            _mainController.SaveReportData += OnSaveReport;
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
            _mainController.Show();
        }
    }
}
