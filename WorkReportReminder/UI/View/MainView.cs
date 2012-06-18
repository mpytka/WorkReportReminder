// -----------------------------------------------------------------------
// <copyright file="MainView.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkReportReminder
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MainView
    {
        private MainModel m_mainModel;

        public MainView()
        {
            m_mainModel = new MainModel();
        }

        #region Properties

        public string NameAndVersionInfo
        {
            get { return m_mainModel.NameAndVersionInfo; }
            set { m_mainModel.NameAndVersionInfo = value; }
        }


        #endregion

        public void  ShowModel()
        {
            m_mainModel.Show();
        }
    }
}
