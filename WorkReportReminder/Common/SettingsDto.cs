using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkReportReminder.SettingsManagement
{
    public class SettingsDto
    {
        /// <summary>
        /// Shift start time.
        /// </summary>
        public DateTime StartShift { get; private set; }

        /// <summary>
        /// Shift end time.
        /// </summary>
        public DateTime EndShift { get; private set; }

        /// <summary>
        /// Interval used to show report reminder view.
        /// </summary>
        public TimeSpan ReportReminderInterval { get; private set; }

        /// <summary>
        /// Interval used to show postponed report reminder view. 
        /// </summary>
        public TimeSpan PostponeReportReminderInterval { get; private set; }
    }
}
