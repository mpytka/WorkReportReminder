using System;

namespace WorkReportReminder.SettingsManagement
{
    /// <summary>
    /// Class used to initialise time manager values.
    /// </summary>
    public class TimeGuardConfiguration
    {
        public TimeGuardConfiguration(TimeSpan normal, TimeSpan postpone)
        {
            NormalTimeInterval = normal;
            PostponeTimeInterval = postpone;
        }

        /// <summary>
        /// Time interval used to show main form after postpone.
        /// </summary>
        public TimeSpan PostponeTimeInterval { get; private set; }

        /// <summary>
        /// Default time interval used to show main form.
        /// </summary>
        public TimeSpan NormalTimeInterval { get; private set; }
    }
}
