using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using WorkReportReminder.DataManagement;
using WorkReportReminder.UI.Controller;

namespace WorkReportReminder.UI.Layout
{
    public partial class ReportSummary : Form, IReportSummaryView
    {
        private ReportSummaryController _controller;
        private const string DateFormat = "dd.MM.yy";
        private const string TimeFormat = "HH:mm";

        private void InitialiseTreeView()
        {
            treeListView.CanExpandGetter = delegate(object wi)
            {
                var workItem = (wi as WorkItem);
                return (workItem != null && workItem.Comments.Count > 0);
            };

            treeListView.ChildrenGetter = delegate(object wi)
            {
                return (wi as WorkItem).Comments;
            };
        }

        public ReportSummary(ReportSummaryController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void OnMenuOpenClick(object sender, System.EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "work report file (*.xml)|*.xml";
            var dialogResult = openFile.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                _controller.GetDataFromFile(openFile.FileName);
            }

            UpdateData();
        }

        public void UpdateData()
        {
            SortByTitle(_controller.PullData());
        }

        private void SortByTitle(WorkItemsList workItems)
        {
            Clear();
            workItems.Reverse();
            foreach (var workItem in workItems)
            {
                var treeNode = new TreeNode(string.Format("{0} [{1}]-[{2}]", workItem.Title, FormatDate(workItem.StartTime), FormatDate(workItem.EndTime)));
                foreach (var comment in workItem.Comments)
                {
                    treeNode.Nodes.Add(string.Format("[{0}] [{1}] - {2}",FormatDate(comment.Time), FormatTime(comment.Time), comment.Content));
                }

            }

            treeListView.Roots = workItems;
        }

        private void SortByDate(ReadOnlyCollection<WorkItem> workItems)
        {
            Clear();
            workItems.Reverse();
            foreach (var workItem in workItems)
            {
            }
        }

        /// <summary>
        /// Clears the view.
        /// </summary>
        public void Clear()
        {
        }

        public void Show()
        {
            base.Show();
        }

        private string FormatDate(DateTime date)
        {
            return date.ToString(DateFormat);
        }

        private string FormatTime(DateTime time)
        {
            return time.ToString(TimeFormat);
        }
    }
}
