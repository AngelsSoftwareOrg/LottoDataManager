
namespace LottoDataManager.Forms.Ticket
{
    partial class HitComparisonFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HitComparisonFrm));
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.objListVwBet = new BrightIdeasSoftware.ObjectListView();
            this.olvColBetTargetDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetN1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetN2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetN3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetN4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetN5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetN6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetMatch = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.objListVwDrawResult = new BrightIdeasSoftware.ObjectListView();
            this.olvColDrawResultDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawN1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawN2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawN3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawN4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawN5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawN6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawWinner = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDrawMatch = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.lnkFilter = new System.Windows.Forms.LinkLabel();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripProgBarRefresh = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.olvColBetOutlet = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetSeqGen = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListVwBet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objListVwDrawResult)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.splitContainerMain);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 38);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(892, 368);
            this.panelMiddle.TabIndex = 0;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.objListVwBet);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.objListVwDrawResult);
            this.splitContainerMain.Size = new System.Drawing.Size(892, 368);
            this.splitContainerMain.SplitterDistance = 297;
            this.splitContainerMain.TabIndex = 0;
            // 
            // objListVwBet
            // 
            this.objListVwBet.AllColumns.Add(this.olvColBetTargetDate);
            this.objListVwBet.AllColumns.Add(this.olvColBetN1);
            this.objListVwBet.AllColumns.Add(this.olvColBetN2);
            this.objListVwBet.AllColumns.Add(this.olvColBetN3);
            this.objListVwBet.AllColumns.Add(this.olvColBetN4);
            this.objListVwBet.AllColumns.Add(this.olvColBetN5);
            this.objListVwBet.AllColumns.Add(this.olvColBetN6);
            this.objListVwBet.AllColumns.Add(this.olvColBetMatch);
            this.objListVwBet.AllColumns.Add(this.olvColBetOutlet);
            this.objListVwBet.AllColumns.Add(this.olvColBetSeqGen);
            this.objListVwBet.CellEditUseWholeCell = false;
            this.objListVwBet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColBetTargetDate,
            this.olvColBetN1,
            this.olvColBetN2,
            this.olvColBetN3,
            this.olvColBetN4,
            this.olvColBetN5,
            this.olvColBetN6,
            this.olvColBetMatch,
            this.olvColBetOutlet,
            this.olvColBetSeqGen});
            this.objListVwBet.Cursor = System.Windows.Forms.Cursors.Default;
            this.objListVwBet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objListVwBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.objListVwBet.FullRowSelect = true;
            this.objListVwBet.GridLines = true;
            this.objListVwBet.HideSelection = false;
            this.objListVwBet.Location = new System.Drawing.Point(0, 0);
            this.objListVwBet.MultiSelect = false;
            this.objListVwBet.Name = "objListVwBet";
            this.objListVwBet.ShowGroups = false;
            this.objListVwBet.Size = new System.Drawing.Size(297, 368);
            this.objListVwBet.SortGroupItemsByPrimaryColumn = false;
            this.objListVwBet.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.objListVwBet.TabIndex = 2;
            this.objListVwBet.UseCompatibleStateImageBehavior = false;
            this.objListVwBet.View = System.Windows.Forms.View.Details;
            this.objListVwBet.SelectedIndexChanged += new System.EventHandler(this.objListVwBet_SelectedIndexChanged);
            // 
            // olvColBetTargetDate
            // 
            this.olvColBetTargetDate.AspectName = "GetTargetDrawDateFormatted";
            this.olvColBetTargetDate.Text = "Target Date";
            // 
            // olvColBetN1
            // 
            this.olvColBetN1.AspectName = "GetNum1";
            this.olvColBetN1.Text = "#1";
            // 
            // olvColBetN2
            // 
            this.olvColBetN2.AspectName = "GetNum2";
            this.olvColBetN2.Text = "#2";
            // 
            // olvColBetN3
            // 
            this.olvColBetN3.AspectName = "GetNum3";
            this.olvColBetN3.Text = "#3";
            // 
            // olvColBetN4
            // 
            this.olvColBetN4.AspectName = "GetNum4";
            this.olvColBetN4.Text = "#4";
            // 
            // olvColBetN5
            // 
            this.olvColBetN5.AspectName = "GetNum5";
            this.olvColBetN5.Text = "#5";
            // 
            // olvColBetN6
            // 
            this.olvColBetN6.AspectName = "GetNum6";
            this.olvColBetN6.Text = "#6";
            // 
            // olvColBetMatch
            // 
            this.olvColBetMatch.Text = "Match";
            this.olvColBetMatch.Width = 120;
            // 
            // objListVwDrawResult
            // 
            this.objListVwDrawResult.AllColumns.Add(this.olvColDrawResultDate);
            this.objListVwDrawResult.AllColumns.Add(this.olvColDrawN1);
            this.objListVwDrawResult.AllColumns.Add(this.olvColDrawN2);
            this.objListVwDrawResult.AllColumns.Add(this.olvColDrawN3);
            this.objListVwDrawResult.AllColumns.Add(this.olvColDrawN4);
            this.objListVwDrawResult.AllColumns.Add(this.olvColDrawN5);
            this.objListVwDrawResult.AllColumns.Add(this.olvColDrawN6);
            this.objListVwDrawResult.AllColumns.Add(this.olvColDrawWinner);
            this.objListVwDrawResult.AllColumns.Add(this.olvColDrawMatch);
            this.objListVwDrawResult.CellEditUseWholeCell = false;
            this.objListVwDrawResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColDrawResultDate,
            this.olvColDrawN1,
            this.olvColDrawN2,
            this.olvColDrawN3,
            this.olvColDrawN4,
            this.olvColDrawN5,
            this.olvColDrawN6,
            this.olvColDrawWinner,
            this.olvColDrawMatch});
            this.objListVwDrawResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.objListVwDrawResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objListVwDrawResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.objListVwDrawResult.FullRowSelect = true;
            this.objListVwDrawResult.GridLines = true;
            this.objListVwDrawResult.HideSelection = false;
            this.objListVwDrawResult.Location = new System.Drawing.Point(0, 0);
            this.objListVwDrawResult.Name = "objListVwDrawResult";
            this.objListVwDrawResult.ShowGroups = false;
            this.objListVwDrawResult.Size = new System.Drawing.Size(591, 368);
            this.objListVwDrawResult.SortGroupItemsByPrimaryColumn = false;
            this.objListVwDrawResult.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.objListVwDrawResult.TabIndex = 1;
            this.objListVwDrawResult.UseCompatibleStateImageBehavior = false;
            this.objListVwDrawResult.View = System.Windows.Forms.View.Details;
            // 
            // olvColDrawResultDate
            // 
            this.olvColDrawResultDate.AspectName = "GetDrawDateFormatted";
            this.olvColDrawResultDate.Searchable = false;
            this.olvColDrawResultDate.Text = "Draw Date";
            this.olvColDrawResultDate.UseFiltering = false;
            // 
            // olvColDrawN1
            // 
            this.olvColDrawN1.AspectName = "GetNum1";
            this.olvColDrawN1.Text = "#1";
            // 
            // olvColDrawN2
            // 
            this.olvColDrawN2.AspectName = "GetNum2";
            this.olvColDrawN2.Text = "#2";
            // 
            // olvColDrawN3
            // 
            this.olvColDrawN3.AspectName = "GetNum3";
            this.olvColDrawN3.Text = "#3";
            // 
            // olvColDrawN4
            // 
            this.olvColDrawN4.AspectName = "GetNum4";
            this.olvColDrawN4.Text = "#4";
            // 
            // olvColDrawN5
            // 
            this.olvColDrawN5.AspectName = "GetNum5";
            this.olvColDrawN5.Text = "#5";
            // 
            // olvColDrawN6
            // 
            this.olvColDrawN6.AspectName = "GetNum6";
            this.olvColDrawN6.Text = "#6";
            // 
            // olvColDrawWinner
            // 
            this.olvColDrawWinner.Searchable = false;
            this.olvColDrawWinner.Text = "Winner";
            this.olvColDrawWinner.UseFiltering = false;
            this.olvColDrawWinner.Width = 172;
            // 
            // olvColDrawMatch
            // 
            this.olvColDrawMatch.Searchable = false;
            this.olvColDrawMatch.Text = "Match";
            this.olvColDrawMatch.UseFiltering = false;
            this.olvColDrawMatch.Width = 200;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.label4);
            this.panelBottom.Controls.Add(this.label3);
            this.panelBottom.Controls.Add(this.label2);
            this.panelBottom.Controls.Add(this.btnExit);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 406);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(892, 79);
            this.panelBottom.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(3, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(574, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "*Right table are drawn results. Selecting a bet will show the matching numbers on" +
    " the right";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "*Left table are all filtered bets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "*See how your bet fares to to other drawn results...";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::LottoDataManager.Properties.Resources.Exit_32;
            this.btnExit.Location = new System.Drawing.Point(710, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(170, 63);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.dateTimePickerTo);
            this.panelTop.Controls.Add(this.lnkFilter);
            this.panelTop.Controls.Add(this.dateTimePickerFrom);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(892, 38);
            this.panelTop.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(486, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "To:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(530, 11);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(242, 22);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // lnkFilter
            // 
            this.lnkFilter.AutoSize = true;
            this.lnkFilter.Location = new System.Drawing.Point(780, 12);
            this.lnkFilter.Name = "lnkFilter";
            this.lnkFilter.Size = new System.Drawing.Size(39, 17);
            this.lnkFilter.TabIndex = 2;
            this.lnkFilter.TabStop = true;
            this.lnkFilter.Text = "Filter";
            this.lnkFilter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFilter_LinkClicked);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(195, 11);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(242, 22);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Show data starting from:";
            // 
            // statusStripMain
            // 
            this.statusStripMain.AutoSize = false;
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgBarRefresh,
            this.toolStripStatusLbl});
            this.statusStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStripMain.Location = new System.Drawing.Point(0, 485);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(892, 26);
            this.statusStripMain.TabIndex = 4;
            // 
            // toolStripProgBarRefresh
            // 
            this.toolStripProgBarRefresh.Name = "toolStripProgBarRefresh";
            this.toolStripProgBarRefresh.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripProgBarRefresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripProgBarRefresh.Size = new System.Drawing.Size(250, 18);
            // 
            // toolStripStatusLbl
            // 
            this.toolStripStatusLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLbl.ForeColor = System.Drawing.Color.Tomato;
            this.toolStripStatusLbl.Name = "toolStripStatusLbl";
            this.toolStripStatusLbl.Size = new System.Drawing.Size(107, 20);
            this.toolStripStatusLbl.Spring = true;
            this.toolStripStatusLbl.Text = "Sample Words";
            this.toolStripStatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // olvColBetOutlet
            // 
            this.olvColBetOutlet.Searchable = false;
            this.olvColBetOutlet.Text = "Outlet";
            this.olvColBetOutlet.Width = 250;
            this.olvColBetOutlet.WordWrap = true;
            // 
            // olvColBetSeqGen
            // 
            this.olvColBetSeqGen.Searchable = false;
            this.olvColBetSeqGen.Text = "Sequence Generator";
            this.olvColBetSeqGen.Width = 700;
            // 
            // HitComparisonFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(892, 511);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.statusStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "HitComparisonFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hit Comparison";
            this.panelMiddle.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objListVwBet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objListVwDrawResult)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private BrightIdeasSoftware.ObjectListView objListVwDrawResult;
        private System.Windows.Forms.Button btnExit;
        private BrightIdeasSoftware.ObjectListView objListVwBet;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkFilter;
        private BrightIdeasSoftware.OLVColumn olvColBetTargetDate;
        private BrightIdeasSoftware.OLVColumn olvColBetN1;
        private BrightIdeasSoftware.OLVColumn olvColBetN2;
        private BrightIdeasSoftware.OLVColumn olvColBetN3;
        private BrightIdeasSoftware.OLVColumn olvColBetN4;
        private BrightIdeasSoftware.OLVColumn olvColBetN5;
        private BrightIdeasSoftware.OLVColumn olvColBetN6;
        private BrightIdeasSoftware.OLVColumn olvColBetMatch;
        private BrightIdeasSoftware.OLVColumn olvColDrawResultDate;
        private BrightIdeasSoftware.OLVColumn olvColDrawN1;
        private BrightIdeasSoftware.OLVColumn olvColDrawN2;
        private BrightIdeasSoftware.OLVColumn olvColDrawN3;
        private BrightIdeasSoftware.OLVColumn olvColDrawN4;
        private BrightIdeasSoftware.OLVColumn olvColDrawN5;
        private BrightIdeasSoftware.OLVColumn olvColDrawN6;
        private BrightIdeasSoftware.OLVColumn olvColDrawWinner;
        private BrightIdeasSoftware.OLVColumn olvColDrawMatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgBarRefresh;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLbl;
        private BrightIdeasSoftware.OLVColumn olvColBetOutlet;
        private BrightIdeasSoftware.OLVColumn olvColBetSeqGen;
    }
}