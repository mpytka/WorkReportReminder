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
        private MainController m_mainController;

        public UICore()
        {
            InitialiseComponents();
            InternalInitialise();
        }

        private void InternalInitialise()
        {
            m_mainController = new MainController();
        }

        private void ShowMainForm()
        {
            m_mainController.ShowForm();
        }

        private void NotificationIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }
    }
}
