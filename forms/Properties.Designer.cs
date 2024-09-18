namespace TaskTracker.forms
{
    partial class PropertiesWindow
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DatabaseOptions = new System.Windows.Forms.TabPage();
            this.dbDetailsSave = new System.Windows.Forms.Button();
            this.dbNameLabel = new System.Windows.Forms.Label();
            this.dbName = new System.Windows.Forms.TextBox();
            this.dbConnect = new System.Windows.Forms.Button();
            this.testDBConn = new System.Windows.Forms.Button();
            this.dbPassword = new System.Windows.Forms.TextBox();
            this.dbUser = new System.Windows.Forms.TextBox();
            this.dbPort = new System.Windows.Forms.TextBox();
            this.dbPortLabel = new System.Windows.Forms.Label();
            this.dbPasswordLabel = new System.Windows.Forms.Label();
            this.dbUserLabel = new System.Windows.Forms.Label();
            this.dbAddressLabel = new System.Windows.Forms.Label();
            this.dbAddress = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.DatabaseOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.DatabaseOptions);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(767, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // DatabaseOptions
            // 
            this.DatabaseOptions.Controls.Add(this.dbDetailsSave);
            this.DatabaseOptions.Controls.Add(this.dbNameLabel);
            this.DatabaseOptions.Controls.Add(this.dbName);
            this.DatabaseOptions.Controls.Add(this.dbConnect);
            this.DatabaseOptions.Controls.Add(this.testDBConn);
            this.DatabaseOptions.Controls.Add(this.dbPassword);
            this.DatabaseOptions.Controls.Add(this.dbUser);
            this.DatabaseOptions.Controls.Add(this.dbPort);
            this.DatabaseOptions.Controls.Add(this.dbPortLabel);
            this.DatabaseOptions.Controls.Add(this.dbPasswordLabel);
            this.DatabaseOptions.Controls.Add(this.dbUserLabel);
            this.DatabaseOptions.Controls.Add(this.dbAddressLabel);
            this.DatabaseOptions.Controls.Add(this.dbAddress);
            this.DatabaseOptions.Location = new System.Drawing.Point(4, 28);
            this.DatabaseOptions.Name = "DatabaseOptions";
            this.DatabaseOptions.Padding = new System.Windows.Forms.Padding(3);
            this.DatabaseOptions.Size = new System.Drawing.Size(759, 394);
            this.DatabaseOptions.TabIndex = 0;
            this.DatabaseOptions.Text = "Database Options";
            this.DatabaseOptions.UseVisualStyleBackColor = true;
            // 
            // dbDetailsSave
            // 
            this.dbDetailsSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dbDetailsSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dbDetailsSave.Location = new System.Drawing.Point(237, 208);
            this.dbDetailsSave.Name = "dbDetailsSave";
            this.dbDetailsSave.Size = new System.Drawing.Size(153, 29);
            this.dbDetailsSave.TabIndex = 5;
            this.dbDetailsSave.Text = "Save";
            this.dbDetailsSave.UseVisualStyleBackColor = false;
            this.dbDetailsSave.Click += new System.EventHandler(this.dbDetailsSave_Click);
            // 
            // dbNameLabel
            // 
            this.dbNameLabel.AutoSize = true;
            this.dbNameLabel.Location = new System.Drawing.Point(142, 78);
            this.dbNameLabel.Name = "dbNameLabel";
            this.dbNameLabel.Size = new System.Drawing.Size(66, 16);
            this.dbNameLabel.TabIndex = 13;
            this.dbNameLabel.Text = "DB Name";
            // 
            // dbName
            // 
            this.dbName.Location = new System.Drawing.Point(237, 71);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(270, 22);
            this.dbName.TabIndex = 1;
            // 
            // dbConnect
            // 
            this.dbConnect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dbConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dbConnect.Location = new System.Drawing.Point(354, 256);
            this.dbConnect.Name = "dbConnect";
            this.dbConnect.Size = new System.Drawing.Size(153, 29);
            this.dbConnect.TabIndex = 7;
            this.dbConnect.Text = "Connect";
            this.dbConnect.UseVisualStyleBackColor = false;
            this.dbConnect.Click += new System.EventHandler(this.dbConnect_Click);
            // 
            // testDBConn
            // 
            this.testDBConn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.testDBConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.testDBConn.Location = new System.Drawing.Point(122, 256);
            this.testDBConn.Name = "testDBConn";
            this.testDBConn.Size = new System.Drawing.Size(153, 29);
            this.testDBConn.TabIndex = 6;
            this.testDBConn.Text = "Test Connection";
            this.testDBConn.UseVisualStyleBackColor = false;
            this.testDBConn.Click += new System.EventHandler(this.testDBConn_Click);
            // 
            // dbPassword
            // 
            this.dbPassword.Location = new System.Drawing.Point(237, 166);
            this.dbPassword.Name = "dbPassword";
            this.dbPassword.PasswordChar = '*';
            this.dbPassword.ShortcutsEnabled = false;
            this.dbPassword.Size = new System.Drawing.Size(270, 22);
            this.dbPassword.TabIndex = 4;
            // 
            // dbUser
            // 
            this.dbUser.Location = new System.Drawing.Point(237, 134);
            this.dbUser.Name = "dbUser";
            this.dbUser.Size = new System.Drawing.Size(270, 22);
            this.dbUser.TabIndex = 3;
            // 
            // dbPort
            // 
            this.dbPort.Location = new System.Drawing.Point(237, 102);
            this.dbPort.Name = "dbPort";
            this.dbPort.Size = new System.Drawing.Size(270, 22);
            this.dbPort.TabIndex = 2;
            // 
            // dbPortLabel
            // 
            this.dbPortLabel.AutoSize = true;
            this.dbPortLabel.Location = new System.Drawing.Point(155, 109);
            this.dbPortLabel.Name = "dbPortLabel";
            this.dbPortLabel.Size = new System.Drawing.Size(53, 16);
            this.dbPortLabel.TabIndex = 4;
            this.dbPortLabel.Text = "DB Port";
            // 
            // dbPasswordLabel
            // 
            this.dbPasswordLabel.AutoSize = true;
            this.dbPasswordLabel.Location = new System.Drawing.Point(119, 172);
            this.dbPasswordLabel.Name = "dbPasswordLabel";
            this.dbPasswordLabel.Size = new System.Drawing.Size(89, 16);
            this.dbPasswordLabel.TabIndex = 3;
            this.dbPasswordLabel.Text = "DB Password";
            // 
            // dbUserLabel
            // 
            this.dbUserLabel.AutoSize = true;
            this.dbUserLabel.Location = new System.Drawing.Point(150, 140);
            this.dbUserLabel.Name = "dbUserLabel";
            this.dbUserLabel.Size = new System.Drawing.Size(58, 16);
            this.dbUserLabel.TabIndex = 2;
            this.dbUserLabel.Text = "DB User";
            // 
            // dbAddressLabel
            // 
            this.dbAddressLabel.AutoSize = true;
            this.dbAddressLabel.Location = new System.Drawing.Point(87, 46);
            this.dbAddressLabel.Name = "dbAddressLabel";
            this.dbAddressLabel.Size = new System.Drawing.Size(121, 16);
            this.dbAddressLabel.TabIndex = 1;
            this.dbAddressLabel.Text = "Database Address";
            // 
            // dbAddress
            // 
            this.dbAddress.Location = new System.Drawing.Point(237, 43);
            this.dbAddress.Name = "dbAddress";
            this.dbAddress.Size = new System.Drawing.Size(270, 22);
            this.dbAddress.TabIndex = 0;
            // 
            // PropertiesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "PropertiesWindow";
            this.Text = "PropertiesWindow";
            this.tabControl1.ResumeLayout(false);
            this.DatabaseOptions.ResumeLayout(false);
            this.DatabaseOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage DatabaseOptions;
        private System.Windows.Forms.TextBox dbAddress;
        private System.Windows.Forms.Label dbPortLabel;
        private System.Windows.Forms.Label dbPasswordLabel;
        private System.Windows.Forms.Label dbUserLabel;
        private System.Windows.Forms.Label dbAddressLabel;
        private System.Windows.Forms.TextBox dbPassword;
        private System.Windows.Forms.TextBox dbUser;
        private System.Windows.Forms.TextBox dbPort;
        private System.Windows.Forms.Button dbConnect;
        private System.Windows.Forms.Button testDBConn;
        private System.Windows.Forms.Button dbDetailsSave;
        private System.Windows.Forms.Label dbNameLabel;
        private System.Windows.Forms.TextBox dbName;
    }
}