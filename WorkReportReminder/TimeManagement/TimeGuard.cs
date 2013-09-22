using System;
using System.Windows.Threading;

namespace WorkReportReminder.TimeManagement
{
    class TimeGuard : ITimeGuard
    {
        private DispatcherTimer _timer;
        private TimeSpan _normalTimerDelay;
        private TimeSpan _postponeTimerDelay;

        private void OnTimerTick(object sender, EventArgs e)
        {
            EventHandler temp = TimerRaised;
            if (temp != null)
            {
                temp(this, e);
            }
        }

        #region Implementation of ITimeGuard

        public event EventHandler TimerRaised;

        /// <summary>
        /// Initialises timer values.
        /// </summary>
        public void InitialiseTimer(TimeGuardConfiguration config)
        {
            _timer = new DispatcherTimer();
            _normalTimerDelay = config.NormalTimeInterval;
            _postponeTimerDelay = config.PostponeTimeInterval;

            _timer.Interval = _normalTimerDelay;
            _timer.Tick += OnTimerTick;
        }

        /// <summary>
        /// Starts timer.
        /// </summary>
        public void StartTimer()
        {
            _timer.Start();
        }

        /// <summary>
        /// Resets timer.
        /// </summary>
        public void ResetTimer()
        {
            _timer.Stop();
            _timer.Interval = _normalTimerDelay;
            _timer.Start();
        }

        /// <summary>
        /// Kills timer.
        /// </summary>
        public void KillTimer()
        {
            _timer.Stop();
        }

        /// <summary>
        /// Postpones timer.
        /// </summary>
        public void PostponeTimer()
        {
            _timer.Stop();
            _timer.Interval = _postponeTimerDelay;
            _timer.Start();
        }

        #endregion
    }
}
