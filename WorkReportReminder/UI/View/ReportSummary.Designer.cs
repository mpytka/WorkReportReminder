using System.Collections.Generic;
using WorkReportReminder.DataManagement;

namespace WorkReportReminder.UI.Layout
{
    partial class ReportSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeListView = new BrightIdeasSoftware.TreeListView();
            this.titleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.startDateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.endDateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 251);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(292, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.sortToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(292, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.openToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.OnMenuOpenClick);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateToolStripMenuItem,
            this.idToolStripMenuItem,
            this.titleToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.dateToolStripMenuItem.Text = "Date";
            // 
            // idToolStripMenuItem
            // 
            this.idToolStripMenuItem.Name = "idToolStripMenuItem";
            this.idToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.idToolStripMenuItem.Text = "Id";
            // 
            // titleToolStripMenuItem
            // 
            this.titleToolStripMenuItem.Name = "titleToolStripMenuItem";
            this.titleToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.titleToolStripMenuItem.Text = "Title";
            // 
            // treeListView
            // 
            this.treeListView.AllColumns.Add(this.titleColumn);
            this.treeListView.AllColumns.Add(this.startDateColumn);
            this.treeListView.AllColumns.Add(this.endDateColumn);
            this.treeListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColumn,
            this.startDateColumn,
            this.endDateColumn});
            this.treeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView.Location = new System.Drawing.Point(0, 24);
            this.treeListView.Name = "treeListView";
            this.treeListView.OwnerDraw = true;
            this.treeListView.ShowGroups = false;
            this.treeListView.Size = new System.Drawing.Size(292, 227);
            this.treeListView.TabIndex = 3;
            this.treeListView.UseCompatibleStateImageBehavior = false;
            this.treeListView.View = System.Windows.Forms.View.Details;
            this.treeListView.VirtualMode = true;
            // 
            // titleColumn
            // 
            this.titleColumn.AspectName = "Title";
            this.titleColumn.Text = "Title";
            // 
            // startDateColumn
            // 
            this.startDateColumn.AspectName = "StartTime";
            this.startDateColumn.Text = "Start Date";
            // 
            // endDateColumn
            // 
            this.endDateColumn.AspectName = "EndTime";
            this.endDateColumn.Text = "End Date";
            // 
            // ReportSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.treeListView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ReportSummary";
            this.Text = "ReportSummary";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private BrightIdeasSoftware.TreeListView treeListView;
        private BrightIdeasSoftware.OLVColumn titleColumn;
        private BrightIdeasSoftware.OLVColumn startDateColumn;
        private BrightIdeasSoftware.OLVColumn endDateColumn;
    }
}