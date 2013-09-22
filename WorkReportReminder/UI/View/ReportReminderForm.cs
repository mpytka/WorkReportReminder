using System;
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
        /// Displays error message.
        /// </summary>
        /// <param name="error"></param>
        public void DisplayErrorMsg(string errorTitle, string errorMessage)
        {
            MessageBox.Show(errorMessage, errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Fills fields with work item's data.
        /// </summary>
        public void Fill(string id, string title, string comment)
        {
            idTextBox.Text = id;
            titleTextBox.Text = title;
            commentTextBox.Text = comment;
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
            _viewController.OnReportSaveRequested(idTextBox.Text, titleTextBox.Text, commentTextBox.Text);
        }

        #endregion

        private void PostponeButton_Click(object sender, EventArgs e)
        {
            _viewController.OnSavePostponed();
        }
    }
}
