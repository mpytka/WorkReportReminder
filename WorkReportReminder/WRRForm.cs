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
    public partial class WRRForm : Form
    {
        public WRRForm()
        {
            InitializeComponent();
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

        /// <summary>
        /// Initialises main form.
        /// </summary>
        private void InitialiseMainForm()
        {
            HideMainForm();
        }

        /// <summary>
        /// Hides application to tray.
        /// </summary>
        private void HideMainForm()
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Shows application.
        /// </summary>
        private void ShowMainForm()
        {
            WindowState = FormWindowState.Normal;
        }
    }
}
