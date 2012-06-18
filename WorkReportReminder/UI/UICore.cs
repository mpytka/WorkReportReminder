// -----------------------------------------------------------------------
// <copyright file="UICore.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Drawing;

namespace WorkReportReminder.UI
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class UICore
    {
        private ReportReminderController m_mainController;

        public UICore()
        {
            InitialiseComponents();
            InternalInitialise();
        }

        private void InternalInitialise()
        {
            m_mainController = new ReportReminderController();
        }

        private void ShowMainForm()
        {
            m_mainController.Show();
        }

        private void NotificationIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }
    }
}
