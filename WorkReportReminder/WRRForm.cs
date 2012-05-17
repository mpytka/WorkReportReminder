using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WorkReportReminder
{
    public partial class WRRForm : Form
    {

        public WRRForm()
        {
            InitializeComponent();
            InitialiseMainForm();
        }

        /// <summary>
        /// Initialises main form.
        /// </summary>
        private void InitialiseMainForm()
        {
            HideMainForm();
            nameAndVersionLabel.Text = GenerateNameAndVersionInfo();
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

        /// <summary>
        /// TODO: move to controller.
        /// </summary>
        /// <returns></returns>
        private string GenerateNameAndVersionInfo()
        {
            string name;
            string version;

            Assembly assembly = Assembly.GetEntryAssembly();

            name = assembly.GetName().Name;
            version = assembly.GetName().Version.ToString();

            return name+" "+version;
        }

        #region Mouse Actions

        private void OKButton_Click(object sender, EventArgs e)
        {
            HideMainForm();
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

        #endregion
    }
}
