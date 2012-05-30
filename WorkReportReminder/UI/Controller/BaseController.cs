// -----------------------------------------------------------------------
// <copyright file="BaseController.cs" company="">
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
    public class BaseController
    {
        private BaseView m_view;

        public BaseController(BaseView view)
        {
            m_view = view;
        }

        public void ShowModel()
        {
            m_view.ShowModel();
        }
    }
}
