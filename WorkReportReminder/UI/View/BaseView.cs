// -----------------------------------------------------------------------
// <copyright file="BaseView.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkReportReminder
{
    

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class BaseView
    {
        private Form m_model;

        public BaseView(Form model)
        {
            m_model = model;
        }

        public void ShowModel()
        {
            m_model.Show();
        }

    }
}
