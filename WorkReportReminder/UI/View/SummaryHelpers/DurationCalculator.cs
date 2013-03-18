using System;

namespace WorkReportReminder.UI.View.SummaryHelpers
{
    internal class DurationCalculator
    {
        private int _workdayLength;

        public DurationCalculator(int workdayLength)
        {
            _workdayLength = workdayLength;
        }

        public int Calculate(DateTime start, DateTime end, DurationFormatTypes format)
        {
            switch (format)
            {
                case DurationFormatTypes.Days:
                default:
                    //TODO: more complicated logic to calculate duration.
                    //do not calculate free days (holidays, weekends etc.);
                    var time = end - start;
                    var duration = time.Hours + (time.Days * _workdayLength);
                    if (time.Minutes > 30)
                    {
                        duration++;
                    }

                    return duration;
                    break;

                
            }
        }
    }
}
