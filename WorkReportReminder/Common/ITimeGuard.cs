using System;
using WorkReportReminder.TimeManagement;

namespace WorkReportReminder.Common
{
    public interface ITimeGuard
    {
        event EventHandler TimerRaised;

        /// <summary>
        /// Initialises timer values.
        /// </summary>
        void InitialiseTimer(TimeGuardConfiguration configManager);

        /// <summary>
        /// Starts timer.
        /// </summary>
        void StartTimer();

        /// <summary>
        /// Resets timer.
        /// </summary>
        void ResetTimer();

        /// <summary>
        /// Kills timer.
        /// </summary>
        void KillTimer();

        /// <summary>
        /// Postpones timer.
        /// </summary>
        void PostponeTimer();

    }
}
