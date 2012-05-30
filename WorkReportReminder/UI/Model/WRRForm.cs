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
            Initialise();
        }

        /// <summary>
        /// Initialises main form.
        /// </summary>
        private void Initialise()
        {
            Hide();
            nameAndVersionLabel.Text = GenerateNameAndVersionInfo();
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
        public new virtual void Show()
        {
            base.Show();
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
            Hide();
        }



        #endregion
    }
}
