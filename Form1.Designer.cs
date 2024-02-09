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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PrjSelectLabel = new System.Windows.Forms.Label();
            this.StartTimer = new System.Windows.Forms.Button();
            this.Timezones = new System.Windows.Forms.ComboBox();
            this.TimeZoneLabel = new System.Windows.Forms.Label();
            this.ProjectDropdown = new System.Windows.Forms.ComboBox();
            this.NewPrj = new System.Windows.Forms.Button();
            this.Records = new System.Windows.Forms.RichTextBox();
            this.AdditionalNotesLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrjSelectLabel
            // 
            this.PrjSelectLabel.AutoSize = true;
            this.PrjSelectLabel.Location = new System.Drawing.Point(13, 27);
            this.PrjSelectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PrjSelectLabel.Name = "PrjSelectLabel";
            this.PrjSelectLabel.Size = new System.Drawing.Size(100, 13);
            this.PrjSelectLabel.TabIndex = 1;
            this.PrjSelectLabel.Text = "Select a project file:";
            // 
            // StartTimer
            // 
            this.StartTimer.AutoSize = true;
            this.StartTimer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StartTimer.Font = new System.Drawing.Font("Impact", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTimer.Location = new System.Drawing.Point(115, 93);
            this.StartTimer.Margin = new System.Windows.Forms.Padding(2);
            this.StartTimer.Name = "StartTimer";
            this.StartTimer.Size = new System.Drawing.Size(220, 63);
            this.StartTimer.TabIndex = 2;
            this.StartTimer.UseVisualStyleBackColor = true;
            this.StartTimer.Click += new System.EventHandler(this.StartTimer_Click);
            // 
            // Timezones
            // 
            this.Timezones.FormattingEnabled = true;
            this.Timezones.Location = new System.Drawing.Point(115, 58);
            this.Timezones.Margin = new System.Windows.Forms.Padding(2);
            this.Timezones.Name = "Timezones";
            this.Timezones.Size = new System.Drawing.Size(220, 21);
            this.Timezones.TabIndex = 3;
            this.Timezones.Text = "(UTC-05:00) Eastern Time (US & Canada)";
            this.Timezones.SelectedIndexChanged += new System.EventHandler(this.TimeZoneField_SelectedIndexChanged);
            // 
            // TimeZoneLabel
            // 
            this.TimeZoneLabel.AutoSize = true;
            this.TimeZoneLabel.Location = new System.Drawing.Point(29, 61);
            this.TimeZoneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeZoneLabel.Name = "TimeZoneLabel";
            this.TimeZoneLabel.Size = new System.Drawing.Size(85, 13);
            this.TimeZoneLabel.TabIndex = 4;
            this.TimeZoneLabel.Text = "Local Timezone:";
            // 
            // ProjectDropdown
            // 
            this.ProjectDropdown.FormattingEnabled = true;
            this.ProjectDropdown.Location = new System.Drawing.Point(115, 23);
            this.ProjectDropdown.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectDropdown.Name = "ProjectDropdown";
            this.ProjectDropdown.Size = new System.Drawing.Size(220, 21);
            this.ProjectDropdown.TabIndex = 7;
            this.ProjectDropdown.SelectedIndexChanged += new System.EventHandler(this.ProjectDropdown_SelectedIndexChanged);
            // 
            // NewPrj
            // 
            this.NewPrj.Location = new System.Drawing.Point(342, 22);
            this.NewPrj.Margin = new System.Windows.Forms.Padding(2);
            this.NewPrj.Name = "NewPrj";
            this.NewPrj.Size = new System.Drawing.Size(58, 22);
            this.NewPrj.TabIndex = 10;
            this.NewPrj.Text = "NEW";
            this.NewPrj.UseVisualStyleBackColor = true;
            this.NewPrj.Click += new System.EventHandler(this.NewPrj_Click);
            // 
            // Records
            // 
            this.Records.Location = new System.Drawing.Point(16, 175);
            this.Records.Margin = new System.Windows.Forms.Padding(2);
            this.Records.Name = "Records";
            this.Records.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Records.Size = new System.Drawing.Size(384, 105);
            this.Records.TabIndex = 9;
            this.Records.Text = "";
            // 
            // AdditionalNotesLabel
            // 
            this.AdditionalNotesLabel.AutoSize = true;
            this.AdditionalNotesLabel.Location = new System.Drawing.Point(13, 160);
            this.AdditionalNotesLabel.Name = "AdditionalNotesLabel";
            this.AdditionalNotesLabel.Size = new System.Drawing.Size(35, 13);
            this.AdditionalNotesLabel.TabIndex = 11;
            this.AdditionalNotesLabel.Text = "Notes";
            this.AdditionalNotesLabel.Click += new System.EventHandler(this.AdditionalNotesLabel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(426, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.viewSourceToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // viewSourceToolStripMenuItem
            // 
            this.viewSourceToolStripMenuItem.Name = "viewSourceToolStripMenuItem";
            this.viewSourceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewSourceToolStripMenuItem.Text = "View Source";
            this.viewSourceToolStripMenuItem.Click += new System.EventHandler(this.viewSourceToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 297);
            this.Controls.Add(this.AdditionalNotesLabel);
            this.Controls.Add(this.NewPrj);
            this.Controls.Add(this.Records);
            this.Controls.Add(this.ProjectDropdown);
            this.Controls.Add(this.TimeZoneLabel);
            this.Controls.Add(this.Timezones);
            this.Controls.Add(this.StartTimer);
            this.Controls.Add(this.PrjSelectLabel);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Track Yo Shtuff";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSourceToolStripMenuItem;
    }
}

