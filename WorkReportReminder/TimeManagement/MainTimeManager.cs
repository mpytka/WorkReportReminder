using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace WorkReportReminder.TimeManagement
{
    class MainTimeManager : ITimeManager
    {
        private DispatcherTimer _timer;
        private TimeSpan _normalTimerDelay;
        private TimeSpan _postponeTimerDelay;

        private void OnTimerTick(object sender, EventArgs e)
        {
            EventHandler temp = TimeElapsed;
            if (temp != null)
            {
                temp(this, e);
            }
        }

        #region Implementation of ITimeManager

        public event EventHandler TimeElapsed;

        /// <summary>
        /// Initialises timer values.
        /// </summary>
        public void InitialiseTimer()
        {
            _timer = new DispatcherTimer();
            //TODO: settings 
            _normalTimerDelay = new TimeSpan(0,0,1,0);
            _postponeTimerDelay = new TimeSpan(0,0,0,5);

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
        /// Reset timer.
        /// </summary>
        public void ResetTimer()
        {
            _timer.Stop();
            _timer.Interval = _normalTimerDelay;
            _timer.Start();
        }

        /// <summary>
        /// Kill timer.
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
