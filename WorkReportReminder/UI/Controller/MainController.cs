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
    public class MainController
    {
        private MainView m_mainView;

        public MainController()
        {
            m_mainView = new MainView();
        }

        private void Initialise()
        {
            m_mainView.NameAndVersionInfo = GenerateNameAndVersionInfo();
        }

        private string GenerateNameAndVersionInfo()
        {
            string name;
            string version;

            Assembly assembly = Assembly.GetEntryAssembly();

            name = assembly.GetName().Name;
            version = assembly.GetName().Version.ToString();

            return name + " " + version;
        }

        public void ShowForm()
        {
            m_mainView.ShowModel();
        }
    }
}
