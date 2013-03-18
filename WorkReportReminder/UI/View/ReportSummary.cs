using System.Linq;
using System.Windows.Forms;
using WorkReportReminder.DataManagement;
using WorkReportReminder.UI.Controller;
using System.Collections.Generic;
using WorkReportReminder.UI.View.SummaryHelpers;

namespace WorkReportReminder.UI
{
    public partial class ReportSummary : Form, IReportSummaryView
    {
        private const int WORKDAY_LENGTH = 8;
        private const string DATE_FORMAT = "dd - MM - yyyy";
        private const string TIME_FORMAT = "HH:mm";
        private const DurationFormatTypes DURATION_TYPE = DurationFormatTypes.Days;
        private const string FILE_FILTER = "work report file (*.xml)|*.xml";

        private ReportSummaryController _controller;

        public ReportSummary(ReportSummaryController controller)
        {
            InitializeComponent();
            _controller = controller;
            
            InitialiseTreeView();
        }

        /// <summary>
        /// Initialises tree view control.
        /// </summary>
        private void InitialiseTreeView()
        {
            var treeVeiwHelper = new TreeViewHelper(this, new DurationCalculator(WORKDAY_LENGTH));
            treeVeiwHelper.InitialiseView();
            treeVeiwHelper.InitialiseDurationFormat(DURATION_TYPE);
            treeVeiwHelper.InitialiseDateFormat(DATE_FORMAT);
            treeVeiwHelper.InitialiseTagColumn();
            treeVeiwHelper.InitialiseIdColumn();
        }

        private void OnMenuOpenClick(object sender, System.EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = FILE_FILTER;
            var dialogResult = openFile.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                _controller.GetDataFromFile(openFile.FileName);
            }

            UpdateData();
        }

        public void UpdateData()
        {
            TreeListView.Roots = _controller.PullData();
        }

        /// <summary>
        /// Clears the view.
        /// </summary>
        public void Clear()
        {
            TreeListView.Clear();
        }

        public void Show()
        {
            base.Show();
        }
    }
}
