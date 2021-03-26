
namespace LottoDataManager.Forms
{
    partial class ModifyClaimsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyClaimsFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.objectListViewWinningBets = new BrightIdeasSoftware.ObjectListView();
            this.olvColChkbox = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColWinAmt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ctxMenuLvBet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedHighlightedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckedIghlightedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelFilterNow = new System.Windows.Forms.LinkLabel();
            this.dateTimePickerBets = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linkUnCheckAll = new System.Windows.Forms.LinkLabel();
            this.linkCheckAll = new System.Windows.Forms.LinkLabel();
            this.btnRestoreBack = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewWinningBets)).BeginInit();
            this.ctxMenuLvBet.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.objectListViewWinningBets);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 471);
            this.panel1.TabIndex = 0;
            // 
            // objectListViewWinningBets
            // 
            this.objectListViewWinningBets.AllColumns.Add(this.olvColChkbox);
            this.objectListViewWinningBets.AllColumns.Add(this.olvColDrawDate);
            this.objectListViewWinningBets.AllColumns.Add(this.olvColWinAmt);
            this.objectListViewWinningBets.AllColumns.Add(this.olvColNum1);
            this.objectListViewWinningBets.AllColumns.Add(this.olvColNum2);
            this.objectListViewWinningBets.AllColumns.Add(this.olvColNum3);
            this.objectListViewWinningBets.AllColumns.Add(this.olvColNum4);
            this.objectListViewWinningBets.AllColumns.Add(this.olvColNum5);
            this.objectListViewWinningBets.AllColumns.Add(this.olvColNum6);
            this.objectListViewWinningBets.CellEditUseWholeCell = false;
            this.objectListViewWinningBets.CheckBoxes = true;
            this.objectListViewWinningBets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColChkbox,
            this.olvColDrawDate,
            this.olvColWinAmt,
            this.olvColNum1,
            this.olvColNum2,
            this.olvColNum3,
            this.olvColNum4,
            this.olvColNum5,
            this.olvColNum6});
            this.objectListViewWinningBets.ContextMenuStrip = this.ctxMenuLvBet;
            this.objectListViewWinningBets.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListViewWinningBets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewWinningBets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objectListViewWinningBets.FullRowSelect = true;
            this.objectListViewWinningBets.GridLines = true;
            this.objectListViewWinningBets.HideSelection = false;
            this.objectListViewWinningBets.Location = new System.Drawing.Point(0, 68);
            this.objectListViewWinningBets.Name = "objectListViewWinningBets";
            this.objectListViewWinningBets.ShowGroups = false;
            this.objectListViewWinningBets.Size = new System.Drawing.Size(945, 403);
            this.objectListViewWinningBets.TabIndex = 0;
            this.objectListViewWinningBets.UseCompatibleStateImageBehavior = false;
            this.objectListViewWinningBets.View = System.Windows.Forms.View.Details;
            this.objectListViewWinningBets.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.objectListViewBets_ItemChecked);
            // 
            // olvColChkbox
            // 
            this.olvColChkbox.AspectName = "";
            this.olvColChkbox.IsEditable = false;
            this.olvColChkbox.Text = "Claimed?";
            this.olvColChkbox.Width = 128;
            // 
            // olvColDrawDate
            // 
            this.olvColDrawDate.AspectName = "GetTargetDrawDateFormatted";
            this.olvColDrawDate.IsEditable = false;
            this.olvColDrawDate.Text = "Target Draw Date";
            this.olvColDrawDate.Width = 152;
            // 
            // olvColWinAmt
            // 
            this.olvColWinAmt.AspectName = "GetWinningAmount";
            this.olvColWinAmt.AspectToStringFormat = "{0:C}";
            this.olvColWinAmt.IsEditable = false;
            this.olvColWinAmt.Text = "Win Amount";
            this.olvColWinAmt.Width = 120;
            // 
            // olvColNum1
            // 
            this.olvColNum1.AspectName = "GetNum1";
            this.olvColNum1.IsEditable = false;
            this.olvColNum1.Text = "Num # 1";
            this.olvColNum1.Width = 96;
            // 
            // olvColNum2
            // 
            this.olvColNum2.AspectName = "GetNum2";
            this.olvColNum2.IsEditable = false;
            this.olvColNum2.Text = "Num # 2";
            this.olvColNum2.Width = 84;
            // 
            // olvColNum3
            // 
            this.olvColNum3.AspectName = "GetNum3";
            this.olvColNum3.IsEditable = false;
            this.olvColNum3.Text = "Num # 3";
            this.olvColNum3.Width = 83;
            // 
            // olvColNum4
            // 
            this.olvColNum4.AspectName = "GetNum4";
            this.olvColNum4.IsEditable = false;
            this.olvColNum4.Text = "Num # 4";
            this.olvColNum4.Width = 82;
            // 
            // olvColNum5
            // 
            this.olvColNum5.AspectName = "GetNum5";
            this.olvColNum5.IsEditable = false;
            this.olvColNum5.Text = "Num # 5";
            this.olvColNum5.Width = 90;
            // 
            // olvColNum6
            // 
            this.olvColNum6.AspectName = "GetNum6";
            this.olvColNum6.IsEditable = false;
            this.olvColNum6.Text = "Num # 6";
            this.olvColNum6.Width = 88;
            // 
            // ctxMenuLvBet
            // 
            this.ctxMenuLvBet.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenuLvBet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.checkedHighlightedToolStripMenuItem,
            this.uncheckedIghlightedToolStripMenuItem,
            this.checkAllToolStripMenuItem,
            this.uncheckAllToolStripMenuItem});
            this.ctxMenuLvBet.Name = "ctxMenuLvBet";
            this.ctxMenuLvBet.Size = new System.Drawing.Size(231, 124);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // checkedHighlightedToolStripMenuItem
            // 
            this.checkedHighlightedToolStripMenuItem.Name = "checkedHighlightedToolStripMenuItem";
            this.checkedHighlightedToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.checkedHighlightedToolStripMenuItem.Text = "Checked highlighted";
            this.checkedHighlightedToolStripMenuItem.Click += new System.EventHandler(this.checkedHighlightedToolStripMenuItem_Click);
            // 
            // uncheckedIghlightedToolStripMenuItem
            // 
            this.uncheckedIghlightedToolStripMenuItem.Name = "uncheckedIghlightedToolStripMenuItem";
            this.uncheckedIghlightedToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.uncheckedIghlightedToolStripMenuItem.Text = "Unchecked highlighted";
            this.uncheckedIghlightedToolStripMenuItem.Click += new System.EventHandler(this.uncheckedIghlightedToolStripMenuItem_Click);
            // 
            // checkAllToolStripMenuItem
            // 
            this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
            this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.checkAllToolStripMenuItem.Text = "Check All";
            this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
            // 
            // uncheckAllToolStripMenuItem
            // 
            this.uncheckAllToolStripMenuItem.Name = "uncheckAllToolStripMenuItem";
            this.uncheckAllToolStripMenuItem.Size = new System.Drawing.Size(230, 24);
            this.uncheckAllToolStripMenuItem.Text = "Uncheck All";
            this.uncheckAllToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.linkLabelFilterNow);
            this.panel2.Controls.Add(this.dateTimePickerBets);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 68);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(539, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(394, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "* Instruction: Check or uncheck marks the status of the claims";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Show your winnings and claims starting from the date below";
            // 
            // linkLabelFilterNow
            // 
            this.linkLabelFilterNow.AutoSize = true;
            this.linkLabelFilterNow.Location = new System.Drawing.Point(279, 39);
            this.linkLabelFilterNow.Name = "linkLabelFilterNow";
            this.linkLabelFilterNow.Size = new System.Drawing.Size(73, 17);
            this.linkLabelFilterNow.TabIndex = 3;
            this.linkLabelFilterNow.TabStop = true;
            this.linkLabelFilterNow.Text = "Filter Now!";
            this.linkLabelFilterNow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFilterNow_LinkClicked);
            // 
            // dateTimePickerBets
            // 
            this.dateTimePickerBets.Location = new System.Drawing.Point(3, 36);
            this.dateTimePickerBets.Name = "dateTimePickerBets";
            this.dateTimePickerBets.Size = new System.Drawing.Size(270, 22);
            this.dateTimePickerBets.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.linkUnCheckAll);
            this.panel3.Controls.Add(this.linkCheckAll);
            this.panel3.Controls.Add(this.btnRestoreBack);
            this.panel3.Controls.Add(this.btnSaveChanges);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 471);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(945, 79);
            this.panel3.TabIndex = 3;
            // 
            // linkUnCheckAll
            // 
            this.linkUnCheckAll.AutoSize = true;
            this.linkUnCheckAll.Location = new System.Drawing.Point(97, 14);
            this.linkUnCheckAll.Name = "linkUnCheckAll";
            this.linkUnCheckAll.Size = new System.Drawing.Size(82, 17);
            this.linkUnCheckAll.TabIndex = 11;
            this.linkUnCheckAll.TabStop = true;
            this.linkUnCheckAll.Text = "Uncheck All";
            this.linkUnCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUnCheckAll_LinkClicked);
            // 
            // linkCheckAll
            // 
            this.linkCheckAll.AutoSize = true;
            this.linkCheckAll.Location = new System.Drawing.Point(12, 14);
            this.linkCheckAll.Name = "linkCheckAll";
            this.linkCheckAll.Size = new System.Drawing.Size(66, 17);
            this.linkCheckAll.TabIndex = 10;
            this.linkCheckAll.TabStop = true;
            this.linkCheckAll.Text = "Check All";
            this.linkCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCheckAll_LinkClicked);
            // 
            // btnRestoreBack
            // 
            this.btnRestoreBack.Location = new System.Drawing.Point(464, 13);
            this.btnRestoreBack.Name = "btnRestoreBack";
            this.btnRestoreBack.Size = new System.Drawing.Size(171, 56);
            this.btnRestoreBack.TabIndex = 9;
            this.btnRestoreBack.Text = "Restore Back the List";
            this.btnRestoreBack.UseVisualStyleBackColor = true;
            this.btnRestoreBack.Click += new System.EventHandler(this.btnRestoreBack_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(641, 13);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(146, 56);
            this.btnSaveChanges.TabIndex = 7;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(793, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(146, 56);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgBar,
            this.toolStripStatusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 550);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(945, 26);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgBar
            // 
            this.toolStripProgBar.Name = "toolStripProgBar";
            this.toolStripProgBar.Size = new System.Drawing.Size(100, 18);
            this.toolStripProgBar.Visible = false;
            // 
            // toolStripStatusLbl
            // 
            this.toolStripStatusLbl.Name = "toolStripStatusLbl";
            this.toolStripStatusLbl.Size = new System.Drawing.Size(89, 20);
            this.toolStripStatusLbl.Text = "Hello World";
            // 
            // ModifyClaimsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(945, 576);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyClaimsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Claims Status";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewWinningBets)).EndInit();
            this.ctxMenuLvBet.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private BrightIdeasSoftware.ObjectListView objectListViewWinningBets;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerBets;
        private System.Windows.Forms.LinkLabel linkLabelFilterNow;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.OLVColumn olvColDrawDate;
        private BrightIdeasSoftware.OLVColumn olvColNum1;
        private BrightIdeasSoftware.OLVColumn olvColNum2;
        private BrightIdeasSoftware.OLVColumn olvColNum3;
        private BrightIdeasSoftware.OLVColumn olvColNum4;
        private BrightIdeasSoftware.OLVColumn olvColNum5;
        private BrightIdeasSoftware.OLVColumn olvColNum6;
        private BrightIdeasSoftware.OLVColumn olvColChkbox;
        private System.Windows.Forms.ContextMenuStrip ctxMenuLvBet;
        private System.Windows.Forms.ToolStripMenuItem checkedHighlightedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckedIghlightedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRestoreBack;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLbl;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgBar;
        private BrightIdeasSoftware.OLVColumn olvColWinAmt;
        private System.Windows.Forms.LinkLabel linkUnCheckAll;
        private System.Windows.Forms.LinkLabel linkCheckAll;
    }
}