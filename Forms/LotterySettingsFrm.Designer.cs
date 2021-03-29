
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
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Lottery Outlet");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Lottery Winning Prizes/Amount");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Lottery Sequence Generator");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Lottery Schedule");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LotterySettingsFrm));
            this.panelMainTop = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mainMenuTreeView = new System.Windows.Forms.TreeView();
            this.imageListForTreeView = new System.Windows.Forms.ImageList(this.components);
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.lotteryOutletTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvLotteryOutlets = new System.Windows.Forms.ListView();
            this.colHeaderDescrption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLotteryOutletDescLen = new System.Windows.Forms.Label();
            this.txtOutletCodeDesc = new System.Windows.Forms.TextBox();
            this.lotteryWinPrizeTabPage = new System.Windows.Forms.TabPage();
            this.lotterySeqGenTabPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lotterySchedTabPage = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.mainPanelBottom = new System.Windows.Forms.Panel();
            this.gpbLWPA1 = new System.Windows.Forms.GroupBox();
            this.cmbLWPAGameMode = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLWPASelectedGame = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet1 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet2 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet3 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet4 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet5 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtbLWPABet1 = new System.Windows.Forms.NumericUpDown();
            this.txtbLWPABet2 = new System.Windows.Forms.NumericUpDown();
            this.txtbLWPABet3 = new System.Windows.Forms.NumericUpDown();
            this.txtbLWPABet4 = new System.Windows.Forms.NumericUpDown();
            this.txtbLWPABet5 = new System.Windows.Forms.NumericUpDown();
            this.txtbLWPABet6 = new System.Windows.Forms.NumericUpDown();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLotteryOutletRemove = new System.Windows.Forms.Button();
            this.btnSaveModDesc = new System.Windows.Forms.Button();
            this.btnSaveLotteryOutlet = new System.Windows.Forms.Button();
            this.btnLAWPASaveChanges = new System.Windows.Forms.Button();
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
            this.gpbLWPA1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet6)).BeginInit();
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
            treeNode5.Name = "nodeLottoOutlet";
            treeNode5.SelectedImageKey = "outlet_32px.png";
            treeNode5.Text = "Lottery Outlet";
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "nodeLotteryWinComb";
            treeNode6.SelectedImageKey = "money_32px.png";
            treeNode6.Text = "Lottery Winning Prizes/Amount";
            treeNode7.ImageKey = "Star5_32x.png";
            treeNode7.Name = "nodeLottoSeqGen";
            treeNode7.SelectedImageKey = "Star5_32x.png";
            treeNode7.Text = "Lottery Sequence Generator";
            treeNode8.ImageKey = "schedule_32px.png";
            treeNode8.Name = "nodeLottoSched";
            treeNode8.SelectedImageKey = "schedule_32px.png";
            treeNode8.Text = "Lottery Schedule";
            this.mainMenuTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.mainMenuTreeView.SelectedImageIndex = 0;
            this.mainMenuTreeView.ShowRootLines = false;
            this.mainMenuTreeView.Size = new System.Drawing.Size(268, 473);
            this.mainMenuTreeView.StateImageList = this.imageListForTreeView;
            this.mainMenuTreeView.TabIndex = 0;
            this.mainMenuTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mainMenuTreeView_AfterSelect);
            this.mainMenuTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mainMenuTreeView_NodeMouseClick);
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
            // lblLotteryOutletDescLen
            // 
            this.lblLotteryOutletDescLen.AutoSize = true;
            this.lblLotteryOutletDescLen.Location = new System.Drawing.Point(3, 87);
            this.lblLotteryOutletDescLen.Name = "lblLotteryOutletDescLen";
            this.lblLotteryOutletDescLen.Size = new System.Drawing.Size(81, 17);
            this.lblLotteryOutletDescLen.TabIndex = 3;
            this.lblLotteryOutletDescLen.Text = "(255 chars)";
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
            this.lotteryWinPrizeTabPage.Controls.Add(this.btnLAWPASaveChanges);
            this.lotteryWinPrizeTabPage.Controls.Add(this.groupBox1);
            this.lotteryWinPrizeTabPage.Controls.Add(this.gpbLWPA1);
            this.lotteryWinPrizeTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotteryWinPrizeTabPage.Name = "lotteryWinPrizeTabPage";
            this.lotteryWinPrizeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lotteryWinPrizeTabPage.Size = new System.Drawing.Size(787, 444);
            this.lotteryWinPrizeTabPage.TabIndex = 1;
            this.lotteryWinPrizeTabPage.Text = "Lottery Winning Prize/Amount";
            this.lotteryWinPrizeTabPage.UseVisualStyleBackColor = true;
            // 
            // lotterySeqGenTabPage
            // 
            this.lotterySeqGenTabPage.Controls.Add(this.label3);
            this.lotterySeqGenTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotterySeqGenTabPage.Name = "lotterySeqGenTabPage";
            this.lotterySeqGenTabPage.Size = new System.Drawing.Size(787, 444);
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
            this.lotterySchedTabPage.Size = new System.Drawing.Size(787, 444);
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
            // gpbLWPA1
            // 
            this.gpbLWPA1.Controls.Add(this.cmbLWPAGameMode);
            this.gpbLWPA1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbLWPA1.Location = new System.Drawing.Point(3, 3);
            this.gpbLWPA1.Name = "gpbLWPA1";
            this.gpbLWPA1.Size = new System.Drawing.Size(781, 55);
            this.gpbLWPA1.TabIndex = 0;
            this.gpbLWPA1.TabStop = false;
            this.gpbLWPA1.Text = "Select the game you want to modify";
            // 
            // cmbLWPAGameMode
            // 
            this.cmbLWPAGameMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbLWPAGameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLWPAGameMode.FormattingEnabled = true;
            this.cmbLWPAGameMode.Location = new System.Drawing.Point(3, 18);
            this.cmbLWPAGameMode.Name = "cmbLWPAGameMode";
            this.cmbLWPAGameMode.Size = new System.Drawing.Size(775, 24);
            this.cmbLWPAGameMode.TabIndex = 0;
            this.cmbLWPAGameMode.SelectedIndexChanged += new System.EventHandler(this.cmbLWPAGameMode_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbLWPABet6);
            this.groupBox1.Controls.Add(this.txtbLWPABet5);
            this.groupBox1.Controls.Add(this.txtbLWPABet4);
            this.groupBox1.Controls.Add(this.txtbLWPABet3);
            this.groupBox1.Controls.Add(this.txtbLWPABet2);
            this.groupBox1.Controls.Add(this.txtbLWPABet1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblLWPAmatchBet6);
            this.groupBox1.Controls.Add(this.lblLWPAmatchBet5);
            this.groupBox1.Controls.Add(this.lblLWPAmatchBet4);
            this.groupBox1.Controls.Add(this.lblLWPAmatchBet3);
            this.groupBox1.Controls.Add(this.lblLWPAmatchBet2);
            this.groupBox1.Controls.Add(this.lblLWPAmatchBet1);
            this.groupBox1.Controls.Add(this.lblLWPASelectedGame);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 261);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update here the Winnings/Prizes combination amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Game: ";
            // 
            // lblLWPASelectedGame
            // 
            this.lblLWPASelectedGame.AutoSize = true;
            this.lblLWPASelectedGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLWPASelectedGame.ForeColor = System.Drawing.Color.Tomato;
            this.lblLWPASelectedGame.Location = new System.Drawing.Point(118, 28);
            this.lblLWPASelectedGame.Name = "lblLWPASelectedGame";
            this.lblLWPASelectedGame.Size = new System.Drawing.Size(149, 20);
            this.lblLWPASelectedGame.TabIndex = 1;
            this.lblLWPASelectedGame.Text = "6/42 Super Lotto";
            // 
            // lblLWPAmatchBet1
            // 
            this.lblLWPAmatchBet1.AutoSize = true;
            this.lblLWPAmatchBet1.Location = new System.Drawing.Point(43, 93);
            this.lblLWPAmatchBet1.Name = "lblLWPAmatchBet1";
            this.lblLWPAmatchBet1.Size = new System.Drawing.Size(107, 17);
            this.lblLWPAmatchBet1.TabIndex = 2;
            this.lblLWPAmatchBet1.Text = "1 of 6 numbers:";
            // 
            // lblLWPAmatchBet2
            // 
            this.lblLWPAmatchBet2.AutoSize = true;
            this.lblLWPAmatchBet2.Location = new System.Drawing.Point(43, 122);
            this.lblLWPAmatchBet2.Name = "lblLWPAmatchBet2";
            this.lblLWPAmatchBet2.Size = new System.Drawing.Size(107, 17);
            this.lblLWPAmatchBet2.TabIndex = 3;
            this.lblLWPAmatchBet2.Text = "2 of 6 numbers:";
            // 
            // lblLWPAmatchBet3
            // 
            this.lblLWPAmatchBet3.AutoSize = true;
            this.lblLWPAmatchBet3.Location = new System.Drawing.Point(43, 150);
            this.lblLWPAmatchBet3.Name = "lblLWPAmatchBet3";
            this.lblLWPAmatchBet3.Size = new System.Drawing.Size(107, 17);
            this.lblLWPAmatchBet3.TabIndex = 4;
            this.lblLWPAmatchBet3.Text = "3 of 6 numbers:";
            // 
            // lblLWPAmatchBet4
            // 
            this.lblLWPAmatchBet4.AutoSize = true;
            this.lblLWPAmatchBet4.Location = new System.Drawing.Point(43, 177);
            this.lblLWPAmatchBet4.Name = "lblLWPAmatchBet4";
            this.lblLWPAmatchBet4.Size = new System.Drawing.Size(107, 17);
            this.lblLWPAmatchBet4.TabIndex = 5;
            this.lblLWPAmatchBet4.Text = "4 of 6 numbers:";
            // 
            // lblLWPAmatchBet5
            // 
            this.lblLWPAmatchBet5.AutoSize = true;
            this.lblLWPAmatchBet5.Location = new System.Drawing.Point(43, 204);
            this.lblLWPAmatchBet5.Name = "lblLWPAmatchBet5";
            this.lblLWPAmatchBet5.Size = new System.Drawing.Size(107, 17);
            this.lblLWPAmatchBet5.TabIndex = 6;
            this.lblLWPAmatchBet5.Text = "5 of 6 numbers:";
            // 
            // lblLWPAmatchBet6
            // 
            this.lblLWPAmatchBet6.AutoSize = true;
            this.lblLWPAmatchBet6.Location = new System.Drawing.Point(43, 231);
            this.lblLWPAmatchBet6.Name = "lblLWPAmatchBet6";
            this.lblLWPAmatchBet6.Size = new System.Drawing.Size(107, 17);
            this.lblLWPAmatchBet6.TabIndex = 7;
            this.lblLWPAmatchBet6.Text = "6 of 6 numbers:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label10.Location = new System.Drawing.Point(372, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Winning Prize";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label11.Location = new System.Drawing.Point(43, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "#Matches on bet";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Tomato;
            this.label12.Location = new System.Drawing.Point(473, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(192, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "*(equal to JACKPOT amount)";
            // 
            // txtbLWPABet1
            // 
            this.txtbLWPABet1.Location = new System.Drawing.Point(226, 91);
            this.txtbLWPABet1.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtbLWPABet1.Name = "txtbLWPABet1";
            this.txtbLWPABet1.Size = new System.Drawing.Size(241, 22);
            this.txtbLWPABet1.TabIndex = 17;
            this.txtbLWPABet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbLWPABet1.ThousandsSeparator = true;
            // 
            // txtbLWPABet2
            // 
            this.txtbLWPABet2.Location = new System.Drawing.Point(226, 117);
            this.txtbLWPABet2.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtbLWPABet2.Name = "txtbLWPABet2";
            this.txtbLWPABet2.Size = new System.Drawing.Size(241, 22);
            this.txtbLWPABet2.TabIndex = 18;
            this.txtbLWPABet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbLWPABet2.ThousandsSeparator = true;
            // 
            // txtbLWPABet3
            // 
            this.txtbLWPABet3.Location = new System.Drawing.Point(226, 145);
            this.txtbLWPABet3.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtbLWPABet3.Name = "txtbLWPABet3";
            this.txtbLWPABet3.Size = new System.Drawing.Size(241, 22);
            this.txtbLWPABet3.TabIndex = 19;
            this.txtbLWPABet3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbLWPABet3.ThousandsSeparator = true;
            // 
            // txtbLWPABet4
            // 
            this.txtbLWPABet4.Location = new System.Drawing.Point(226, 173);
            this.txtbLWPABet4.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtbLWPABet4.Name = "txtbLWPABet4";
            this.txtbLWPABet4.Size = new System.Drawing.Size(241, 22);
            this.txtbLWPABet4.TabIndex = 20;
            this.txtbLWPABet4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbLWPABet4.ThousandsSeparator = true;
            // 
            // txtbLWPABet5
            // 
            this.txtbLWPABet5.Location = new System.Drawing.Point(226, 199);
            this.txtbLWPABet5.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtbLWPABet5.Name = "txtbLWPABet5";
            this.txtbLWPABet5.Size = new System.Drawing.Size(241, 22);
            this.txtbLWPABet5.TabIndex = 21;
            this.txtbLWPABet5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbLWPABet5.ThousandsSeparator = true;
            // 
            // txtbLWPABet6
            // 
            this.txtbLWPABet6.Location = new System.Drawing.Point(226, 226);
            this.txtbLWPABet6.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtbLWPABet6.Name = "txtbLWPABet6";
            this.txtbLWPABet6.Size = new System.Drawing.Size(241, 22);
            this.txtbLWPABet6.TabIndex = 22;
            this.txtbLWPABet6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbLWPABet6.ThousandsSeparator = true;
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
            // btnLotteryOutletRemove
            // 
            this.btnLotteryOutletRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLotteryOutletRemove.Image = global::LottoDataManager.Properties.Resources.Trash_32x;
            this.btnLotteryOutletRemove.Location = new System.Drawing.Point(722, 87);
            this.btnLotteryOutletRemove.Name = "btnLotteryOutletRemove";
            this.btnLotteryOutletRemove.Size = new System.Drawing.Size(56, 62);
            this.btnLotteryOutletRemove.TabIndex = 4;
            this.btnLotteryOutletRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLotteryOutletRemove.UseVisualStyleBackColor = true;
            this.btnLotteryOutletRemove.Click += new System.EventHandler(this.btnLotteryOutletRemove_Click);
            // 
            // btnSaveModDesc
            // 
            this.btnSaveModDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveModDesc.Image = global::LottoDataManager.Properties.Resources.Edit_01_32x;
            this.btnSaveModDesc.Location = new System.Drawing.Point(244, 87);
            this.btnSaveModDesc.Name = "btnSaveModDesc";
            this.btnSaveModDesc.Size = new System.Drawing.Size(271, 63);
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
            this.btnSaveLotteryOutlet.Size = new System.Drawing.Size(198, 62);
            this.btnSaveLotteryOutlet.TabIndex = 1;
            this.btnSaveLotteryOutlet.Text = "Save as New Outlet";
            this.btnSaveLotteryOutlet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveLotteryOutlet.UseVisualStyleBackColor = true;
            this.btnSaveLotteryOutlet.Click += new System.EventHandler(this.btnSaveLotteryOutlet_Click);
            // 
            // btnLAWPASaveChanges
            // 
            this.btnLAWPASaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLAWPASaveChanges.Image = global::LottoDataManager.Properties.Resources.save_v1_32;
            this.btnLAWPASaveChanges.Location = new System.Drawing.Point(584, 376);
            this.btnLAWPASaveChanges.Name = "btnLAWPASaveChanges";
            this.btnLAWPASaveChanges.Size = new System.Drawing.Size(198, 62);
            this.btnLAWPASaveChanges.TabIndex = 3;
            this.btnLAWPASaveChanges.Text = "Save changes";
            this.btnLAWPASaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLAWPASaveChanges.UseVisualStyleBackColor = true;
            this.btnLAWPASaveChanges.Click += new System.EventHandler(this.btnLAWPASaveChanges_Click);
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
            this.lotterySeqGenTabPage.ResumeLayout(false);
            this.lotterySeqGenTabPage.PerformLayout();
            this.lotterySchedTabPage.ResumeLayout(false);
            this.lotterySchedTabPage.PerformLayout();
            this.mainPanelBottom.ResumeLayout(false);
            this.gpbLWPA1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet6)).EndInit();
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
        private System.Windows.Forms.GroupBox gpbLWPA1;
        private System.Windows.Forms.ComboBox cmbLWPAGameMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLWPASelectedGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLWPAmatchBet4;
        private System.Windows.Forms.Label lblLWPAmatchBet3;
        private System.Windows.Forms.Label lblLWPAmatchBet2;
        private System.Windows.Forms.Label lblLWPAmatchBet1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblLWPAmatchBet6;
        private System.Windows.Forms.Label lblLWPAmatchBet5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLAWPASaveChanges;
        private System.Windows.Forms.NumericUpDown txtbLWPABet1;
        private System.Windows.Forms.NumericUpDown txtbLWPABet6;
        private System.Windows.Forms.NumericUpDown txtbLWPABet5;
        private System.Windows.Forms.NumericUpDown txtbLWPABet4;
        private System.Windows.Forms.NumericUpDown txtbLWPABet3;
        private System.Windows.Forms.NumericUpDown txtbLWPABet2;
    }
}