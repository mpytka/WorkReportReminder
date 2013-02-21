
using System.Windows.Forms;

namespace WorkReportReminder.UI.Layout
{
    public partial class ReportSummary : Form, IReportSummaryView
    {
        public ReportSummary()
        {
            InitializeComponent();
            ShowExampleDataFill();
            base.Show();
        }

        public void ShowExampleDataFill()
        {
            treeView.Nodes.Add("first");
            treeView.Nodes[0].Nodes.Add("one");
            treeView.Nodes[0].Nodes.Add("two");
            treeView.Nodes[0].Nodes.Add("one");
            treeView.Nodes[0].Nodes.Add("three");
            treeView.Nodes[0].Nodes.Add("one");
            treeView.Nodes.Add("second");
            treeView.Nodes.Add("third");
        }
    }
}
