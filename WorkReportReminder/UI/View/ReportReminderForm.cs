using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkReportReminder.UI;
using WorkReportReminder.UI.Controller;


namespace WorkReportReminder
{
    public partial class ReportReminderForm : Form, IReportReminderView
    {
        private string _nameAndVersionInfo = string.Empty;
        private ReportReminderViewController _viewController;

        #region Properties

        #endregion

        public ReportReminderForm(ReportReminderViewController viewController)
        {
            InitializeComponent();
            Initialise();
            _viewController = viewController;
        }

        /// <summary>
        /// Initialises main form.
        /// </summary>
        private void Initialise()
        {
            Hide();
        }

        #region IReportReminderView implementation

        public string SetNameAndVersionInfo
        {
            set { nameAndVersionLabel.Text = value; }
        }

        /// <summary>
        /// Hides form to tray.
        /// </summary>
        public new void Hide()
        {
            base.Hide();
            WindowState = FormWindowState.Minimized;
            TopMost = false;
        }


        /// <summary>
        /// Shows application.
        /// </summary>
        public new void Show()
        {
            base.Show();
            WindowState = FormWindowState.Normal;
            TopMost = true;
        }

        #endregion

        #region Mouse Actions

        private void OKButton_Click(object sender, EventArgs e)
        {
            _viewController.SaveReport(idTextBox.Text, titleTextBox.Text, commentTextBox.Text);
        }

        #endregion

        private void PostponeButton_Click(object sender, EventArgs e)
        {
            _viewController.PostponeReport();
        }
    }
}
