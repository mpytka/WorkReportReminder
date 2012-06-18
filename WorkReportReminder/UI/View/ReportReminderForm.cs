using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkReportReminder.UI;


namespace WorkReportReminder
{
    public partial class ReportReminderForm : Form, IReportReminderView
    {
        private string m_nameAndVersionInfo = string.Empty;

        #region Events

        public event EventHandler OKButtonClicked;
        public event EventHandler PostponeButtonClicked;

        #endregion

        #region Properties

        #endregion

        public ReportReminderForm()
        {
            InitializeComponent();
            Initialise();
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
        }

        /// <summary>
        /// Shows application.
        /// </summary>
        public new void Show()
        {
            base.Show();
            WindowState = FormWindowState.Normal;
        }

        #endregion

        #region Mouse Actions

        private void OKButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        #endregion
    }
}
