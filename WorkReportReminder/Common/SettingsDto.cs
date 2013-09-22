using System;

namespace WorkReportReminder.Common
{
    public class SettingsDto 
    {
        public SettingsDto(DateTime startShift, DateTime endShift, TimeSpan reminderInterval, TimeSpan postponeReminderInterval)
        {
            StartShift = startShift;
            EndShift = endShift;
            ReportReminderInterval = reminderInterval;
            PostponeReportReminderInterval = postponeReminderInterval;
        }
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
