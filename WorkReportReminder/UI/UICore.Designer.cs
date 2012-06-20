// -----------------------------------------------------------------------
// <copyright file="UICore.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using WorkReportReminder.Properties;

namespace WorkReportReminder.UI
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class UICore
    {
        private System.Windows.Forms.NotifyIcon NotificationIcon;
        private System.Windows.Forms.ContextMenuStrip IconContextMenuStrip;

        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem CloseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;

        private void InitialiseComponents()
        {
            
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseMenuItem.Text = "Close";

            this.ShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowMenuItem.Text = "Show";

            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuItem.Text = "Settings";

            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();

            this.IconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.NotificationIcon = new System.Windows.Forms.NotifyIcon();
            //
            //notofication icon
            //
            this.NotificationIcon.Icon = ( (System.Drawing.Icon)( Resources.TaskBarIcon ) );
            this.NotificationIcon.Text = "WorkReportReminder";
            this.NotificationIcon.Visible = true;
            this.NotificationIcon.ContextMenuStrip = this.IconContextMenuStrip;
            this.NotificationIcon.DoubleClick += new System.EventHandler(this.NotificationIcon_DoubleClick);
            // 
            // IconContextMenuStrip
            // 
            this.IconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                                                         {
                                                             this.ShowMenuItem,
                                                             this.SettingsMenuItem,
                                                             this.CloseMenuItem
                                                         });
            this.IconContextMenuStrip.Name = "IconContextMenuStrip";
            this.IconContextMenuStrip.Size = new System.Drawing.Size(182, 124);

            this.IconContextMenuStrip.ResumeLayout(false);
            this.IconContextMenuStrip.PerformLayout();
        }
    }
}
