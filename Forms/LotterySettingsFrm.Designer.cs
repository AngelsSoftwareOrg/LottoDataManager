
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Lottery Outlet");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Lottery Winning Prizes/Amount");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Lottery Sequence Generator");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Lottery Schedule");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LotterySettingsFrm));
            this.panelMainTop = new System.Windows.Forms.Panel();
            this.mainPanelBottom = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExit = new System.Windows.Forms.Button();
            this.mainMenuTreeView = new System.Windows.Forms.TreeView();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.lotteryOutletTabPage = new System.Windows.Forms.TabPage();
            this.lotteryWinPrizeTabPage = new System.Windows.Forms.TabPage();
            this.lotterySeqGenTabPage = new System.Windows.Forms.TabPage();
            this.lotterySchedTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelMainTop.SuspendLayout();
            this.mainPanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.lotteryOutletTabPage.SuspendLayout();
            this.lotteryWinPrizeTabPage.SuspendLayout();
            this.lotterySeqGenTabPage.SuspendLayout();
            this.lotterySchedTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainTop
            // 
            this.panelMainTop.Controls.Add(this.splitContainer1);
            this.panelMainTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainTop.Location = new System.Drawing.Point(0, 0);
            this.panelMainTop.Name = "panelMainTop";
            this.panelMainTop.Size = new System.Drawing.Size(944, 483);
            this.panelMainTop.TabIndex = 0;
            // 
            // mainPanelBottom
            // 
            this.mainPanelBottom.Controls.Add(this.btnExit);
            this.mainPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainPanelBottom.Location = new System.Drawing.Point(0, 483);
            this.mainPanelBottom.Name = "mainPanelBottom";
            this.mainPanelBottom.Size = new System.Drawing.Size(944, 63);
            this.mainPanelBottom.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer1.Size = new System.Drawing.Size(944, 483);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(821, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(119, 54);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // mainMenuTreeView
            // 
            this.mainMenuTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuTreeView.Location = new System.Drawing.Point(0, 0);
            this.mainMenuTreeView.Name = "mainMenuTreeView";
            treeNode1.Name = "nodeLottoOutlet";
            treeNode1.Text = "Lottery Outlet";
            treeNode2.Name = "nodeLotteryWinComb";
            treeNode2.Text = "Lottery Winning Prizes/Amount";
            treeNode3.Name = "nodeLottoSeqGen";
            treeNode3.Text = "Lottery Sequence Generator";
            treeNode4.Name = "nodeLottoSched";
            treeNode4.Text = "Lottery Schedule";
            this.mainMenuTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.mainMenuTreeView.Size = new System.Drawing.Size(226, 483);
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
            this.mainTabControl.Size = new System.Drawing.Size(714, 483);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.TabStop = false;
            // 
            // lotteryOutletTabPage
            // 
            this.lotteryOutletTabPage.Controls.Add(this.label1);
            this.lotteryOutletTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotteryOutletTabPage.Name = "lotteryOutletTabPage";
            this.lotteryOutletTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lotteryOutletTabPage.Size = new System.Drawing.Size(705, 454);
            this.lotteryOutletTabPage.TabIndex = 0;
            this.lotteryOutletTabPage.Text = "Lottery Outlet";
            this.lotteryOutletTabPage.UseVisualStyleBackColor = true;
            // 
            // lotteryWinPrizeTabPage
            // 
            this.lotteryWinPrizeTabPage.Controls.Add(this.label2);
            this.lotteryWinPrizeTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotteryWinPrizeTabPage.Name = "lotteryWinPrizeTabPage";
            this.lotteryWinPrizeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lotteryWinPrizeTabPage.Size = new System.Drawing.Size(706, 454);
            this.lotteryWinPrizeTabPage.TabIndex = 1;
            this.lotteryWinPrizeTabPage.Text = "Lottery Winning Prize/Amount";
            this.lotteryWinPrizeTabPage.UseVisualStyleBackColor = true;
            // 
            // lotterySeqGenTabPage
            // 
            this.lotterySeqGenTabPage.Controls.Add(this.label3);
            this.lotterySeqGenTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotterySeqGenTabPage.Name = "lotterySeqGenTabPage";
            this.lotterySeqGenTabPage.Size = new System.Drawing.Size(706, 454);
            this.lotterySeqGenTabPage.TabIndex = 2;
            this.lotterySeqGenTabPage.Text = "Lottery Sequence Generator";
            this.lotterySeqGenTabPage.UseVisualStyleBackColor = true;
            // 
            // lotterySchedTabPage
            // 
            this.lotterySchedTabPage.Controls.Add(this.label4);
            this.lotterySchedTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotterySchedTabPage.Name = "lotterySchedTabPage";
            this.lotterySchedTabPage.Size = new System.Drawing.Size(706, 454);
            this.lotterySchedTabPage.TabIndex = 3;
            this.lotterySchedTabPage.Text = "Lottery Schedule";
            this.lotterySchedTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lottery Outlet Settings";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lottery Sequence Generator Settings";
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
            // LotterySettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(944, 546);
            this.Controls.Add(this.panelMainTop);
            this.Controls.Add(this.mainPanelBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "LotterySettingsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lottery Settings";
            this.Load += new System.EventHandler(this.LotterySettingsFrm_Load);
            this.panelMainTop.ResumeLayout(false);
            this.mainPanelBottom.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.lotteryOutletTabPage.ResumeLayout(false);
            this.lotteryOutletTabPage.PerformLayout();
            this.lotteryWinPrizeTabPage.ResumeLayout(false);
            this.lotteryWinPrizeTabPage.PerformLayout();
            this.lotterySeqGenTabPage.ResumeLayout(false);
            this.lotterySeqGenTabPage.PerformLayout();
            this.lotterySchedTabPage.ResumeLayout(false);
            this.lotterySchedTabPage.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}