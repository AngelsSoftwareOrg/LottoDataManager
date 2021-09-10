
namespace LottoDataManager.Forms
{
    partial class DrawAndBetMatchFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawAndBetMatchFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxYourBet = new System.Windows.Forms.GroupBox();
            this.tblLyPnlBet = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDrawResult = new System.Windows.Forms.GroupBox();
            this.tblLyPnlDrawResult = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.objListViewBet = new BrightIdeasSoftware.ObjectListView();
            this.olvColDrawDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1.SuspendLayout();
            this.groupBoxYourBet.SuspendLayout();
            this.groupBoxDrawResult.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListViewBet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxYourBet);
            this.panel1.Controls.Add(this.groupBoxDrawResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 227);
            this.panel1.TabIndex = 0;
            // 
            // groupBoxYourBet
            // 
            this.groupBoxYourBet.Controls.Add(this.tblLyPnlBet);
            this.groupBoxYourBet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxYourBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxYourBet.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBoxYourBet.Location = new System.Drawing.Point(0, 115);
            this.groupBoxYourBet.Name = "groupBoxYourBet";
            this.groupBoxYourBet.Size = new System.Drawing.Size(941, 112);
            this.groupBoxYourBet.TabIndex = 1;
            this.groupBoxYourBet.TabStop = false;
            this.groupBoxYourBet.Text = "Your Bet";
            // 
            // tblLyPnlBet
            // 
            this.tblLyPnlBet.ColumnCount = 2;
            this.tblLyPnlBet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLyPnlBet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLyPnlBet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLyPnlBet.Location = new System.Drawing.Point(3, 23);
            this.tblLyPnlBet.Name = "tblLyPnlBet";
            this.tblLyPnlBet.RowCount = 2;
            this.tblLyPnlBet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLyPnlBet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLyPnlBet.Size = new System.Drawing.Size(935, 86);
            this.tblLyPnlBet.TabIndex = 1;
            // 
            // groupBoxDrawResult
            // 
            this.groupBoxDrawResult.Controls.Add(this.tblLyPnlDrawResult);
            this.groupBoxDrawResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDrawResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDrawResult.ForeColor = System.Drawing.Color.Tomato;
            this.groupBoxDrawResult.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDrawResult.Name = "groupBoxDrawResult";
            this.groupBoxDrawResult.Size = new System.Drawing.Size(941, 115);
            this.groupBoxDrawResult.TabIndex = 0;
            this.groupBoxDrawResult.TabStop = false;
            this.groupBoxDrawResult.Text = "Draw Result";
            // 
            // tblLyPnlDrawResult
            // 
            this.tblLyPnlDrawResult.ColumnCount = 2;
            this.tblLyPnlDrawResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLyPnlDrawResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLyPnlDrawResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLyPnlDrawResult.Location = new System.Drawing.Point(3, 23);
            this.tblLyPnlDrawResult.Name = "tblLyPnlDrawResult";
            this.tblLyPnlDrawResult.RowCount = 2;
            this.tblLyPnlDrawResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLyPnlDrawResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLyPnlDrawResult.Size = new System.Drawing.Size(935, 89);
            this.tblLyPnlDrawResult.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.objListViewBet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 227);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(941, 266);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(3, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "* Please select a specific bet to compare to Draw Result";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::LottoDataManager.Properties.Resources.Exit_32;
            this.btnExit.Location = new System.Drawing.Point(744, 202);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(194, 59);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // objListViewBet
            // 
            this.objListViewBet.AllColumns.Add(this.olvColDrawDate);
            this.objListViewBet.AllColumns.Add(this.olvColNum1);
            this.objListViewBet.AllColumns.Add(this.olvColNum2);
            this.objListViewBet.AllColumns.Add(this.olvColNum3);
            this.objListViewBet.AllColumns.Add(this.olvColNum4);
            this.objListViewBet.AllColumns.Add(this.olvColNum5);
            this.objListViewBet.AllColumns.Add(this.olvColNum6);
            this.objListViewBet.CellEditUseWholeCell = false;
            this.objListViewBet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColDrawDate,
            this.olvColNum1,
            this.olvColNum2,
            this.olvColNum3,
            this.olvColNum4,
            this.olvColNum5,
            this.olvColNum6});
            this.objListViewBet.Cursor = System.Windows.Forms.Cursors.Default;
            this.objListViewBet.Dock = System.Windows.Forms.DockStyle.Top;
            this.objListViewBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objListViewBet.FullRowSelect = true;
            this.objListViewBet.GridLines = true;
            this.objListViewBet.HasCollapsibleGroups = false;
            this.objListViewBet.HideSelection = false;
            this.objListViewBet.Location = new System.Drawing.Point(0, 0);
            this.objListViewBet.Name = "objListViewBet";
            this.objListViewBet.ShowGroups = false;
            this.objListViewBet.Size = new System.Drawing.Size(941, 197);
            this.objListViewBet.TabIndex = 0;
            this.objListViewBet.UseCompatibleStateImageBehavior = false;
            this.objListViewBet.View = System.Windows.Forms.View.Details;
            this.objListViewBet.SelectionChanged += new System.EventHandler(this.ObjListViewBet_SelectionChanged);
            // 
            // olvColDrawDate
            // 
            this.olvColDrawDate.AspectName = "GetTargetDrawDateLongFormat";
            this.olvColDrawDate.Groupable = false;
            this.olvColDrawDate.IsEditable = false;
            this.olvColDrawDate.Text = "Bet Draw Date";
            this.olvColDrawDate.Width = 162;
            // 
            // olvColNum1
            // 
            this.olvColNum1.AspectName = "GetNum1";
            this.olvColNum1.IsEditable = false;
            this.olvColNum1.Text = "Num #1";
            this.olvColNum1.Width = 111;
            // 
            // olvColNum2
            // 
            this.olvColNum2.AspectName = "GetNum2";
            this.olvColNum2.IsEditable = false;
            this.olvColNum2.Text = "Num #2";
            this.olvColNum2.Width = 92;
            // 
            // olvColNum3
            // 
            this.olvColNum3.AspectName = "GetNum3";
            this.olvColNum3.IsEditable = false;
            this.olvColNum3.Text = "Num #3";
            this.olvColNum3.Width = 126;
            // 
            // olvColNum4
            // 
            this.olvColNum4.AspectName = "GetNum4";
            this.olvColNum4.IsEditable = false;
            this.olvColNum4.Text = "Num #4";
            this.olvColNum4.Width = 125;
            // 
            // olvColNum5
            // 
            this.olvColNum5.AspectName = "GetNum5";
            this.olvColNum5.IsEditable = false;
            this.olvColNum5.Text = "Num #5";
            this.olvColNum5.Width = 109;
            // 
            // olvColNum6
            // 
            this.olvColNum6.AspectName = "GetNum6";
            this.olvColNum6.IsEditable = false;
            this.olvColNum6.Text = "Num #6";
            this.olvColNum6.Width = 170;
            // 
            // DrawAndBetMatchFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(941, 493);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrawAndBetMatchFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matching your bets to Draw Result";
            this.panel1.ResumeLayout(false);
            this.groupBoxYourBet.ResumeLayout(false);
            this.groupBoxDrawResult.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListViewBet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBoxYourBet;
        private System.Windows.Forms.GroupBox groupBoxDrawResult;
        private System.Windows.Forms.TableLayoutPanel tblLyPnlDrawResult;
        private System.Windows.Forms.TableLayoutPanel tblLyPnlBet;
        private BrightIdeasSoftware.ObjectListView objListViewBet;
        private System.Windows.Forms.Button btnExit;
        private BrightIdeasSoftware.OLVColumn olvColDrawDate;
        private BrightIdeasSoftware.OLVColumn olvColNum1;
        private BrightIdeasSoftware.OLVColumn olvColNum2;
        private BrightIdeasSoftware.OLVColumn olvColNum3;
        private BrightIdeasSoftware.OLVColumn olvColNum4;
        private BrightIdeasSoftware.OLVColumn olvColNum5;
        private BrightIdeasSoftware.OLVColumn olvColNum6;
        private System.Windows.Forms.Label label1;
    }
}