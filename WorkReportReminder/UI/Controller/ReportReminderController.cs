// -----------------------------------------------------------------------
// <copyright file="MainController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WorkReportReminder
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ReportReminderController
    {
        private ReportReminderForm m_view;

        #region Events


        #endregion

        public ReportReminderController()
        {
            m_view = new ReportReminderForm();
        }

        private void Initialise()
        {
            m_view.SetNameAndVersionInfo = NameAndVersionInfo();
        }

        /// <summary>
        /// Returns name and version information.
        /// </summary>
        /// <returns></returns>
        private string NameAndVersionInfo()
        {
            string name;
            string version;

            Assembly assembly = Assembly.GetEntryAssembly();

            name = assembly.GetName().Name;
            version = assembly.GetName().Version.ToString();

            return name + " " + version;
        }

        /// <summary>
        /// Shows form.
        /// </summary>
        public void Show()
        {
            m_view.Show();
        }
    }
}
