using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkReportReminder.UI.Controls
{
    public class DataGridViewTreeViewColumn : DataGridViewTextBoxColumn
    {
        private TreeView treeView;

        public DataGridViewTreeViewColumn()
        {
            InitialiseItems();
            treeView.Nodes.Add("one");
            treeView.Nodes.Add("one");
            treeView.Nodes.Add("one");
            treeView.Nodes[0].Nodes.Add("one one");
            treeView.Nodes[0].Nodes.Add("one one");
            treeView.Nodes[0].Nodes.Add("one one");
        }

        private void InitialiseItems()
        {
            treeView = new TreeView();
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(160, 301);
            this.treeView.TabIndex = 1;
        }
    }
}
