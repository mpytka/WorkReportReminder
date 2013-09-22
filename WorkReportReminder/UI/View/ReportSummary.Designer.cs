namespace WorkReportReminder.UI
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
            this.TreeListView = new BrightIdeasSoftware.TreeListView();
            this.titleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DurationColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.StartDateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.EndDateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TagColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.IdColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListView)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 222);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(686, 22);
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
            this.menuStrip.Size = new System.Drawing.Size(686, 24);
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
            // TreeListView
            // 
            this.TreeListView.AllColumns.Add(this.titleColumn);
            this.TreeListView.AllColumns.Add(this.DurationColumn);
            this.TreeListView.AllColumns.Add(this.StartDateColumn);
            this.TreeListView.AllColumns.Add(this.EndDateColumn);
            this.TreeListView.AllColumns.Add(this.TagColumn);
            this.TreeListView.AllColumns.Add(this.IdColumn);
            this.TreeListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColumn,
            this.DurationColumn,
            this.StartDateColumn,
            this.EndDateColumn,
            this.TagColumn,
            this.IdColumn});
            this.TreeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TreeListView.HeaderWordWrap = true;
            this.TreeListView.Location = new System.Drawing.Point(0, 24);
            this.TreeListView.Name = "TreeListView";
            this.TreeListView.OwnerDraw = true;
            this.TreeListView.ShowGroups = false;
            this.TreeListView.Size = new System.Drawing.Size(686, 198);
            this.TreeListView.TabIndex = 3;
            this.TreeListView.UseAlternatingBackColors = true;
            this.TreeListView.UseCompatibleStateImageBehavior = false;
            this.TreeListView.View = System.Windows.Forms.View.Details;
            this.TreeListView.VirtualMode = true;
            // 
            // titleColumn
            // 
            this.titleColumn.AspectName = "Title";
            this.titleColumn.DisplayIndex = 1;
            this.titleColumn.Text = "Title";
            this.titleColumn.Width = 300;
            // 
            // DurationColumn
            // 
            this.DurationColumn.AspectName = "";
            this.DurationColumn.DisplayIndex = 2;
            this.DurationColumn.Text = "Duration";
            this.DurationColumn.Width = 40;
            // 
            // StartDateColumn
            // 
            this.StartDateColumn.AspectName = "StartTime";
            this.StartDateColumn.DisplayIndex = 3;
            this.StartDateColumn.Text = "Start Date";
            this.StartDateColumn.Width = 100;
            // 
            // EndDateColumn
            // 
            this.EndDateColumn.AspectName = "EndTime";
            this.EndDateColumn.DisplayIndex = 4;
            this.EndDateColumn.Text = "End Date";
            this.EndDateColumn.Width = 100;
            // 
            // TagColumn
            // 
            this.TagColumn.DisplayIndex = 0;
            this.TagColumn.Text = "Tag";
            // 
            // IdColumn
            // 
            this.IdColumn.Text = "ID";
            // 
            // ReportSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(686, 244);
            this.Controls.Add(this.TreeListView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ReportSummary";
            this.Text = "ReportSummary";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListView)).EndInit();
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
        public BrightIdeasSoftware.TreeListView TreeListView;
        private BrightIdeasSoftware.OLVColumn titleColumn;
        public BrightIdeasSoftware.OLVColumn StartDateColumn;
        public BrightIdeasSoftware.OLVColumn EndDateColumn;
        public BrightIdeasSoftware.OLVColumn DurationColumn;
        public BrightIdeasSoftware.OLVColumn TagColumn;
        public BrightIdeasSoftware.OLVColumn IdColumn;
    }
}