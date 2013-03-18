using System;
using System.Text.RegularExpressions;

using WorkReportReminder.UI;
using WorkReportReminder.DataManagement;

namespace WorkReportReminder.UI.View.SummaryHelpers
{
    /// <summary>
    /// Helper class used to define behaviour of treeView.
    /// </summary>
    internal class TreeViewHelper
    {
        private ReportSummary _view;
        private DurationCalculator _durationCalculator;

        public TreeViewHelper(ReportSummary view, DurationCalculator calc)
        {
            _view = view;
            _durationCalculator = calc;
        }

        /// <summary>
        /// Initialises view.
        /// Defines how detect if item has children, and what to return.
        /// </summary>
        public void InitialiseView()
        {
            _view.TreeListView.CanExpandGetter =
                (obj) =>
                {
                    var workItem = (obj as WorkItem);
                    return (workItem != null && workItem.Comments.Count > 0);
                };

            _view.TreeListView.ChildrenGetter =
                (obj) =>
                {
                    return (obj as WorkItem).Comments;
                };
        }

        /// <summary>
        /// Defines displayed date format.
        /// Format is common for all columns containing DateTime value.
        /// </summary>
        public void InitialiseDateFormat(string dateFormat)
        {
            _view.StartDateColumn.AspectGetter =
                (obj) =>
                {
                    if (obj is WorkItem)
                    {
                        return (obj as WorkItem).StartTime.ToString(dateFormat);
                    }
                    if (obj is WorkItemComment)
                    {
                        return (obj as WorkItemComment).Time.ToString(dateFormat);
                    }

                    return string.Empty;
                };

            _view.EndDateColumn.AspectGetter =
                (obj) =>
                {
                    var workItem = (obj as WorkItem);
                    if (workItem != null)
                    {
                        return workItem.EndTime.ToString(dateFormat);
                    }

                    return string.Empty;
                };

        }

        /// <summary>
        /// Defines how to display duration.
        /// It can be configure to display hours, days etc. depending on durationFOrmat.
        /// </summary>
        public void InitialiseDurationFormat(DurationFormatTypes durationFormat)
        {
            _view.DurationColumn.AspectGetter =
                (obj) =>
                {
                    var workItem = (obj as WorkItem);
                    if (workItem != null)
                    {
                        return _durationCalculator.Calculate(workItem.StartTime, workItem.EndTime, durationFormat);
                    }
                    return string.Empty;
                };
        }

        /// <summary>
        /// Defines what should be displayed in Tag column.
        /// </summary>
        public void InitialiseTagColumn(char tagSign)
        {
            _view.TagColumn.AspectGetter =
                (obj) =>
                {
                    var workItem = (obj as WorkItem);
                    if (workItem != null)
                    {
                        //we simplify that tags should not be separated, just one by another (without spaces etc.).
                        var result = Regex.Match(workItem.Title, @"(\[[^]]*\])*");
                        return result.Groups[0].Value;
                    }

                    return string.Empty;
                };
        }

        /// <summary>
        /// Defines what should be displayed as ID.
        /// </summary>
        public void InitialiseIdColumn()
        {
            _view.IdColumn.AspectGetter =
                (obj) =>
                {
                    var workItem = (obj as WorkItem);
                    if (workItem != null)
                    {
                        return workItem.Id;
                    }

                    return string.Empty;
                };
        }
    }
}
