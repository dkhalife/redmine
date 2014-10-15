namespace WorkTimer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mProjects = new System.Windows.Forms.ToolStripMenuItem();
            this.mProjectsByName = new System.Windows.Forms.ToolStripMenuItem();
            this.mIssues = new System.Windows.Forms.ToolStripMenuItem();
            this.mIssuesById = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.restart = new System.Windows.Forms.PictureBox();
            this.stop = new System.Windows.Forms.PictureBox();
            this.pause = new System.Windows.Forms.PictureBox();
            this.start = new System.Windows.Forms.PictureBox();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIssueTitle = new System.Windows.Forms.Label();
            this.lblIssueNumber = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.restart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFile,
            this.mProjects,
            this.mIssues});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(596, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mFile
            // 
            this.mFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSettings,
            this.mHelp,
            this.mAbout,
            this.mClose});
            this.mFile.Name = "mFile";
            this.mFile.ShortcutKeyDisplayString = "";
            this.mFile.Size = new System.Drawing.Size(37, 20);
            this.mFile.Text = "&File";
            // 
            // mSettings
            // 
            this.mSettings.Name = "mSettings";
            this.mSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mSettings.Size = new System.Drawing.Size(156, 22);
            this.mSettings.Text = "&Settings";
            this.mSettings.Click += new System.EventHandler(this.mSettings_Click);
            // 
            // mHelp
            // 
            this.mHelp.Name = "mHelp";
            this.mHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mHelp.Size = new System.Drawing.Size(156, 22);
            this.mHelp.Text = "&Help";
            this.mHelp.Click += new System.EventHandler(this.mHelp_Click);
            // 
            // mAbout
            // 
            this.mAbout.Name = "mAbout";
            this.mAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mAbout.Size = new System.Drawing.Size(156, 22);
            this.mAbout.Text = "&About";
            this.mAbout.Click += new System.EventHandler(this.mAbout_Click);
            // 
            // mClose
            // 
            this.mClose.Name = "mClose";
            this.mClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mClose.Size = new System.Drawing.Size(156, 22);
            this.mClose.Text = "&Close";
            this.mClose.Click += new System.EventHandler(this.mClose_Click);
            // 
            // mProjects
            // 
            this.mProjects.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mProjectsByName});
            this.mProjects.Enabled = false;
            this.mProjects.Name = "mProjects";
            this.mProjects.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mProjects.Size = new System.Drawing.Size(61, 20);
            this.mProjects.Text = "&Projects";
            // 
            // mProjectsByName
            // 
            this.mProjectsByName.Name = "mProjectsByName";
            this.mProjectsByName.Size = new System.Drawing.Size(160, 22);
            this.mProjectsByName.Text = "Search By &Name";
            this.mProjectsByName.Click += new System.EventHandler(this.mProjectsByName_Click);
            // 
            // mIssues
            // 
            this.mIssues.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mIssuesById});
            this.mIssues.Enabled = false;
            this.mIssues.Name = "mIssues";
            this.mIssues.Size = new System.Drawing.Size(50, 20);
            this.mIssues.Text = "Iss&ues";
            // 
            // mIssuesById
            // 
            this.mIssuesById.Name = "mIssuesById";
            this.mIssuesById.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mIssuesById.Size = new System.Drawing.Size(176, 22);
            this.mIssuesById.Text = "Search By &ID";
            this.mIssuesById.Click += new System.EventHandler(this.mIssuesById_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.restart);
            this.groupBox1.Controls.Add(this.stop);
            this.groupBox1.Controls.Add(this.pause);
            this.groupBox1.Controls.Add(this.start);
            this.groupBox1.Controls.Add(this.lblElapsedTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 87);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timer";
            // 
            // restart
            // 
            this.restart.Enabled = false;
            this.restart.Image = ((System.Drawing.Image)(resources.GetObject("restart.Image")));
            this.restart.Location = new System.Drawing.Point(106, 49);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(26, 25);
            this.restart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.restart.TabIndex = 2;
            this.restart.TabStop = false;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // stop
            // 
            this.stop.Enabled = false;
            this.stop.Image = global::WorkTimer.Properties.Resources.stop;
            this.stop.Location = new System.Drawing.Point(74, 49);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(26, 25);
            this.stop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stop.TabIndex = 2;
            this.stop.TabStop = false;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // pause
            // 
            this.pause.Enabled = false;
            this.pause.Image = global::WorkTimer.Properties.Resources.pause;
            this.pause.Location = new System.Drawing.Point(42, 49);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(26, 25);
            this.pause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pause.TabIndex = 2;
            this.pause.TabStop = false;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // start
            // 
            this.start.Image = global::WorkTimer.Properties.Resources.play;
            this.start.Location = new System.Drawing.Point(10, 49);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(26, 25);
            this.start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.start.TabIndex = 2;
            this.start.TabStop = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsedTime.Location = new System.Drawing.Point(88, 20);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(49, 13);
            this.lblElapsedTime.TabIndex = 1;
            this.lblElapsedTime.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elapsed Time:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblIssueTitle);
            this.groupBox2.Controls.Add(this.lblIssueNumber);
            this.groupBox2.Controls.Add(this.lblProject);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(171, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 87);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Tracking";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Issue Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Issue Title:";
            // 
            // lblIssueTitle
            // 
            this.lblIssueTitle.AutoSize = true;
            this.lblIssueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueTitle.Location = new System.Drawing.Point(70, 63);
            this.lblIssueTitle.Name = "lblIssueTitle";
            this.lblIssueTitle.Size = new System.Drawing.Size(66, 13);
            this.lblIssueTitle.TabIndex = 0;
            this.lblIssueTitle.Text = "No selection";
            // 
            // lblIssueNumber
            // 
            this.lblIssueNumber.AutoSize = true;
            this.lblIssueNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueNumber.Location = new System.Drawing.Point(87, 42);
            this.lblIssueNumber.Name = "lblIssueNumber";
            this.lblIssueNumber.Size = new System.Drawing.Size(66, 13);
            this.lblIssueNumber.TabIndex = 0;
            this.lblIssueNumber.Text = "No selection";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(55, 20);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(66, 13);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "No selection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Project:";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 129);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Redmine Work Timer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.restart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mFile;
        private System.Windows.Forms.ToolStripMenuItem mSettings;
        private System.Windows.Forms.ToolStripMenuItem mProjects;
        private System.Windows.Forms.ToolStripMenuItem mProjectsByName;
        private System.Windows.Forms.ToolStripMenuItem mIssues;
        private System.Windows.Forms.ToolStripMenuItem mIssuesById;
        private System.Windows.Forms.ToolStripMenuItem mAbout;
        private System.Windows.Forms.ToolStripMenuItem mClose;
        private System.Windows.Forms.ToolStripMenuItem mHelp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox stop;
        private System.Windows.Forms.PictureBox pause;
        private System.Windows.Forms.PictureBox start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIssueTitle;
        private System.Windows.Forms.Label lblIssueNumber;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox restart;
    }
}

