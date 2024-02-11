namespace TaskTracker
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PrjSelectLabel = new System.Windows.Forms.Label();
            this.StartTimer = new System.Windows.Forms.Button();
            this.Timezones = new System.Windows.Forms.ComboBox();
            this.TimeZoneLabel = new System.Windows.Forms.Label();
            this.ProjectDropdown = new System.Windows.Forms.ComboBox();
            this.NewPrj = new System.Windows.Forms.Button();
            this.Records = new System.Windows.Forms.RichTextBox();
            this.AdditionalNotesLabel = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrowseProjectTextFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpTip = new System.Windows.Forms.HelpProvider();
            this.BrowseDirectoryTip = new System.Windows.Forms.ToolTip(this.components);
            this.TimezoneTip = new System.Windows.Forms.ToolTip(this.components);
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrjSelectLabel
            // 
            this.PrjSelectLabel.AutoSize = true;
            this.PrjSelectLabel.Location = new System.Drawing.Point(24, 59);
            this.PrjSelectLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PrjSelectLabel.Name = "PrjSelectLabel";
            this.PrjSelectLabel.Size = new System.Drawing.Size(181, 25);
            this.PrjSelectLabel.TabIndex = 1;
            this.PrjSelectLabel.Text = "Select a project file:";
            // 
            // StartTimer
            // 
            this.StartTimer.AutoSize = true;
            this.StartTimer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StartTimer.Font = new System.Drawing.Font("Impact", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTimer.Location = new System.Drawing.Point(211, 172);
            this.StartTimer.Margin = new System.Windows.Forms.Padding(4);
            this.StartTimer.Name = "StartTimer";
            this.StartTimer.Size = new System.Drawing.Size(403, 116);
            this.StartTimer.TabIndex = 2;
            this.StartTimer.UseVisualStyleBackColor = true;
            this.StartTimer.Click += new System.EventHandler(this.StartTimer_Click);
            // 
            // Timezones
            // 
            this.Timezones.FormattingEnabled = true;
            this.Timezones.Location = new System.Drawing.Point(211, 107);
            this.Timezones.Margin = new System.Windows.Forms.Padding(4);
            this.Timezones.Name = "Timezones";
            this.Timezones.Size = new System.Drawing.Size(403, 32);
            this.Timezones.TabIndex = 3;
            this.Timezones.Text = "(UTC-05:00) Eastern Time (US & Canada)";
            this.TimezoneTip.SetToolTip(this.Timezones, "This adjusts the timer to display in the local time\r\nwhen you actually started an" +
        "d ended in the text doc.");
            this.Timezones.SelectedIndexChanged += new System.EventHandler(this.TimeZoneField_SelectedIndexChanged);
            // 
            // TimeZoneLabel
            // 
            this.TimeZoneLabel.AutoSize = true;
            this.TimeZoneLabel.Location = new System.Drawing.Point(53, 113);
            this.TimeZoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeZoneLabel.Name = "TimeZoneLabel";
            this.TimeZoneLabel.Size = new System.Drawing.Size(157, 25);
            this.TimeZoneLabel.TabIndex = 4;
            this.TimeZoneLabel.Text = "Local Timezone:";
            // 
            // ProjectDropdown
            // 
            this.ProjectDropdown.FormattingEnabled = true;
            this.ProjectDropdown.Location = new System.Drawing.Point(211, 55);
            this.ProjectDropdown.Margin = new System.Windows.Forms.Padding(4);
            this.ProjectDropdown.Name = "ProjectDropdown";
            this.ProjectDropdown.Size = new System.Drawing.Size(403, 32);
            this.ProjectDropdown.TabIndex = 7;
            this.ProjectDropdown.SelectedIndexChanged += new System.EventHandler(this.ProjectDropdown_SelectedIndexChanged);
            // 
            // NewPrj
            // 
            this.NewPrj.Location = new System.Drawing.Point(627, 51);
            this.NewPrj.Margin = new System.Windows.Forms.Padding(4);
            this.NewPrj.Name = "NewPrj";
            this.NewPrj.Size = new System.Drawing.Size(106, 41);
            this.NewPrj.TabIndex = 10;
            this.NewPrj.Text = "NEW";
            this.NewPrj.UseVisualStyleBackColor = true;
            this.NewPrj.Click += new System.EventHandler(this.NewPrj_Click);
            // 
            // Records
            // 
            this.Records.Location = new System.Drawing.Point(29, 323);
            this.Records.Margin = new System.Windows.Forms.Padding(4);
            this.Records.Name = "Records";
            this.Records.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Records.Size = new System.Drawing.Size(701, 190);
            this.Records.TabIndex = 9;
            this.Records.Text = "";
            // 
            // AdditionalNotesLabel
            // 
            this.AdditionalNotesLabel.AutoSize = true;
            this.AdditionalNotesLabel.Location = new System.Drawing.Point(24, 295);
            this.AdditionalNotesLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AdditionalNotesLabel.Name = "AdditionalNotesLabel";
            this.AdditionalNotesLabel.Size = new System.Drawing.Size(63, 25);
            this.AdditionalNotesLabel.TabIndex = 11;
            this.AdditionalNotesLabel.Text = "Notes";
            this.AdditionalNotesLabel.Click += new System.EventHandler(this.AdditionalNotesLabel_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem,
            this.BrowseProjectTextFilesToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.MenuStrip.Size = new System.Drawing.Size(781, 42);
            this.MenuStrip.TabIndex = 12;
            this.MenuStrip.Text = "MenuStrip";
            this.BrowseDirectoryTip.SetToolTip(this.MenuStrip, "Browses the directory on your local machine where the projects being tracked are." +
        "\r\n\r\n\r\n");
            this.MenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.ViewSourceToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(74, 34);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ViewSourceToolStripMenuItem
            // 
            this.ViewSourceToolStripMenuItem.Name = "ViewSourceToolStripMenuItem";
            this.ViewSourceToolStripMenuItem.Size = new System.Drawing.Size(315, 40);
            this.ViewSourceToolStripMenuItem.Text = "View Source";
            this.ViewSourceToolStripMenuItem.Click += new System.EventHandler(this.ViewSourceToolStripMenuItem_Click);
            // 
            // BrowseProjectTextFilesToolStripMenuItem
            // 
            this.BrowseProjectTextFilesToolStripMenuItem.Name = "BrowseProjectTextFilesToolStripMenuItem";
            this.BrowseProjectTextFilesToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            this.BrowseProjectTextFilesToolStripMenuItem.Text = "Browse Project Files";
            this.BrowseProjectTextFilesToolStripMenuItem.Click += new System.EventHandler(this.BrowseProjectTextFilesToolStripMenuItem_Click);
            // 
            // BrowseDirectoryTip
            // 
            this.BrowseDirectoryTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.BrowseDirectoryTip.ToolTipTitle = "Click to browse the directory containing all project files.";
            // 
            // TimezoneTip
            // 
            this.TimezoneTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 548);
            this.Controls.Add(this.AdditionalNotesLabel);
            this.Controls.Add(this.NewPrj);
            this.Controls.Add(this.Records);
            this.Controls.Add(this.ProjectDropdown);
            this.Controls.Add(this.TimeZoneLabel);
            this.Controls.Add(this.Timezones);
            this.Controls.Add(this.StartTimer);
            this.Controls.Add(this.PrjSelectLabel);
            this.Controls.Add(this.MenuStrip);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Track Your Time";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label PrjSelectLabel;
        private System.Windows.Forms.Button StartTimer;
        private System.Windows.Forms.ComboBox Timezones;
        private System.Windows.Forms.Label TimeZoneLabel;
        private System.Windows.Forms.ComboBox ProjectDropdown;
        private System.Windows.Forms.Button NewPrj;
        private System.Windows.Forms.RichTextBox Records;
        private System.Windows.Forms.Label AdditionalNotesLabel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrowseProjectTextFilesToolStripMenuItem;
        private System.Windows.Forms.HelpProvider HelpTip;
        private System.Windows.Forms.ToolTip BrowseDirectoryTip;
        private System.Windows.Forms.ToolTip TimezoneTip;
    }
}

