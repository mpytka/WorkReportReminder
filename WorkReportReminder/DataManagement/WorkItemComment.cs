using System;

namespace WorkReportReminder.DataManagement
{
    /// <summary>
    /// Represents comment added to work item.
    /// </summary>
    public class WorkItemComment : IComparable
    {
        private const int DIFFERENT_VALUE = 1;
        private const int THE_SAME_VALUE = 0;

        private readonly char[] CHARS_TO_TRIM_FROM_START = new char[] {'\r', '\n', ' '};
        private readonly char[] CHARS_TO_TRIM_FROM_END = new char[] {'\r', '\n', ' '};

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string Title { get; private set; }

        public WorkItemComment(string content, DateTime startTime):this(content, startTime, startTime)
        {
        }

        public WorkItemComment(string content, DateTime startTime, DateTime endTime)
        {
            Title = Trim(content);
            StartTime = startTime;
            EndTime = endTime;
        }

        public void SetEndTime(DateTime endTime)
        {
            EndTime = endTime;
        }

        /// <summary>
        /// Removes unvanted chars from the start and end of passed string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string Trim(string value)
        {
            return value.TrimStart(CHARS_TO_TRIM_FROM_START).TrimEnd(CHARS_TO_TRIM_FROM_END);
        }

        #region Comparable

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance is the same or different.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Zero This instance is equal to <paramref name="obj"/>. Greater than zero This instance is greater than <paramref name="obj"/>. 
        /// </returns>
        /// <param name="obj">An object to compare with this instance. </param><exception cref="T:System.ArgumentException"><paramref name="obj"/> is not the same type as this instance. </exception><filterpriority>2</filterpriority>
        public int CompareTo(object obj)
        {
            if(obj is string)
            {
                return CompareToString(obj as string);
            }
            if(obj is WorkItemComment)
            {
                return CompareToWorkItemComment(obj as WorkItemComment);
            }

            return DIFFERENT_VALUE;
        }

        /// <summary>
        /// Compare this instance with other instance.
        /// </summary>
        private int CompareToWorkItemComment(WorkItemComment instanceToCompare)
        {
            if (instanceToCompare.Title.CompareTo(Title) == 0 && 
                instanceToCompare.StartTime == StartTime &&
                instanceToCompare.EndTime == EndTime)
            {
                return THE_SAME_VALUE;
            }

            return DIFFERENT_VALUE;
        }

        /// <summary>
        /// Compare this instance with string.
        /// </summary>
        private int CompareToString(string value)
        {
            var valueToCompare = Trim(value);

            if(valueToCompare.CompareTo(valueToCompare) == 0)
            {
                return THE_SAME_VALUE;
            }

            return DIFFERENT_VALUE;
        }

        #endregion
    }
}