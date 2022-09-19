namespace GISGeometryCompressor
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
            this.lblSelectDatabase = new System.Windows.Forms.Label();
            this.cboSelectDatabase = new System.Windows.Forms.ComboBox();
            this.cboSelectTable = new System.Windows.Forms.ComboBox();
            this.lblSelectTable = new System.Windows.Forms.Label();
            this.lblSelectColumn = new System.Windows.Forms.Label();
            this.cboSelectColumn = new System.Windows.Forms.ComboBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.lblSelectPKEY = new System.Windows.Forms.Label();
            this.cboSelectPKEY = new System.Windows.Forms.ComboBox();
            this.lblSelectPasses = new System.Windows.Forms.Label();
            this.cboSelectPasses = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.cboID = new System.Windows.Forms.ComboBox();
            this.chkSkipDataSets = new System.Windows.Forms.CheckBox();
            this.ttHover = new System.Windows.Forms.ToolTip(this.components);
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.bwProcess = new System.ComponentModel.BackgroundWorker();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSelectDatabase
            // 
            this.lblSelectDatabase.AutoSize = true;
            this.lblSelectDatabase.Location = new System.Drawing.Point(12, 15);
            this.lblSelectDatabase.Name = "lblSelectDatabase";
            this.lblSelectDatabase.Size = new System.Drawing.Size(53, 13);
            this.lblSelectDatabase.TabIndex = 1;
            this.lblSelectDatabase.Text = "Database";
            // 
            // cboSelectDatabase
            // 
            this.cboSelectDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectDatabase.FormattingEnabled = true;
            this.cboSelectDatabase.Location = new System.Drawing.Point(71, 12);
            this.cboSelectDatabase.Name = "cboSelectDatabase";
            this.cboSelectDatabase.Size = new System.Drawing.Size(201, 21);
            this.cboSelectDatabase.TabIndex = 0;
            this.cboSelectDatabase.SelectedIndexChanged += new System.EventHandler(this.cboSelectDatabase_SelectedIndexChanged);
            // 
            // cboSelectTable
            // 
            this.cboSelectTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectTable.FormattingEnabled = true;
            this.cboSelectTable.Location = new System.Drawing.Point(71, 39);
            this.cboSelectTable.Name = "cboSelectTable";
            this.cboSelectTable.Size = new System.Drawing.Size(201, 21);
            this.cboSelectTable.TabIndex = 2;
            this.cboSelectTable.SelectedIndexChanged += new System.EventHandler(this.cboSelectTable_SelectedIndexChanged);
            // 
            // lblSelectTable
            // 
            this.lblSelectTable.AutoSize = true;
            this.lblSelectTable.Location = new System.Drawing.Point(12, 42);
            this.lblSelectTable.Name = "lblSelectTable";
            this.lblSelectTable.Size = new System.Drawing.Size(34, 13);
            this.lblSelectTable.TabIndex = 3;
            this.lblSelectTable.Text = "Table";
            // 
            // lblSelectColumn
            // 
            this.lblSelectColumn.AutoSize = true;
            this.lblSelectColumn.Location = new System.Drawing.Point(12, 96);
            this.lblSelectColumn.Name = "lblSelectColumn";
            this.lblSelectColumn.Size = new System.Drawing.Size(42, 13);
            this.lblSelectColumn.TabIndex = 5;
            this.lblSelectColumn.Text = "Column";
            // 
            // cboSelectColumn
            // 
            this.cboSelectColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectColumn.FormattingEnabled = true;
            this.cboSelectColumn.Location = new System.Drawing.Point(71, 93);
            this.cboSelectColumn.Name = "cboSelectColumn";
            this.cboSelectColumn.Size = new System.Drawing.Size(201, 21);
            this.cboSelectColumn.TabIndex = 4;
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(71, 170);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 6;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // lblSelectPKEY
            // 
            this.lblSelectPKEY.AutoSize = true;
            this.lblSelectPKEY.Location = new System.Drawing.Point(12, 69);
            this.lblSelectPKEY.Name = "lblSelectPKEY";
            this.lblSelectPKEY.Size = new System.Drawing.Size(35, 13);
            this.lblSelectPKEY.TabIndex = 8;
            this.lblSelectPKEY.Text = "PKEY";
            // 
            // cboSelectPKEY
            // 
            this.cboSelectPKEY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectPKEY.FormattingEnabled = true;
            this.cboSelectPKEY.Location = new System.Drawing.Point(71, 66);
            this.cboSelectPKEY.Name = "cboSelectPKEY";
            this.cboSelectPKEY.Size = new System.Drawing.Size(201, 21);
            this.cboSelectPKEY.TabIndex = 7;
            this.cboSelectPKEY.SelectedIndexChanged += new System.EventHandler(this.cboSelectPKEY_SelectedIndexChanged);
            // 
            // lblSelectPasses
            // 
            this.lblSelectPasses.AutoSize = true;
            this.lblSelectPasses.Location = new System.Drawing.Point(12, 123);
            this.lblSelectPasses.Name = "lblSelectPasses";
            this.lblSelectPasses.Size = new System.Drawing.Size(41, 13);
            this.lblSelectPasses.TabIndex = 10;
            this.lblSelectPasses.Text = "Passes";
            // 
            // cboSelectPasses
            // 
            this.cboSelectPasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectPasses.FormattingEnabled = true;
            this.cboSelectPasses.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cboSelectPasses.Location = new System.Drawing.Point(71, 120);
            this.cboSelectPasses.Name = "cboSelectPasses";
            this.cboSelectPasses.Size = new System.Drawing.Size(201, 21);
            this.cboSelectPasses.TabIndex = 9;
            this.cboSelectPasses.Text = "1";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 231);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 12;
            this.lblID.Text = "ID";
            // 
            // cboID
            // 
            this.cboID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboID.FormattingEnabled = true;
            this.cboID.Items.AddRange(new object[] {
            "All",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cboID.Location = new System.Drawing.Point(71, 228);
            this.cboID.Name = "cboID";
            this.cboID.Size = new System.Drawing.Size(201, 21);
            this.cboID.TabIndex = 11;
            this.cboID.Text = "All";
            // 
            // chkSkipDataSets
            // 
            this.chkSkipDataSets.AutoSize = true;
            this.chkSkipDataSets.Checked = true;
            this.chkSkipDataSets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSkipDataSets.Location = new System.Drawing.Point(71, 147);
            this.chkSkipDataSets.Name = "chkSkipDataSets";
            this.chkSkipDataSets.Size = new System.Drawing.Size(184, 17);
            this.chkSkipDataSets.TabIndex = 13;
            this.chkSkipDataSets.Text = "Don\'t compress if below threshold";
            this.ttHover.SetToolTip(this.chkSkipDataSets, "Don\'t compress datasets less than 4 co-ordinates large.");
            this.chkSkipDataSets.UseVisualStyleBackColor = true;
            // 
            // ttHover
            // 
            this.ttHover.IsBalloon = true;
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.Location = new System.Drawing.Point(12, 282);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(260, 23);
            this.pbProgress.TabIndex = 14;
            // 
            // bwProcess
            // 
            this.bwProcess.WorkerReportsProgress = true;
            this.bwProcess.WorkerSupportsCancellation = true;
            this.bwProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwProcess_DoWork);
            this.bwProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwProcess_ProgressChanged);
            this.bwProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwProcess_RunWorkerCompleted);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 266);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(13, 13);
            this.lblProgress.TabIndex = 17;
            this.lblProgress.Text = "0";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 317);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.chkSkipDataSets);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.cboID);
            this.Controls.Add(this.lblSelectPasses);
            this.Controls.Add(this.cboSelectPasses);
            this.Controls.Add(this.lblSelectPKEY);
            this.Controls.Add(this.cboSelectPKEY);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.lblSelectColumn);
            this.Controls.Add(this.cboSelectColumn);
            this.Controls.Add(this.lblSelectTable);
            this.Controls.Add(this.cboSelectTable);
            this.Controls.Add(this.lblSelectDatabase);
            this.Controls.Add(this.cboSelectDatabase);
            this.Name = "frmMain";
            this.Text = "GIS Geometry Compressor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSelectDatabase;
        private System.Windows.Forms.ComboBox cboSelectDatabase;
        private System.Windows.Forms.ComboBox cboSelectTable;
        private System.Windows.Forms.Label lblSelectTable;
        private System.Windows.Forms.Label lblSelectColumn;
        private System.Windows.Forms.ComboBox cboSelectColumn;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Label lblSelectPKEY;
        private System.Windows.Forms.ComboBox cboSelectPKEY;
        private System.Windows.Forms.Label lblSelectPasses;
        private System.Windows.Forms.ComboBox cboSelectPasses;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cboID;
        private System.Windows.Forms.CheckBox chkSkipDataSets;
        private System.Windows.Forms.ToolTip ttHover;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.ComponentModel.BackgroundWorker bwProcess;
        private System.Windows.Forms.Label lblProgress;
    }
}

