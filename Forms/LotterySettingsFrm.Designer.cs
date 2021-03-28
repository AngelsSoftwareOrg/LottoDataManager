
namespace LottoDataManager.Forms
{
    partial class LotterySettingsFrm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Lottery Outlet");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Lottery Winning Prizes/Amount");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Lottery Sequence Generator");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Lottery Schedule");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LotterySettingsFrm));
            this.panelMainTop = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mainMenuTreeView = new System.Windows.Forms.TreeView();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.lotteryOutletTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvLotteryOutlets = new System.Windows.Forms.ListView();
            this.colHeaderDescrption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLotteryOutletRemove = new System.Windows.Forms.Button();
            this.lblLotteryOutletDescLen = new System.Windows.Forms.Label();
            this.btnSaveModDesc = new System.Windows.Forms.Button();
            this.btnSaveLotteryOutlet = new System.Windows.Forms.Button();
            this.txtOutletCodeDesc = new System.Windows.Forms.TextBox();
            this.lotteryWinPrizeTabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lotterySeqGenTabPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lotterySchedTabPage = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.mainPanelBottom = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.imageListForTreeView = new System.Windows.Forms.ImageList(this.components);
            this.panelMainTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.lotteryOutletTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.lotteryWinPrizeTabPage.SuspendLayout();
            this.lotterySeqGenTabPage.SuspendLayout();
            this.lotterySchedTabPage.SuspendLayout();
            this.mainPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainTop
            // 
            this.panelMainTop.Controls.Add(this.splitContainer1);
            this.panelMainTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainTop.Location = new System.Drawing.Point(0, 0);
            this.panelMainTop.Name = "panelMainTop";
            this.panelMainTop.Size = new System.Drawing.Size(1067, 473);
            this.panelMainTop.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mainMenuTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mainTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 473);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 0;
            // 
            // mainMenuTreeView
            // 
            this.mainMenuTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuTreeView.ImageIndex = 0;
            this.mainMenuTreeView.ImageList = this.imageListForTreeView;
            this.mainMenuTreeView.Indent = 20;
            this.mainMenuTreeView.ItemHeight = 40;
            this.mainMenuTreeView.Location = new System.Drawing.Point(0, 0);
            this.mainMenuTreeView.Name = "mainMenuTreeView";
            treeNode1.Name = "nodeLottoOutlet";
            treeNode1.SelectedImageKey = "outlet_32px.png";
            treeNode1.Text = "Lottery Outlet";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "nodeLotteryWinComb";
            treeNode2.SelectedImageKey = "money_32px.png";
            treeNode2.Text = "Lottery Winning Prizes/Amount";
            treeNode3.ImageKey = "Star5_32x.png";
            treeNode3.Name = "nodeLottoSeqGen";
            treeNode3.SelectedImageKey = "Star5_32x.png";
            treeNode3.Text = "Lottery Sequence Generator";
            treeNode4.ImageKey = "schedule_32px.png";
            treeNode4.Name = "nodeLottoSched";
            treeNode4.SelectedImageKey = "schedule_32px.png";
            treeNode4.Text = "Lottery Schedule";
            this.mainMenuTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.mainMenuTreeView.SelectedImageIndex = 0;
            this.mainMenuTreeView.ShowRootLines = false;
            this.mainMenuTreeView.Size = new System.Drawing.Size(268, 473);
            this.mainMenuTreeView.StateImageList = this.imageListForTreeView;
            this.mainMenuTreeView.TabIndex = 0;
            this.mainMenuTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mainMenuTreeView_AfterSelect);
            this.mainMenuTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mainMenuTreeView_NodeMouseClick);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.lotteryOutletTabPage);
            this.mainTabControl.Controls.Add(this.lotteryWinPrizeTabPage);
            this.mainTabControl.Controls.Add(this.lotterySeqGenTabPage);
            this.mainTabControl.Controls.Add(this.lotterySchedTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(795, 473);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.TabStop = false;
            // 
            // lotteryOutletTabPage
            // 
            this.lotteryOutletTabPage.Controls.Add(this.panel2);
            this.lotteryOutletTabPage.Controls.Add(this.panel1);
            this.lotteryOutletTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotteryOutletTabPage.Name = "lotteryOutletTabPage";
            this.lotteryOutletTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lotteryOutletTabPage.Size = new System.Drawing.Size(787, 444);
            this.lotteryOutletTabPage.TabIndex = 0;
            this.lotteryOutletTabPage.Text = "Lottery Outlet";
            this.lotteryOutletTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvLotteryOutlets);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(781, 289);
            this.panel2.TabIndex = 0;
            // 
            // lvLotteryOutlets
            // 
            this.lvLotteryOutlets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderDescrption});
            this.lvLotteryOutlets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLotteryOutlets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLotteryOutlets.FullRowSelect = true;
            this.lvLotteryOutlets.GridLines = true;
            this.lvLotteryOutlets.HideSelection = false;
            this.lvLotteryOutlets.Location = new System.Drawing.Point(0, 0);
            this.lvLotteryOutlets.MultiSelect = false;
            this.lvLotteryOutlets.Name = "lvLotteryOutlets";
            this.lvLotteryOutlets.Size = new System.Drawing.Size(781, 289);
            this.lvLotteryOutlets.TabIndex = 0;
            this.lvLotteryOutlets.UseCompatibleStateImageBehavior = false;
            this.lvLotteryOutlets.View = System.Windows.Forms.View.Details;
            this.lvLotteryOutlets.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvLotteryOutlets_ColumnClick);
            this.lvLotteryOutlets.SelectedIndexChanged += new System.EventHandler(this.lvLotteryOutlets_SelectedIndexChanged);
            // 
            // colHeaderDescrption
            // 
            this.colHeaderDescrption.Text = "Description";
            this.colHeaderDescrption.Width = 462;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLotteryOutletRemove);
            this.panel1.Controls.Add(this.lblLotteryOutletDescLen);
            this.panel1.Controls.Add(this.btnSaveModDesc);
            this.panel1.Controls.Add(this.btnSaveLotteryOutlet);
            this.panel1.Controls.Add(this.txtOutletCodeDesc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 292);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 149);
            this.panel1.TabIndex = 0;
            // 
            // btnLotteryOutletRemove
            // 
            this.btnLotteryOutletRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLotteryOutletRemove.Image = global::LottoDataManager.Properties.Resources.Trash_32x;
            this.btnLotteryOutletRemove.Location = new System.Drawing.Point(722, 87);
            this.btnLotteryOutletRemove.Name = "btnLotteryOutletRemove";
            this.btnLotteryOutletRemove.Size = new System.Drawing.Size(56, 57);
            this.btnLotteryOutletRemove.TabIndex = 4;
            this.btnLotteryOutletRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLotteryOutletRemove.UseVisualStyleBackColor = true;
            this.btnLotteryOutletRemove.Click += new System.EventHandler(this.btnLotteryOutletRemove_Click);
            // 
            // lblLotteryOutletDescLen
            // 
            this.lblLotteryOutletDescLen.AutoSize = true;
            this.lblLotteryOutletDescLen.Location = new System.Drawing.Point(3, 87);
            this.lblLotteryOutletDescLen.Name = "lblLotteryOutletDescLen";
            this.lblLotteryOutletDescLen.Size = new System.Drawing.Size(81, 17);
            this.lblLotteryOutletDescLen.TabIndex = 3;
            this.lblLotteryOutletDescLen.Text = "(255 chars)";
            // 
            // btnSaveModDesc
            // 
            this.btnSaveModDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveModDesc.Image = global::LottoDataManager.Properties.Resources.Edit_01_32x;
            this.btnSaveModDesc.Location = new System.Drawing.Point(244, 87);
            this.btnSaveModDesc.Name = "btnSaveModDesc";
            this.btnSaveModDesc.Size = new System.Drawing.Size(271, 57);
            this.btnSaveModDesc.TabIndex = 2;
            this.btnSaveModDesc.Text = "Save modified outlet description";
            this.btnSaveModDesc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveModDesc.UseVisualStyleBackColor = true;
            this.btnSaveModDesc.Click += new System.EventHandler(this.btnSaveModDesc_Click);
            // 
            // btnSaveLotteryOutlet
            // 
            this.btnSaveLotteryOutlet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveLotteryOutlet.Image = global::LottoDataManager.Properties.Resources.save_v1_32;
            this.btnSaveLotteryOutlet.Location = new System.Drawing.Point(521, 87);
            this.btnSaveLotteryOutlet.Name = "btnSaveLotteryOutlet";
            this.btnSaveLotteryOutlet.Size = new System.Drawing.Size(198, 57);
            this.btnSaveLotteryOutlet.TabIndex = 1;
            this.btnSaveLotteryOutlet.Text = "Save as New Outlet";
            this.btnSaveLotteryOutlet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveLotteryOutlet.UseVisualStyleBackColor = true;
            this.btnSaveLotteryOutlet.Click += new System.EventHandler(this.btnSaveLotteryOutlet_Click);
            // 
            // txtOutletCodeDesc
            // 
            this.txtOutletCodeDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtOutletCodeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutletCodeDesc.Location = new System.Drawing.Point(0, 0);
            this.txtOutletCodeDesc.Multiline = true;
            this.txtOutletCodeDesc.Name = "txtOutletCodeDesc";
            this.txtOutletCodeDesc.Size = new System.Drawing.Size(781, 81);
            this.txtOutletCodeDesc.TabIndex = 0;
            this.txtOutletCodeDesc.TextChanged += new System.EventHandler(this.txtOutletCodeDesc_TextChanged);
            // 
            // lotteryWinPrizeTabPage
            // 
            this.lotteryWinPrizeTabPage.Controls.Add(this.label2);
            this.lotteryWinPrizeTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotteryWinPrizeTabPage.Name = "lotteryWinPrizeTabPage";
            this.lotteryWinPrizeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lotteryWinPrizeTabPage.Size = new System.Drawing.Size(787, 444);
            this.lotteryWinPrizeTabPage.TabIndex = 1;
            this.lotteryWinPrizeTabPage.Text = "Lottery Winning Prize/Amount";
            this.lotteryWinPrizeTabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lottery Winning Prize/Amount Settings";
            // 
            // lotterySeqGenTabPage
            // 
            this.lotterySeqGenTabPage.Controls.Add(this.label3);
            this.lotterySeqGenTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotterySeqGenTabPage.Name = "lotterySeqGenTabPage";
            this.lotterySeqGenTabPage.Size = new System.Drawing.Size(779, 444);
            this.lotterySeqGenTabPage.TabIndex = 2;
            this.lotterySeqGenTabPage.Text = "Lottery Sequence Generator";
            this.lotterySeqGenTabPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lottery Sequence Generator Settings";
            // 
            // lotterySchedTabPage
            // 
            this.lotterySchedTabPage.Controls.Add(this.label4);
            this.lotterySchedTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotterySchedTabPage.Name = "lotterySchedTabPage";
            this.lotterySchedTabPage.Size = new System.Drawing.Size(779, 444);
            this.lotterySchedTabPage.TabIndex = 3;
            this.lotterySchedTabPage.Text = "Lottery Schedule";
            this.lotterySchedTabPage.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lottery Schedule Settings";
            // 
            // mainPanelBottom
            // 
            this.mainPanelBottom.Controls.Add(this.btnExit);
            this.mainPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainPanelBottom.Location = new System.Drawing.Point(0, 473);
            this.mainPanelBottom.Name = "mainPanelBottom";
            this.mainPanelBottom.Size = new System.Drawing.Size(1067, 63);
            this.mainPanelBottom.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::LottoDataManager.Properties.Resources.Exit_32;
            this.btnExit.Location = new System.Drawing.Point(940, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(119, 57);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // imageListForTreeView
            // 
            this.imageListForTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListForTreeView.ImageStream")));
            this.imageListForTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListForTreeView.Images.SetKeyName(0, "outlet_32px.png");
            this.imageListForTreeView.Images.SetKeyName(1, "money_32px.png");
            this.imageListForTreeView.Images.SetKeyName(2, "schedule_32px.png");
            this.imageListForTreeView.Images.SetKeyName(3, "Star5_32x.png");
            // 
            // LotterySettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1067, 536);
            this.Controls.Add(this.panelMainTop);
            this.Controls.Add(this.mainPanelBottom);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "LotterySettingsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lottery Settings";
            this.Load += new System.EventHandler(this.LotterySettingsFrm_Load);
            this.panelMainTop.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.lotteryOutletTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.lotteryWinPrizeTabPage.ResumeLayout(false);
            this.lotteryWinPrizeTabPage.PerformLayout();
            this.lotterySeqGenTabPage.ResumeLayout(false);
            this.lotterySeqGenTabPage.PerformLayout();
            this.lotterySchedTabPage.ResumeLayout(false);
            this.lotterySchedTabPage.PerformLayout();
            this.mainPanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainTop;
        private System.Windows.Forms.Panel mainPanelBottom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TreeView mainMenuTreeView;
        private System.Windows.Forms.TabPage lotteryOutletTabPage;
        private System.Windows.Forms.TabPage lotteryWinPrizeTabPage;
        private System.Windows.Forms.TabPage lotterySeqGenTabPage;
        private System.Windows.Forms.TabPage lotterySchedTabPage;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvLotteryOutlets;
        private System.Windows.Forms.ColumnHeader colHeaderDescrption;
        private System.Windows.Forms.TextBox txtOutletCodeDesc;
        private System.Windows.Forms.Button btnSaveLotteryOutlet;
        private System.Windows.Forms.Button btnSaveModDesc;
        private System.Windows.Forms.Label lblLotteryOutletDescLen;
        private System.Windows.Forms.Button btnLotteryOutletRemove;
        private System.Windows.Forms.ImageList imageListForTreeView;
    }
}