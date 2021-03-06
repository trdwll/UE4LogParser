﻿namespace UE4LogParser
{
    partial class frmMain
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
            this.logView = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuOpen = new System.Windows.Forms.MenuItem();
            this.menuExport = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuSettings = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.logView)).BeginInit();
            this.SuspendLayout();
            // 
            // logView
            // 
            this.logView.AllowDrop = true;
            this.logView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.logView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.type,
            this.message});
            this.logView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logView.Location = new System.Drawing.Point(0, 0);
            this.logView.Name = "logView";
            this.logView.RowHeadersVisible = false;
            this.logView.RowHeadersWidth = 50;
            this.logView.Size = new System.Drawing.Size(973, 520);
            this.logView.TabIndex = 0;
            this.logView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.logView_CellFormatting);
            this.logView.DragDrop += new System.Windows.Forms.DragEventHandler(this.logView_DragDrop);
            this.logView.DragEnter += new System.Windows.Forms.DragEventHandler(this.logView_DragEnter);
            // 
            // num
            // 
            this.num.HeaderText = "Num";
            this.num.Name = "num";
            this.num.Width = 54;
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.Width = 56;
            // 
            // message
            // 
            this.message.HeaderText = "Message";
            this.message.Name = "message";
            this.message.Width = 75;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuSettings,
            this.menuAbout});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOpen,
            this.menuExport,
            this.menuItem5,
            this.menuExit});
            this.menuFile.Text = "File";
            // 
            // menuOpen
            // 
            this.menuOpen.Index = 0;
            this.menuOpen.Text = "Load Log";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuExport
            // 
            this.menuExport.Enabled = false;
            this.menuExport.Index = 1;
            this.menuExport.Text = "Export Log";
            this.menuExport.Click += new System.EventHandler(this.menuExport_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 3;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuSettings
            // 
            this.menuSettings.Enabled = false;
            this.menuSettings.Index = 1;
            this.menuSettings.Text = "Settings";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 2;
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 520);
            this.Controls.Add(this.logView);
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(600, 340);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UE4LogParser";
            ((System.ComponentModel.ISupportInitialize)(this.logView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView logView;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuFile;
        private System.Windows.Forms.MenuItem menuAbout;
        private System.Windows.Forms.MenuItem menuOpen;
        private System.Windows.Forms.MenuItem menuExport;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuSettings;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
    }
}

