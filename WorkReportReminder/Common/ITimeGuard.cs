using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkReportReminder.SettingsManagement;

namespace WorkReportReminder.TimeManagement
{
    public interface ITimeGuard
    {
        event EventHandler TimeElapsed;

        /// <summary>
        /// Initialises timer values.
        /// </summary>
        void InitialiseTimer(TimeGuardConfiguration configManager);

        /// <summary>
        /// Starts timer.
        /// </summary>
        void StartTimer();

        /// <summary>
        /// Reset timer.
        /// </summary>
        void ResetTimer();

        /// <summary>
        /// Kill timer.
        /// </summary>
        void KillTimer();

        /// <summary>
        /// Postpones timer.
        /// </summary>
        void PostponeTimer();

    }
}
