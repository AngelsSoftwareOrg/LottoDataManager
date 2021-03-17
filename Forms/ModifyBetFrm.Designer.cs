
namespace LottoDataManager.Forms
{
    partial class ModifyBetFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyBetFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.objectListViewBets = new BrightIdeasSoftware.ObjectListView();
            this.olvColChkbox = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvLottoOutlet = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            this.btnRestoreBack = new System.Windows.Forms.Button();
            this.btnDeleteChecked = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.olvLottoSeqGen = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewBets)).BeginInit();
            this.ctxMenuLvBet.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.objectListViewBets);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 429);
            this.panel1.TabIndex = 0;
            // 
            // objectListViewBets
            // 
            this.objectListViewBets.AllColumns.Add(this.olvColChkbox);
            this.objectListViewBets.AllColumns.Add(this.olvColDrawDate);
            this.objectListViewBets.AllColumns.Add(this.olvColNum1);
            this.objectListViewBets.AllColumns.Add(this.olvColNum2);
            this.objectListViewBets.AllColumns.Add(this.olvColNum3);
            this.objectListViewBets.AllColumns.Add(this.olvColNum4);
            this.objectListViewBets.AllColumns.Add(this.olvColNum5);
            this.objectListViewBets.AllColumns.Add(this.olvColNum6);
            this.objectListViewBets.AllColumns.Add(this.olvLottoOutlet);
            this.objectListViewBets.AllColumns.Add(this.olvLottoSeqGen);
            this.objectListViewBets.CellEditUseWholeCell = false;
            this.objectListViewBets.CheckBoxes = true;
            this.objectListViewBets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColChkbox,
            this.olvColDrawDate,
            this.olvColNum1,
            this.olvColNum2,
            this.olvColNum3,
            this.olvColNum4,
            this.olvColNum5,
            this.olvColNum6,
            this.olvLottoOutlet,
            this.olvLottoSeqGen});
            this.objectListViewBets.ContextMenuStrip = this.ctxMenuLvBet;
            this.objectListViewBets.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListViewBets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListViewBets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objectListViewBets.FullRowSelect = true;
            this.objectListViewBets.GridLines = true;
            this.objectListViewBets.HideSelection = false;
            this.objectListViewBets.Location = new System.Drawing.Point(0, 68);
            this.objectListViewBets.Name = "objectListViewBets";
            this.objectListViewBets.ShowGroups = false;
            this.objectListViewBets.Size = new System.Drawing.Size(945, 361);
            this.objectListViewBets.TabIndex = 0;
            this.objectListViewBets.UseCompatibleStateImageBehavior = false;
            this.objectListViewBets.View = System.Windows.Forms.View.Details;
            this.objectListViewBets.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.objectListViewBets_ItemChecked);
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
            // olvColNum1
            // 
            this.olvColNum1.AspectName = "GetNum1";
            this.olvColNum1.Text = "Num # 1";
            this.olvColNum1.Width = 96;
            // 
            // olvColNum2
            // 
            this.olvColNum2.AspectName = "GetNum2";
            this.olvColNum2.Text = "Num # 2";
            this.olvColNum2.Width = 84;
            // 
            // olvColNum3
            // 
            this.olvColNum3.AspectName = "GetNum3";
            this.olvColNum3.Text = "Num # 3";
            this.olvColNum3.Width = 83;
            // 
            // olvColNum4
            // 
            this.olvColNum4.AspectName = "GetNum4";
            this.olvColNum4.Text = "Num # 4";
            this.olvColNum4.Width = 82;
            // 
            // olvColNum5
            // 
            this.olvColNum5.AspectName = "GetNum5";
            this.olvColNum5.Text = "Num # 5";
            this.olvColNum5.Width = 90;
            // 
            // olvColNum6
            // 
            this.olvColNum6.AspectName = "GetNum6";
            this.olvColNum6.Text = "Num # 6";
            this.olvColNum6.Width = 88;
            // 
            // olvLottoOutlet
            // 
            this.olvLottoOutlet.CellEditUseWholeCell = true;
            this.olvLottoOutlet.Text = "Lotto Outlet";
            this.olvLottoOutlet.Width = 145;
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
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(461, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(478, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "* Instruction: To edit, click on the number cell and start changing the value.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Show you bets starting from the date below";
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
            this.panel3.Controls.Add(this.btnRestoreBack);
            this.panel3.Controls.Add(this.btnDeleteChecked);
            this.panel3.Controls.Add(this.btnSaveChanges);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 429);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(945, 81);
            this.panel3.TabIndex = 3;
            // 
            // btnRestoreBack
            // 
            this.btnRestoreBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreBack.Location = new System.Drawing.Point(464, 14);
            this.btnRestoreBack.Name = "btnRestoreBack";
            this.btnRestoreBack.Size = new System.Drawing.Size(171, 56);
            this.btnRestoreBack.TabIndex = 9;
            this.btnRestoreBack.Text = "Restore Back the List";
            this.btnRestoreBack.UseVisualStyleBackColor = true;
            this.btnRestoreBack.Click += new System.EventHandler(this.btnRestoreBack_Click);
            // 
            // btnDeleteChecked
            // 
            this.btnDeleteChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteChecked.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteChecked.Image")));
            this.btnDeleteChecked.Location = new System.Drawing.Point(12, 21);
            this.btnDeleteChecked.Name = "btnDeleteChecked";
            this.btnDeleteChecked.Size = new System.Drawing.Size(50, 39);
            this.btnDeleteChecked.TabIndex = 8;
            this.btnDeleteChecked.UseVisualStyleBackColor = true;
            this.btnDeleteChecked.Click += new System.EventHandler(this.btnDeleteChecked_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Location = new System.Drawing.Point(641, 14);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(146, 56);
            this.btnSaveChanges.TabIndex = 7;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(793, 14);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 510);
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
            // olvLottoSeqGen
            // 
            this.olvLottoSeqGen.CellEditUseWholeCell = true;
            this.olvLottoSeqGen.Text = "Sequence Generator";
            this.olvLottoSeqGen.Width = 160;
            // 
            // ModifyBetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(945, 536);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ModifyBetFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Bet";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewBets)).EndInit();
            this.ctxMenuLvBet.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private BrightIdeasSoftware.ObjectListView objectListViewBets;
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
        private System.Windows.Forms.Button btnDeleteChecked;
        private System.Windows.Forms.Button btnRestoreBack;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLbl;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgBar;
        private BrightIdeasSoftware.OLVColumn olvLottoOutlet;
        private BrightIdeasSoftware.OLVColumn olvLottoSeqGen;
    }
}