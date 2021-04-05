
namespace LottoDataManager.Forms
{
    partial class ModifyBetDateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyBetDateFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.oblViewBets = new BrightIdeasSoftware.ObjectListView();
            this.olvColChkbox = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNumComb = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLottoOutlet = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLottoSeqGen = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbStartingDates = new System.Windows.Forms.GroupBox();
            this.linkLabelFilterNow = new System.Windows.Forms.LinkLabel();
            this.dateTimePickerBets = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbSelectedDate = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.RichTextBox();
            this.gbTargetDrawDate = new System.Windows.Forms.GroupBox();
            this.dtDrawDate = new System.Windows.Forms.DateTimePicker();
            this.gbDateCal = new System.Windows.Forms.GroupBox();
            this.lblDateEvery = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oblViewBets)).BeginInit();
            this.panel2.SuspendLayout();
            this.gbStartingDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbSelectedDate.SuspendLayout();
            this.gbTargetDrawDate.SuspendLayout();
            this.gbDateCal.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.oblViewBets);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 414);
            this.panel1.TabIndex = 1;
            // 
            // oblViewBets
            // 
            this.oblViewBets.AllColumns.Add(this.olvColChkbox);
            this.oblViewBets.AllColumns.Add(this.olvColDrawDate);
            this.oblViewBets.AllColumns.Add(this.olvColNumComb);
            this.oblViewBets.AllColumns.Add(this.olvLottoOutlet);
            this.oblViewBets.AllColumns.Add(this.olvLottoSeqGen);
            this.oblViewBets.CellEditUseWholeCell = false;
            this.oblViewBets.CheckBoxes = true;
            this.oblViewBets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColChkbox,
            this.olvColDrawDate,
            this.olvColNumComb,
            this.olvLottoOutlet,
            this.olvLottoSeqGen});
            this.oblViewBets.Cursor = System.Windows.Forms.Cursors.Default;
            this.oblViewBets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oblViewBets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oblViewBets.FullRowSelect = true;
            this.oblViewBets.GridLines = true;
            this.oblViewBets.HideSelection = false;
            this.oblViewBets.Location = new System.Drawing.Point(0, 68);
            this.oblViewBets.Name = "oblViewBets";
            this.oblViewBets.ShowGroups = false;
            this.oblViewBets.Size = new System.Drawing.Size(521, 346);
            this.oblViewBets.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.oblViewBets.TabIndex = 0;
            this.oblViewBets.UseCompatibleStateImageBehavior = false;
            this.oblViewBets.View = System.Windows.Forms.View.Details;
            // 
            // olvColChkbox
            // 
            this.olvColChkbox.HeaderCheckBox = true;
            this.olvColChkbox.IsEditable = false;
            this.olvColChkbox.Text = "Select";
            this.olvColChkbox.Width = 67;
            // 
            // olvColDrawDate
            // 
            this.olvColDrawDate.AspectName = "GetTargetDrawDateFormatted";
            this.olvColDrawDate.IsEditable = false;
            this.olvColDrawDate.Text = "Target Draw Date";
            this.olvColDrawDate.Width = 152;
            // 
            // olvColNumComb
            // 
            this.olvColNumComb.IsEditable = false;
            this.olvColNumComb.Text = "Bet";
            this.olvColNumComb.Width = 146;
            // 
            // olvLottoOutlet
            // 
            this.olvLottoOutlet.IsEditable = false;
            this.olvLottoOutlet.Text = "Lotto Outlet";
            this.olvLottoOutlet.Width = 145;
            // 
            // olvLottoSeqGen
            // 
            this.olvLottoSeqGen.IsEditable = false;
            this.olvLottoSeqGen.Text = "Sequence Generator";
            this.olvLottoSeqGen.Width = 160;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbStartingDates);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(521, 68);
            this.panel2.TabIndex = 2;
            // 
            // gbStartingDates
            // 
            this.gbStartingDates.Controls.Add(this.linkLabelFilterNow);
            this.gbStartingDates.Controls.Add(this.dateTimePickerBets);
            this.gbStartingDates.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbStartingDates.Location = new System.Drawing.Point(0, 0);
            this.gbStartingDates.Name = "gbStartingDates";
            this.gbStartingDates.Size = new System.Drawing.Size(521, 62);
            this.gbStartingDates.TabIndex = 5;
            this.gbStartingDates.TabStop = false;
            this.gbStartingDates.Text = "Show you bets starting from the date below";
            // 
            // linkLabelFilterNow
            // 
            this.linkLabelFilterNow.AutoSize = true;
            this.linkLabelFilterNow.Location = new System.Drawing.Point(285, 36);
            this.linkLabelFilterNow.Name = "linkLabelFilterNow";
            this.linkLabelFilterNow.Size = new System.Drawing.Size(73, 17);
            this.linkLabelFilterNow.TabIndex = 3;
            this.linkLabelFilterNow.TabStop = true;
            this.linkLabelFilterNow.Text = "Filter Now!";
            this.linkLabelFilterNow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFilterNow_LinkClicked);
            // 
            // dateTimePickerBets
            // 
            this.dateTimePickerBets.Location = new System.Drawing.Point(9, 31);
            this.dateTimePickerBets.Name = "dateTimePickerBets";
            this.dateTimePickerBets.Size = new System.Drawing.Size(270, 22);
            this.dateTimePickerBets.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 19);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbSelectedDate);
            this.splitContainer1.Panel2.Controls.Add(this.gbTargetDrawDate);
            this.splitContainer1.Panel2.Controls.Add(this.gbDateCal);
            this.splitContainer1.Size = new System.Drawing.Size(1035, 414);
            this.splitContainer1.SplitterDistance = 521;
            this.splitContainer1.TabIndex = 5;
            // 
            // gbSelectedDate
            // 
            this.gbSelectedDate.Controls.Add(this.txtStatus);
            this.gbSelectedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSelectedDate.Location = new System.Drawing.Point(0, 123);
            this.gbSelectedDate.Name = "gbSelectedDate";
            this.gbSelectedDate.Size = new System.Drawing.Size(510, 291);
            this.gbSelectedDate.TabIndex = 2;
            this.gbSelectedDate.TabStop = false;
            this.gbSelectedDate.Text = "Processing status....";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.White;
            this.txtStatus.Location = new System.Drawing.Point(3, 18);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ShowSelectionMargin = true;
            this.txtStatus.Size = new System.Drawing.Size(504, 270);
            this.txtStatus.TabIndex = 1;
            this.txtStatus.Text = "";
            // 
            // gbTargetDrawDate
            // 
            this.gbTargetDrawDate.Controls.Add(this.dtDrawDate);
            this.gbTargetDrawDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTargetDrawDate.Location = new System.Drawing.Point(0, 63);
            this.gbTargetDrawDate.Name = "gbTargetDrawDate";
            this.gbTargetDrawDate.Size = new System.Drawing.Size(510, 60);
            this.gbTargetDrawDate.TabIndex = 1;
            this.gbTargetDrawDate.TabStop = false;
            this.gbTargetDrawDate.Text = "Or select your target draw date";
            // 
            // dtDrawDate
            // 
            this.dtDrawDate.Location = new System.Drawing.Point(6, 21);
            this.dtDrawDate.Name = "dtDrawDate";
            this.dtDrawDate.Size = new System.Drawing.Size(458, 22);
            this.dtDrawDate.TabIndex = 1;
            // 
            // gbDateCal
            // 
            this.gbDateCal.Controls.Add(this.lblDateEvery);
            this.gbDateCal.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDateCal.Location = new System.Drawing.Point(0, 0);
            this.gbDateCal.Name = "gbDateCal";
            this.gbDateCal.Size = new System.Drawing.Size(510, 63);
            this.gbDateCal.TabIndex = 0;
            this.gbDateCal.TabStop = false;
            this.gbDateCal.Text = "Valid Draw Dates are";
            // 
            // lblDateEvery
            // 
            this.lblDateEvery.AutoSize = true;
            this.lblDateEvery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateEvery.ForeColor = System.Drawing.Color.Tomato;
            this.lblDateEvery.Location = new System.Drawing.Point(7, 27);
            this.lblDateEvery.Name = "lblDateEvery";
            this.lblDateEvery.Size = new System.Drawing.Size(189, 25);
            this.lblDateEvery.TabIndex = 0;
            this.lblDateEvery.Text = "every Mon, Tue, Sat";
            this.lblDateEvery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.btnSaveChanges);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 433);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1035, 80);
            this.panel3.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::LottoDataManager.Properties.Resources.Available_Updates_32px;
            this.btnRefresh.Location = new System.Drawing.Point(559, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(149, 56);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRestoreBack_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Image = global::LottoDataManager.Properties.Resources.save_v1_32;
            this.btnSaveChanges.Location = new System.Drawing.Point(714, 12);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(157, 56);
            this.btnSaveChanges.TabIndex = 11;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::LottoDataManager.Properties.Resources.Exit_32;
            this.btnExit.Location = new System.Drawing.Point(877, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(146, 56);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1035, 19);
            this.panel4.TabIndex = 4;
            // 
            // ModifyBetDateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1035, 513);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ModifyBetDateFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Bet Date";
            this.Load += new System.EventHandler(this.ModifyBetDateFrm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oblViewBets)).EndInit();
            this.panel2.ResumeLayout(false);
            this.gbStartingDates.ResumeLayout(false);
            this.gbStartingDates.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbSelectedDate.ResumeLayout(false);
            this.gbTargetDrawDate.ResumeLayout(false);
            this.gbDateCal.ResumeLayout(false);
            this.gbDateCal.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private BrightIdeasSoftware.ObjectListView oblViewBets;
        private BrightIdeasSoftware.OLVColumn olvColChkbox;
        private BrightIdeasSoftware.OLVColumn olvColDrawDate;
        private BrightIdeasSoftware.OLVColumn olvColNumComb;
        private BrightIdeasSoftware.OLVColumn olvLottoOutlet;
        private BrightIdeasSoftware.OLVColumn olvLottoSeqGen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabelFilterNow;
        private System.Windows.Forms.DateTimePicker dateTimePickerBets;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbSelectedDate;
        private System.Windows.Forms.GroupBox gbTargetDrawDate;
        private System.Windows.Forms.GroupBox gbDateCal;
        private System.Windows.Forms.GroupBox gbStartingDates;
        private System.Windows.Forms.DateTimePicker dtDrawDate;
        private System.Windows.Forms.Label lblDateEvery;
        private System.Windows.Forms.RichTextBox txtStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel4;
    }
}