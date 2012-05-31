// -----------------------------------------------------------------------
// <copyright file="ApplicationCore.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WorkReportReminder.Properties;
using WorkReportReminder;

namespace WorkReportReminder.Core
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ApplicationCore : ApplicationContext
    {
        private System.Windows.Forms.NotifyIcon NotificationIcon;

        private MainController m_mainController;

        public ApplicationCore()
        {
            InitialiseComponents();
            InternalInitialise();
        }

        private void InitialiseComponents()
        {
            this.NotificationIcon = new System.Windows.Forms.NotifyIcon();
            this.NotificationIcon.Icon = ((System.Drawing.Icon)(Resources.TaskBarIcon));
            this.NotificationIcon.Text = "WorkReportReminder";
            this.NotificationIcon.Visible = true;
            this.NotificationIcon.DoubleClick += new System.EventHandler(this.NotificationIcon_DoubleClick);
        }

        private void InternalInitialise()
        {
            m_mainController = new MainController();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotificationIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void ShowMainForm()
        {
            m_mainController.ShowForm();
        }

    }
}
