using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkReportReminder.TimeManagement
{
    interface ITimeManager
    {
        event EventHandler TimeElapsed;

        /// <summary>
        /// Initialises timer values.
        /// </summary>
        void InitialiseTimer();

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
