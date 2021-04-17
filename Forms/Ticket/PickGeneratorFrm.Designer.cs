
using BrightIdeasSoftware;

namespace LottoDataManager.Forms
{
    partial class PickGeneratorFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickGeneratorFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpbxParam = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tblPnlLayParams = new System.Windows.Forms.TableLayoutPanel();
            this.grpbxGenType = new System.Windows.Forms.GroupBox();
            this.lvGenType = new BrightIdeasSoftware.ObjectListView();
            this.olvColDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.grpbxActions = new System.Windows.Forms.GroupBox();
            this.btnClearSel = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpbxOutput = new System.Windows.Forms.GroupBox();
            this.lvGenSeq = new System.Windows.Forms.ListView();
            this.lvColSeqIdx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvColSeq1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvColSeq2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvColSeq3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvColSeq4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvColSeq5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvColSeq6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxMenuBet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpbxFinalActions = new System.Windows.Forms.GroupBox();
            this.linkUncheckAll = new System.Windows.Forms.LinkLabel();
            this.btnAddSelected = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grpbxParam.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpbxGenType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvGenType)).BeginInit();
            this.grpbxActions.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpbxOutput.SuspendLayout();
            this.ctxMenuBet.SuspendLayout();
            this.grpbxFinalActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.grpbxParam);
            this.panel1.Controls.Add(this.grpbxGenType);
            this.panel1.Controls.Add(this.grpbxActions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 573);
            this.panel1.TabIndex = 0;
            // 
            // grpbxParam
            // 
            this.grpbxParam.Controls.Add(this.panel3);
            this.grpbxParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxParam.ForeColor = System.Drawing.Color.Navy;
            this.grpbxParam.Location = new System.Drawing.Point(0, 264);
            this.grpbxParam.Name = "grpbxParam";
            this.grpbxParam.Size = new System.Drawing.Size(576, 205);
            this.grpbxParam.TabIndex = 1;
            this.grpbxParam.TabStop = false;
            this.grpbxParam.Text = "Step 2: Enter Parameter for the Chosen Generator";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.tblPnlLayParams);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(570, 182);
            this.panel3.TabIndex = 0;
            // 
            // tblPnlLayParams
            // 
            this.tblPnlLayParams.AutoSize = true;
            this.tblPnlLayParams.ColumnCount = 2;
            this.tblPnlLayParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPnlLayParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPnlLayParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPnlLayParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblPnlLayParams.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tblPnlLayParams.Location = new System.Drawing.Point(0, 0);
            this.tblPnlLayParams.Name = "tblPnlLayParams";
            this.tblPnlLayParams.RowCount = 2;
            this.tblPnlLayParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPnlLayParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPnlLayParams.Size = new System.Drawing.Size(570, 182);
            this.tblPnlLayParams.TabIndex = 0;
            // 
            // grpbxGenType
            // 
            this.grpbxGenType.Controls.Add(this.lvGenType);
            this.grpbxGenType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpbxGenType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpbxGenType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxGenType.ForeColor = System.Drawing.Color.Navy;
            this.grpbxGenType.Location = new System.Drawing.Point(0, 0);
            this.grpbxGenType.Name = "grpbxGenType";
            this.grpbxGenType.Size = new System.Drawing.Size(576, 264);
            this.grpbxGenType.TabIndex = 0;
            this.grpbxGenType.TabStop = false;
            this.grpbxGenType.Text = "Step 1. Choose Generator Type";
            // 
            // lvGenType
            // 
            this.lvGenType.AllColumns.Add(this.olvColDesc);
            this.lvGenType.CellEditUseWholeCell = false;
            this.lvGenType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColDesc});
            this.lvGenType.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvGenType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGenType.FullRowSelect = true;
            this.lvGenType.GridLines = true;
            this.lvGenType.HasCollapsibleGroups = false;
            this.lvGenType.HideSelection = false;
            this.lvGenType.Location = new System.Drawing.Point(3, 20);
            this.lvGenType.MultiSelect = false;
            this.lvGenType.Name = "lvGenType";
            this.lvGenType.ShowGroups = false;
            this.lvGenType.Size = new System.Drawing.Size(570, 241);
            this.lvGenType.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvGenType.TabIndex = 0;
            this.lvGenType.UseCompatibleStateImageBehavior = false;
            this.lvGenType.View = System.Windows.Forms.View.Details;
            this.lvGenType.SelectionChanged += new System.EventHandler(this.lvGenType_SelectionChanged);
            // 
            // olvColDesc
            // 
            this.olvColDesc.AspectName = "GetDescription";
            this.olvColDesc.Groupable = false;
            this.olvColDesc.Text = "Description";
            this.olvColDesc.Width = 600;
            // 
            // grpbxActions
            // 
            this.grpbxActions.Controls.Add(this.btnClearSel);
            this.grpbxActions.Controls.Add(this.btnGenerate);
            this.grpbxActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpbxActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxActions.ForeColor = System.Drawing.Color.Navy;
            this.grpbxActions.Location = new System.Drawing.Point(0, 469);
            this.grpbxActions.Name = "grpbxActions";
            this.grpbxActions.Size = new System.Drawing.Size(576, 100);
            this.grpbxActions.TabIndex = 2;
            this.grpbxActions.TabStop = false;
            this.grpbxActions.Text = "Step 3: Actions";
            // 
            // btnClearSel
            // 
            this.btnClearSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearSel.Image = global::LottoDataManager.Properties.Resources.erase_32px;
            this.btnClearSel.Location = new System.Drawing.Point(231, 23);
            this.btnClearSel.Name = "btnClearSel";
            this.btnClearSel.Size = new System.Drawing.Size(181, 67);
            this.btnClearSel.TabIndex = 1;
            this.btnClearSel.Text = "Clear Selections";
            this.btnClearSel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearSel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearSel.UseVisualStyleBackColor = true;
            this.btnClearSel.Click += new System.EventHandler(this.btnClearSel_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGenerate.Image = global::LottoDataManager.Properties.Resources.Star5_32x;
            this.btnGenerate.Location = new System.Drawing.Point(419, 23);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(143, 67);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.grpbxOutput);
            this.panel2.Controls.Add(this.grpbxFinalActions);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(580, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 573);
            this.panel2.TabIndex = 1;
            // 
            // grpbxOutput
            // 
            this.grpbxOutput.Controls.Add(this.lvGenSeq);
            this.grpbxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbxOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxOutput.ForeColor = System.Drawing.Color.Navy;
            this.grpbxOutput.Location = new System.Drawing.Point(0, 0);
            this.grpbxOutput.Name = "grpbxOutput";
            this.grpbxOutput.Size = new System.Drawing.Size(542, 469);
            this.grpbxOutput.TabIndex = 0;
            this.grpbxOutput.TabStop = false;
            this.grpbxOutput.Text = "Step 4: Output";
            // 
            // lvGenSeq
            // 
            this.lvGenSeq.CheckBoxes = true;
            this.lvGenSeq.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvColSeqIdx,
            this.lvColSeq1,
            this.lvColSeq2,
            this.lvColSeq3,
            this.lvColSeq4,
            this.lvColSeq5,
            this.lvColSeq6});
            this.lvGenSeq.ContextMenuStrip = this.ctxMenuBet;
            this.lvGenSeq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGenSeq.FullRowSelect = true;
            this.lvGenSeq.GridLines = true;
            this.lvGenSeq.HideSelection = false;
            this.lvGenSeq.Location = new System.Drawing.Point(3, 20);
            this.lvGenSeq.Name = "lvGenSeq";
            this.lvGenSeq.Size = new System.Drawing.Size(536, 446);
            this.lvGenSeq.TabIndex = 0;
            this.lvGenSeq.UseCompatibleStateImageBehavior = false;
            this.lvGenSeq.View = System.Windows.Forms.View.Details;
            this.lvGenSeq.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvGenSeq_ColumnClick);
            // 
            // lvColSeqIdx
            // 
            this.lvColSeqIdx.Text = "#";
            // 
            // lvColSeq1
            // 
            this.lvColSeq1.Text = "#1";
            // 
            // lvColSeq2
            // 
            this.lvColSeq2.Text = "#2";
            // 
            // lvColSeq3
            // 
            this.lvColSeq3.Text = "#3";
            // 
            // lvColSeq4
            // 
            this.lvColSeq4.Text = "#4";
            // 
            // lvColSeq5
            // 
            this.lvColSeq5.Text = "#5";
            // 
            // lvColSeq6
            // 
            this.lvColSeq6.Text = "#6";
            // 
            // ctxMenuBet
            // 
            this.ctxMenuBet.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenuBet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkToolStripMenuItem,
            this.uncheckAllToolStripMenuItem,
            this.addBetToolStripMenuItem});
            this.ctxMenuBet.Name = "ctxMenuBet";
            this.ctxMenuBet.Size = new System.Drawing.Size(156, 76);
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.checkToolStripMenuItem.Text = "Check";
            this.checkToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
            // 
            // uncheckAllToolStripMenuItem
            // 
            this.uncheckAllToolStripMenuItem.Name = "uncheckAllToolStripMenuItem";
            this.uncheckAllToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.uncheckAllToolStripMenuItem.Text = "Uncheck All";
            this.uncheckAllToolStripMenuItem.Click += new System.EventHandler(this.uncheckAllToolStripMenuItem_Click);
            // 
            // addBetToolStripMenuItem
            // 
            this.addBetToolStripMenuItem.Name = "addBetToolStripMenuItem";
            this.addBetToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.addBetToolStripMenuItem.Text = "Add Bet";
            this.addBetToolStripMenuItem.Click += new System.EventHandler(this.addBetToolStripMenuItem_Click);
            // 
            // grpbxFinalActions
            // 
            this.grpbxFinalActions.Controls.Add(this.linkUncheckAll);
            this.grpbxFinalActions.Controls.Add(this.btnAddSelected);
            this.grpbxFinalActions.Controls.Add(this.btnExit);
            this.grpbxFinalActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpbxFinalActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxFinalActions.ForeColor = System.Drawing.Color.Navy;
            this.grpbxFinalActions.Location = new System.Drawing.Point(0, 469);
            this.grpbxFinalActions.Name = "grpbxFinalActions";
            this.grpbxFinalActions.Size = new System.Drawing.Size(542, 100);
            this.grpbxFinalActions.TabIndex = 1;
            this.grpbxFinalActions.TabStop = false;
            this.grpbxFinalActions.Text = "Step 5: Final Action";
            // 
            // linkUncheckAll
            // 
            this.linkUncheckAll.AutoSize = true;
            this.linkUncheckAll.Location = new System.Drawing.Point(6, 46);
            this.linkUncheckAll.Name = "linkUncheckAll";
            this.linkUncheckAll.Size = new System.Drawing.Size(86, 18);
            this.linkUncheckAll.TabIndex = 2;
            this.linkUncheckAll.TabStop = true;
            this.linkUncheckAll.Text = "Uncheck All";
            this.linkUncheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUncheckAll_LinkClicked);
            // 
            // btnAddSelected
            // 
            this.btnAddSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSelected.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSelected.ForeColor = System.Drawing.Color.Black;
            this.btnAddSelected.Image = global::LottoDataManager.Properties.Resources.money_32px;
            this.btnAddSelected.Location = new System.Drawing.Point(183, 21);
            this.btnAddSelected.Name = "btnAddSelected";
            this.btnAddSelected.Size = new System.Drawing.Size(201, 69);
            this.btnAddSelected.TabIndex = 1;
            this.btnAddSelected.Text = "Place checked as bet";
            this.btnAddSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSelected.UseVisualStyleBackColor = true;
            this.btnAddSelected.Click += new System.EventHandler(this.btnAddSelected_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Image = global::LottoDataManager.Properties.Resources.Exit_32;
            this.btnExit.Location = new System.Drawing.Point(390, 21);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(142, 69);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // PickGeneratorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1126, 573);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PickGeneratorFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pick Generator";
            this.Load += new System.EventHandler(this.PickGeneratorFrm_Load);
            this.panel1.ResumeLayout(false);
            this.grpbxParam.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.grpbxGenType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvGenType)).EndInit();
            this.grpbxActions.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grpbxOutput.ResumeLayout(false);
            this.ctxMenuBet.ResumeLayout(false);
            this.grpbxFinalActions.ResumeLayout(false);
            this.grpbxFinalActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpbxGenType;
        private System.Windows.Forms.GroupBox grpbxParam;
        private System.Windows.Forms.GroupBox grpbxActions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tblPnlLayParams;
        private System.Windows.Forms.GroupBox grpbxOutput;
        private System.Windows.Forms.GroupBox grpbxFinalActions;
        private System.Windows.Forms.Button btnClearSel;
        private System.Windows.Forms.Button btnGenerate;
        private ObjectListView lvGenType;
        private OLVColumn olvColDesc;
        private System.Windows.Forms.ListView lvGenSeq;
        private System.Windows.Forms.ColumnHeader lvColSeqIdx;
        private System.Windows.Forms.ColumnHeader lvColSeq1;
        private System.Windows.Forms.ColumnHeader lvColSeq2;
        private System.Windows.Forms.ColumnHeader lvColSeq3;
        private System.Windows.Forms.ColumnHeader lvColSeq4;
        private System.Windows.Forms.ColumnHeader lvColSeq5;
        private System.Windows.Forms.ColumnHeader lvColSeq6;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddSelected;
        private System.Windows.Forms.LinkLabel linkUncheckAll;
        private System.Windows.Forms.ContextMenuStrip ctxMenuBet;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBetToolStripMenuItem;
    }
}