// -----------------------------------------------------------------------
// <copyright file="ApplicationCore.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Forms;
using WorkReportReminder.UI;

namespace WorkReportReminder.Core
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ApplicationCore : ApplicationContext
    {
        private UICore m_uiCore;

        public ApplicationCore()
        {
            m_uiCore = new UICore();
        }
    }
}
