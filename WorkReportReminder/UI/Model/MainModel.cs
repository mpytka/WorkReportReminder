using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WorkReportReminder
{
    public partial class MainModel : Form
    {
        private string m_nameAndVersionInfo = string.Empty;
        #region Properties

        public string NameAndVersionInfo
        {
            get
            {
                return m_nameAndVersionInfo;
            }
            set
            {
                m_nameAndVersionInfo = value;
                nameAndVersionLabel.Text = m_nameAndVersionInfo;
            }
        }

        #endregion

        public MainModel()
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
            nameAndVersionLabel.Text = NameAndVersionInfo;
        }

        /// <summary>
        /// Hides form to tray.
        /// </summary>
        public void Hide()
        {
            base.Hide();
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Shows application.
        /// </summary>
        public void Show()
        {
            base.Show();
            WindowState = FormWindowState.Normal;
        }



        #region Mouse Actions

        private void OKButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        #endregion
    }
}
