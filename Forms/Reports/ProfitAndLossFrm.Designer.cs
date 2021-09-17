
namespace LottoDataManager.Forms.Reports
{
    partial class ProfitAndLossFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfitAndLossFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbGameModes = new System.Windows.Forms.GroupBox();
            this.cblGameModes = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLblCheckAll = new System.Windows.Forms.LinkLabel();
            this.linkLblReset = new System.Windows.Forms.LinkLabel();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbGameModes.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbGameModes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 236);
            this.panel1.TabIndex = 0;
            // 
            // gbGameModes
            // 
            this.gbGameModes.Controls.Add(this.cblGameModes);
            this.gbGameModes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbGameModes.Location = new System.Drawing.Point(0, 0);
            this.gbGameModes.Name = "gbGameModes";
            this.gbGameModes.Size = new System.Drawing.Size(547, 236);
            this.gbGameModes.TabIndex = 0;
            this.gbGameModes.TabStop = false;
            this.gbGameModes.Text = "Select your Game Mode to include on the report";
            // 
            // cblGameModes
            // 
            this.cblGameModes.ColumnWidth = 2;
            this.cblGameModes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cblGameModes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cblGameModes.FormattingEnabled = true;
            this.cblGameModes.HorizontalScrollbar = true;
            this.cblGameModes.Location = new System.Drawing.Point(3, 18);
            this.cblGameModes.Name = "cblGameModes";
            this.cblGameModes.Size = new System.Drawing.Size(541, 215);
            this.cblGameModes.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.linkLblCheckAll);
            this.panel2.Controls.Add(this.linkLblReset);
            this.panel2.Controls.Add(this.btnRunReport);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 236);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 69);
            this.panel2.TabIndex = 1;
            // 
            // linkLblCheckAll
            // 
            this.linkLblCheckAll.AutoSize = true;
            this.linkLblCheckAll.Location = new System.Drawing.Point(12, 13);
            this.linkLblCheckAll.Name = "linkLblCheckAll";
            this.linkLblCheckAll.Size = new System.Drawing.Size(66, 17);
            this.linkLblCheckAll.TabIndex = 1;
            this.linkLblCheckAll.TabStop = true;
            this.linkLblCheckAll.Text = "Check All";
            this.linkLblCheckAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblCheckAll_LinkClicked);
            // 
            // linkLblReset
            // 
            this.linkLblReset.AutoSize = true;
            this.linkLblReset.Location = new System.Drawing.Point(12, 39);
            this.linkLblReset.Name = "linkLblReset";
            this.linkLblReset.Size = new System.Drawing.Size(45, 17);
            this.linkLblReset.TabIndex = 2;
            this.linkLblReset.TabStop = true;
            this.linkLblReset.Text = "Reset";
            this.linkLblReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblUnCheckAll_LinkClicked);
            // 
            // btnRunReport
            // 
            this.btnRunReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunReport.Image = global::LottoDataManager.Properties.Resources.statistic_32;
            this.btnRunReport.Location = new System.Drawing.Point(187, 2);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(177, 63);
            this.btnRunReport.TabIndex = 1;
            this.btnRunReport.Text = "Run Report";
            this.btnRunReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRunReport.UseVisualStyleBackColor = true;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::LottoDataManager.Properties.Resources.Exit_32;
            this.btnExit.Location = new System.Drawing.Point(367, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(177, 63);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ProfitAndLossFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(547, 305);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ProfitAndLossFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profit And Loss Reports";
            this.Load += new System.EventHandler(this.ProfitAndLossFrm_Load);
            this.panel1.ResumeLayout(false);
            this.gbGameModes.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.GroupBox gbGameModes;
        private System.Windows.Forms.CheckedListBox cblGameModes;
        private System.Windows.Forms.LinkLabel linkLblCheckAll;
        private System.Windows.Forms.LinkLabel linkLblReset;
    }
}