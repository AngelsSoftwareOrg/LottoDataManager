
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Configurations");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Lottery Outlet");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Lottery Winning Prizes/Amount");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Lottery Sequence Generator");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Lottery Schedule");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LotterySettingsFrm));
            this.panelMainTop = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mainMenuTreeView = new System.Windows.Forms.TreeView();
            this.imageListForTreeView = new System.Windows.Forms.ImageList(this.components);
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.lotteryConfig = new System.Windows.Forms.TabPage();
            this.btnConfigSave = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtConfigNotes = new System.Windows.Forms.TextBox();
            this.lnkLblConfigML = new System.Windows.Forms.LinkLabel();
            this.txtConfigFolderML = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkLblConfigDB = new System.Windows.Forms.LinkLabel();
            this.txtConfigDBSource = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btnLAWPASaveChanges = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbLWPABet6 = new System.Windows.Forms.NumericUpDown();
            this.txtbLWPABet5 = new System.Windows.Forms.NumericUpDown();
            this.txtbLWPABet4 = new System.Windows.Forms.NumericUpDown();
            this.txtbLWPABet3 = new System.Windows.Forms.NumericUpDown();
            this.txtbLWPABet2 = new System.Windows.Forms.NumericUpDown();
            this.txtbLWPABet1 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet6 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet5 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet4 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet3 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet2 = new System.Windows.Forms.Label();
            this.lblLWPAmatchBet1 = new System.Windows.Forms.Label();
            this.lblLWPASelectedGame = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbLWPA1 = new System.Windows.Forms.GroupBox();
            this.cmbLWPAGameMode = new System.Windows.Forms.ComboBox();
            this.lotterySeqGenTabPage = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvSeqGenDescriptions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSeqGenChars = new System.Windows.Forms.Label();
            this.btnSeqGenSaveChanges = new System.Windows.Forms.Button();
            this.txtbGenSeqDescription = new System.Windows.Forms.TextBox();
            this.lotterySchedTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkbLotSchedSun = new System.Windows.Forms.CheckBox();
            this.chkbLotSchedSat = new System.Windows.Forms.CheckBox();
            this.chkbLotSchedFri = new System.Windows.Forms.CheckBox();
            this.chkbLotSchedThurs = new System.Windows.Forms.CheckBox();
            this.chkbLotSchedWed = new System.Windows.Forms.CheckBox();
            this.chkbLotSchedTue = new System.Windows.Forms.CheckBox();
            this.chkbLotSchedMon = new System.Windows.Forms.CheckBox();
            this.lblLotSchedSelectedGame = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbLotSchedLotteries = new System.Windows.Forms.ComboBox();
            this.btnLotSchedSave = new System.Windows.Forms.Button();
            this.mainPanelBottom = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelMainTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.lotteryConfig.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.lotteryOutletTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.lotteryWinPrizeTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet1)).BeginInit();
            this.gpbLWPA1.SuspendLayout();
            this.lotterySeqGenTabPage.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.lotterySchedTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.mainPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainTop
            // 
            this.panelMainTop.Controls.Add(this.splitContainer1);
            this.panelMainTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainTop.Location = new System.Drawing.Point(0, 0);
            this.panelMainTop.Name = "panelMainTop";
            this.panelMainTop.Size = new System.Drawing.Size(1069, 436);
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
            this.splitContainer1.Size = new System.Drawing.Size(1069, 436);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 0;
            // 
            // mainMenuTreeView
            // 
            this.mainMenuTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuTreeView.FullRowSelect = true;
            this.mainMenuTreeView.HideSelection = false;
            this.mainMenuTreeView.ImageIndex = 0;
            this.mainMenuTreeView.ImageList = this.imageListForTreeView;
            this.mainMenuTreeView.Indent = 20;
            this.mainMenuTreeView.ItemHeight = 40;
            this.mainMenuTreeView.Location = new System.Drawing.Point(0, 0);
            this.mainMenuTreeView.Name = "mainMenuTreeView";
            treeNode1.ImageKey = "config_folders_32px.png";
            treeNode1.Name = "nodeConfig";
            treeNode1.SelectedImageKey = "config_folders_32px.png";
            treeNode1.Text = "Configurations";
            treeNode2.Name = "nodeLottoOutlet";
            treeNode2.SelectedImageKey = "outlet_32px.png";
            treeNode2.Text = "Lottery Outlet";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "nodeLotteryWinComb";
            treeNode3.SelectedImageKey = "money_32px.png";
            treeNode3.Text = "Lottery Winning Prizes/Amount";
            treeNode4.ImageKey = "Star5_32x.png";
            treeNode4.Name = "nodeLottoSeqGen";
            treeNode4.SelectedImageKey = "Star5_32x.png";
            treeNode4.Text = "Lottery Sequence Generator";
            treeNode5.ImageKey = "schedule_32px.png";
            treeNode5.Name = "nodeLottoSched";
            treeNode5.SelectedImageKey = "schedule_32px.png";
            treeNode5.Text = "Lottery Schedule";
            this.mainMenuTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.mainMenuTreeView.SelectedImageIndex = 0;
            this.mainMenuTreeView.ShowRootLines = false;
            this.mainMenuTreeView.Size = new System.Drawing.Size(268, 436);
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
            this.imageListForTreeView.Images.SetKeyName(4, "config_folders_32px.png");
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.lotteryConfig);
            this.mainTabControl.Controls.Add(this.lotteryOutletTabPage);
            this.mainTabControl.Controls.Add(this.lotteryWinPrizeTabPage);
            this.mainTabControl.Controls.Add(this.lotterySeqGenTabPage);
            this.mainTabControl.Controls.Add(this.lotterySchedTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(797, 436);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.TabStop = false;
            // 
            // lotteryConfig
            // 
            this.lotteryConfig.Controls.Add(this.btnConfigSave);
            this.lotteryConfig.Controls.Add(this.groupBox4);
            this.lotteryConfig.Location = new System.Drawing.Point(4, 25);
            this.lotteryConfig.Name = "lotteryConfig";
            this.lotteryConfig.Size = new System.Drawing.Size(789, 407);
            this.lotteryConfig.TabIndex = 4;
            this.lotteryConfig.Text = "Configurations";
            this.lotteryConfig.UseVisualStyleBackColor = true;
            // 
            // btnConfigSave
            // 
            this.btnConfigSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigSave.Image = global::LottoDataManager.Properties.Resources.save_v1_32;
            this.btnConfigSave.Location = new System.Drawing.Point(620, 342);
            this.btnConfigSave.Name = "btnConfigSave";
            this.btnConfigSave.Size = new System.Drawing.Size(165, 62);
            this.btnConfigSave.TabIndex = 2;
            this.btnConfigSave.Text = "Save changes";
            this.btnConfigSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfigSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfigSave.UseVisualStyleBackColor = true;
            this.btnConfigSave.Click += new System.EventHandler(this.btnConfigSave_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtConfigNotes);
            this.groupBox4.Controls.Add(this.lnkLblConfigML);
            this.groupBox4.Controls.Add(this.txtConfigFolderML);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.lnkLblConfigDB);
            this.groupBox4.Controls.Add(this.txtConfigDBSource);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(786, 340);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Database and Model Sources";
            // 
            // txtConfigNotes
            // 
            this.txtConfigNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigNotes.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtConfigNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfigNotes.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtConfigNotes.Location = new System.Drawing.Point(12, 269);
            this.txtConfigNotes.Multiline = true;
            this.txtConfigNotes.Name = "txtConfigNotes";
            this.txtConfigNotes.ReadOnly = true;
            this.txtConfigNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConfigNotes.Size = new System.Drawing.Size(773, 65);
            this.txtConfigNotes.TabIndex = 6;
            // 
            // lnkLblConfigML
            // 
            this.lnkLblConfigML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkLblConfigML.AutoSize = true;
            this.lnkLblConfigML.Location = new System.Drawing.Point(690, 236);
            this.lnkLblConfigML.Name = "lnkLblConfigML";
            this.lnkLblConfigML.Size = new System.Drawing.Size(89, 17);
            this.lnkLblConfigML.TabIndex = 5;
            this.lnkLblConfigML.TabStop = true;
            this.lnkLblConfigML.Text = "Choose Path";
            this.lnkLblConfigML.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblConfigML_LinkClicked);
            // 
            // txtConfigFolderML
            // 
            this.txtConfigFolderML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigFolderML.Location = new System.Drawing.Point(12, 160);
            this.txtConfigFolderML.Multiline = true;
            this.txtConfigFolderML.Name = "txtConfigFolderML";
            this.txtConfigFolderML.ReadOnly = true;
            this.txtConfigFolderML.Size = new System.Drawing.Size(768, 73);
            this.txtConfigFolderML.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Machine Learning folder path: ";
            // 
            // lnkLblConfigDB
            // 
            this.lnkLblConfigDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkLblConfigDB.AutoSize = true;
            this.lnkLblConfigDB.Location = new System.Drawing.Point(697, 107);
            this.lnkLblConfigDB.Name = "lnkLblConfigDB";
            this.lnkLblConfigDB.Size = new System.Drawing.Size(82, 17);
            this.lnkLblConfigDB.TabIndex = 2;
            this.lnkLblConfigDB.TabStop = true;
            this.lnkLblConfigDB.Text = "Choose File";
            this.lnkLblConfigDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblConfigDB_LinkClicked);
            // 
            // txtConfigDBSource
            // 
            this.txtConfigDBSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfigDBSource.Location = new System.Drawing.Point(10, 43);
            this.txtConfigDBSource.Multiline = true;
            this.txtConfigDBSource.Name = "txtConfigDBSource";
            this.txtConfigDBSource.ReadOnly = true;
            this.txtConfigDBSource.Size = new System.Drawing.Size(771, 61);
            this.txtConfigDBSource.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Database MS Access File:";
            // 
            // lotteryOutletTabPage
            // 
            this.lotteryOutletTabPage.Controls.Add(this.panel2);
            this.lotteryOutletTabPage.Controls.Add(this.panel1);
            this.lotteryOutletTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotteryOutletTabPage.Name = "lotteryOutletTabPage";
            this.lotteryOutletTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.lotteryOutletTabPage.Size = new System.Drawing.Size(789, 407);
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
            this.panel2.Size = new System.Drawing.Size(783, 252);
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
            this.lvLotteryOutlets.Size = new System.Drawing.Size(783, 252);
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
            this.panel1.Location = new System.Drawing.Point(3, 255);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 149);
            this.panel1.TabIndex = 0;
            // 
            // btnLotteryOutletRemove
            // 
            this.btnLotteryOutletRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLotteryOutletRemove.Image = global::LottoDataManager.Properties.Resources.Trash_32x;
            this.btnLotteryOutletRemove.Location = new System.Drawing.Point(724, 87);
            this.btnLotteryOutletRemove.Name = "btnLotteryOutletRemove";
            this.btnLotteryOutletRemove.Size = new System.Drawing.Size(56, 62);
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
            this.btnSaveModDesc.Location = new System.Drawing.Point(246, 87);
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
            this.btnSaveLotteryOutlet.Location = new System.Drawing.Point(523, 87);
            this.btnSaveLotteryOutlet.Name = "btnSaveLotteryOutlet";
            this.btnSaveLotteryOutlet.Size = new System.Drawing.Size(198, 62);
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
            this.txtOutletCodeDesc.Size = new System.Drawing.Size(783, 81);
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
            this.lotteryWinPrizeTabPage.Size = new System.Drawing.Size(789, 407);
            this.lotteryWinPrizeTabPage.TabIndex = 1;
            this.lotteryWinPrizeTabPage.Text = "Lottery Winning Prize/Amount";
            this.lotteryWinPrizeTabPage.UseVisualStyleBackColor = true;
            // 
            // btnLAWPASaveChanges
            // 
            this.btnLAWPASaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLAWPASaveChanges.Image = global::LottoDataManager.Properties.Resources.save_v1_32;
            this.btnLAWPASaveChanges.Location = new System.Drawing.Point(604, 340);
            this.btnLAWPASaveChanges.Name = "btnLAWPASaveChanges";
            this.btnLAWPASaveChanges.Size = new System.Drawing.Size(179, 62);
            this.btnLAWPASaveChanges.TabIndex = 3;
            this.btnLAWPASaveChanges.Text = "Save changes";
            this.btnLAWPASaveChanges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLAWPASaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLAWPASaveChanges.UseVisualStyleBackColor = true;
            this.btnLAWPASaveChanges.Click += new System.EventHandler(this.btnLAWPASaveChanges_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox1.Location = new System.Drawing.Point(3, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 275);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update here the Winnings/Prizes combination amount";
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
            // lblLWPAmatchBet6
            // 
            this.lblLWPAmatchBet6.AutoSize = true;
            this.lblLWPAmatchBet6.Location = new System.Drawing.Point(43, 231);
            this.lblLWPAmatchBet6.Name = "lblLWPAmatchBet6";
            this.lblLWPAmatchBet6.Size = new System.Drawing.Size(107, 17);
            this.lblLWPAmatchBet6.TabIndex = 7;
            this.lblLWPAmatchBet6.Text = "6 of 6 numbers:";
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
            // lblLWPAmatchBet4
            // 
            this.lblLWPAmatchBet4.AutoSize = true;
            this.lblLWPAmatchBet4.Location = new System.Drawing.Point(43, 177);
            this.lblLWPAmatchBet4.Name = "lblLWPAmatchBet4";
            this.lblLWPAmatchBet4.Size = new System.Drawing.Size(107, 17);
            this.lblLWPAmatchBet4.TabIndex = 5;
            this.lblLWPAmatchBet4.Text = "4 of 6 numbers:";
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
            // lblLWPAmatchBet2
            // 
            this.lblLWPAmatchBet2.AutoSize = true;
            this.lblLWPAmatchBet2.Location = new System.Drawing.Point(43, 122);
            this.lblLWPAmatchBet2.Name = "lblLWPAmatchBet2";
            this.lblLWPAmatchBet2.Size = new System.Drawing.Size(107, 17);
            this.lblLWPAmatchBet2.TabIndex = 3;
            this.lblLWPAmatchBet2.Text = "2 of 6 numbers:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Game: ";
            // 
            // gpbLWPA1
            // 
            this.gpbLWPA1.Controls.Add(this.cmbLWPAGameMode);
            this.gpbLWPA1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbLWPA1.Location = new System.Drawing.Point(3, 3);
            this.gpbLWPA1.Name = "gpbLWPA1";
            this.gpbLWPA1.Size = new System.Drawing.Size(783, 55);
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
            this.cmbLWPAGameMode.Size = new System.Drawing.Size(777, 24);
            this.cmbLWPAGameMode.TabIndex = 0;
            this.cmbLWPAGameMode.SelectedIndexChanged += new System.EventHandler(this.cmbLWPAGameMode_SelectedIndexChanged);
            // 
            // lotterySeqGenTabPage
            // 
            this.lotterySeqGenTabPage.Controls.Add(this.panel3);
            this.lotterySeqGenTabPage.Controls.Add(this.panel4);
            this.lotterySeqGenTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotterySeqGenTabPage.Name = "lotterySeqGenTabPage";
            this.lotterySeqGenTabPage.Size = new System.Drawing.Size(789, 407);
            this.lotterySeqGenTabPage.TabIndex = 2;
            this.lotterySeqGenTabPage.Text = "Lottery Sequence Generator";
            this.lotterySeqGenTabPage.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvSeqGenDescriptions);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(789, 258);
            this.panel3.TabIndex = 1;
            // 
            // lvSeqGenDescriptions
            // 
            this.lvSeqGenDescriptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvSeqGenDescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSeqGenDescriptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSeqGenDescriptions.FullRowSelect = true;
            this.lvSeqGenDescriptions.GridLines = true;
            this.lvSeqGenDescriptions.HideSelection = false;
            this.lvSeqGenDescriptions.Location = new System.Drawing.Point(0, 0);
            this.lvSeqGenDescriptions.MultiSelect = false;
            this.lvSeqGenDescriptions.Name = "lvSeqGenDescriptions";
            this.lvSeqGenDescriptions.Size = new System.Drawing.Size(789, 258);
            this.lvSeqGenDescriptions.TabIndex = 0;
            this.lvSeqGenDescriptions.UseCompatibleStateImageBehavior = false;
            this.lvSeqGenDescriptions.View = System.Windows.Forms.View.Details;
            this.lvSeqGenDescriptions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSeqGenDescriptions_ColumnClick);
            this.lvSeqGenDescriptions.SelectedIndexChanged += new System.EventHandler(this.lvSeqGenDescriptions_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 462;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblSeqGenChars);
            this.panel4.Controls.Add(this.btnSeqGenSaveChanges);
            this.panel4.Controls.Add(this.txtbGenSeqDescription);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 258);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(789, 149);
            this.panel4.TabIndex = 2;
            // 
            // lblSeqGenChars
            // 
            this.lblSeqGenChars.AutoSize = true;
            this.lblSeqGenChars.Location = new System.Drawing.Point(3, 87);
            this.lblSeqGenChars.Name = "lblSeqGenChars";
            this.lblSeqGenChars.Size = new System.Drawing.Size(81, 17);
            this.lblSeqGenChars.TabIndex = 3;
            this.lblSeqGenChars.Text = "(255 chars)";
            // 
            // btnSeqGenSaveChanges
            // 
            this.btnSeqGenSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeqGenSaveChanges.Image = global::LottoDataManager.Properties.Resources.save_v1_32;
            this.btnSeqGenSaveChanges.Location = new System.Drawing.Point(516, 86);
            this.btnSeqGenSaveChanges.Name = "btnSeqGenSaveChanges";
            this.btnSeqGenSaveChanges.Size = new System.Drawing.Size(268, 62);
            this.btnSeqGenSaveChanges.TabIndex = 1;
            this.btnSeqGenSaveChanges.Text = "Save description changes";
            this.btnSeqGenSaveChanges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeqGenSaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeqGenSaveChanges.UseVisualStyleBackColor = true;
            this.btnSeqGenSaveChanges.Click += new System.EventHandler(this.btnSeqGenSaveChanges_Click);
            // 
            // txtbGenSeqDescription
            // 
            this.txtbGenSeqDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtbGenSeqDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbGenSeqDescription.Location = new System.Drawing.Point(0, 0);
            this.txtbGenSeqDescription.Multiline = true;
            this.txtbGenSeqDescription.Name = "txtbGenSeqDescription";
            this.txtbGenSeqDescription.Size = new System.Drawing.Size(789, 81);
            this.txtbGenSeqDescription.TabIndex = 0;
            this.txtbGenSeqDescription.TextChanged += new System.EventHandler(this.txtbGenSeqDescription_TextChanged);
            // 
            // lotterySchedTabPage
            // 
            this.lotterySchedTabPage.Controls.Add(this.groupBox3);
            this.lotterySchedTabPage.Controls.Add(this.groupBox2);
            this.lotterySchedTabPage.Controls.Add(this.btnLotSchedSave);
            this.lotterySchedTabPage.Location = new System.Drawing.Point(4, 25);
            this.lotterySchedTabPage.Name = "lotterySchedTabPage";
            this.lotterySchedTabPage.Size = new System.Drawing.Size(789, 407);
            this.lotterySchedTabPage.TabIndex = 3;
            this.lotterySchedTabPage.Text = "Lottery Schedule";
            this.lotterySchedTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkbLotSchedSun);
            this.groupBox3.Controls.Add(this.chkbLotSchedSat);
            this.groupBox3.Controls.Add(this.chkbLotSchedFri);
            this.groupBox3.Controls.Add(this.chkbLotSchedThurs);
            this.groupBox3.Controls.Add(this.chkbLotSchedWed);
            this.groupBox3.Controls.Add(this.chkbLotSchedTue);
            this.groupBox3.Controls.Add(this.chkbLotSchedMon);
            this.groupBox3.Controls.Add(this.lblLotSchedSelectedGame);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(3, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(782, 286);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Game Schedule";
            // 
            // chkbLotSchedSun
            // 
            this.chkbLotSchedSun.AutoSize = true;
            this.chkbLotSchedSun.Location = new System.Drawing.Point(39, 230);
            this.chkbLotSchedSun.Name = "chkbLotSchedSun";
            this.chkbLotSchedSun.Size = new System.Drawing.Size(78, 21);
            this.chkbLotSchedSun.TabIndex = 10;
            this.chkbLotSchedSun.Text = "Sunday";
            this.chkbLotSchedSun.UseVisualStyleBackColor = true;
            // 
            // chkbLotSchedSat
            // 
            this.chkbLotSchedSat.AutoSize = true;
            this.chkbLotSchedSat.Location = new System.Drawing.Point(39, 203);
            this.chkbLotSchedSat.Name = "chkbLotSchedSat";
            this.chkbLotSchedSat.Size = new System.Drawing.Size(87, 21);
            this.chkbLotSchedSat.TabIndex = 9;
            this.chkbLotSchedSat.Text = "Saturday";
            this.chkbLotSchedSat.UseVisualStyleBackColor = true;
            // 
            // chkbLotSchedFri
            // 
            this.chkbLotSchedFri.AutoSize = true;
            this.chkbLotSchedFri.Location = new System.Drawing.Point(39, 176);
            this.chkbLotSchedFri.Name = "chkbLotSchedFri";
            this.chkbLotSchedFri.Size = new System.Drawing.Size(69, 21);
            this.chkbLotSchedFri.TabIndex = 8;
            this.chkbLotSchedFri.Text = "Friday";
            this.chkbLotSchedFri.UseVisualStyleBackColor = true;
            // 
            // chkbLotSchedThurs
            // 
            this.chkbLotSchedThurs.AutoSize = true;
            this.chkbLotSchedThurs.Location = new System.Drawing.Point(39, 149);
            this.chkbLotSchedThurs.Name = "chkbLotSchedThurs";
            this.chkbLotSchedThurs.Size = new System.Drawing.Size(90, 21);
            this.chkbLotSchedThurs.TabIndex = 7;
            this.chkbLotSchedThurs.Text = "Thursday";
            this.chkbLotSchedThurs.UseVisualStyleBackColor = true;
            // 
            // chkbLotSchedWed
            // 
            this.chkbLotSchedWed.AutoSize = true;
            this.chkbLotSchedWed.Location = new System.Drawing.Point(39, 122);
            this.chkbLotSchedWed.Name = "chkbLotSchedWed";
            this.chkbLotSchedWed.Size = new System.Drawing.Size(105, 21);
            this.chkbLotSchedWed.TabIndex = 6;
            this.chkbLotSchedWed.Text = "Wednesday";
            this.chkbLotSchedWed.UseVisualStyleBackColor = true;
            // 
            // chkbLotSchedTue
            // 
            this.chkbLotSchedTue.AutoSize = true;
            this.chkbLotSchedTue.Location = new System.Drawing.Point(39, 95);
            this.chkbLotSchedTue.Name = "chkbLotSchedTue";
            this.chkbLotSchedTue.Size = new System.Drawing.Size(85, 21);
            this.chkbLotSchedTue.TabIndex = 5;
            this.chkbLotSchedTue.Text = "Tuesday";
            this.chkbLotSchedTue.UseVisualStyleBackColor = true;
            // 
            // chkbLotSchedMon
            // 
            this.chkbLotSchedMon.AutoSize = true;
            this.chkbLotSchedMon.Location = new System.Drawing.Point(39, 68);
            this.chkbLotSchedMon.Name = "chkbLotSchedMon";
            this.chkbLotSchedMon.Size = new System.Drawing.Size(80, 21);
            this.chkbLotSchedMon.TabIndex = 4;
            this.chkbLotSchedMon.Text = "Monday";
            this.chkbLotSchedMon.UseVisualStyleBackColor = true;
            // 
            // lblLotSchedSelectedGame
            // 
            this.lblLotSchedSelectedGame.AutoSize = true;
            this.lblLotSchedSelectedGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotSchedSelectedGame.ForeColor = System.Drawing.Color.Tomato;
            this.lblLotSchedSelectedGame.Location = new System.Drawing.Point(115, 24);
            this.lblLotSchedSelectedGame.Name = "lblLotSchedSelectedGame";
            this.lblLotSchedSelectedGame.Size = new System.Drawing.Size(149, 20);
            this.lblLotSchedSelectedGame.TabIndex = 3;
            this.lblLotSchedSelectedGame.Text = "6/42 Super Lotto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Selected Game: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbLotSchedLotteries);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(789, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select the game you want the schedule to modify";
            // 
            // cmbLotSchedLotteries
            // 
            this.cmbLotSchedLotteries.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbLotSchedLotteries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLotSchedLotteries.FormattingEnabled = true;
            this.cmbLotSchedLotteries.Location = new System.Drawing.Point(3, 18);
            this.cmbLotSchedLotteries.Name = "cmbLotSchedLotteries";
            this.cmbLotSchedLotteries.Size = new System.Drawing.Size(783, 24);
            this.cmbLotSchedLotteries.TabIndex = 0;
            this.cmbLotSchedLotteries.SelectedIndexChanged += new System.EventHandler(this.cmbLotSchedLotteries_SelectedIndexChanged);
            // 
            // btnLotSchedSave
            // 
            this.btnLotSchedSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLotSchedSave.Image = global::LottoDataManager.Properties.Resources.save_v1_32;
            this.btnLotSchedSave.Location = new System.Drawing.Point(606, 340);
            this.btnLotSchedSave.Name = "btnLotSchedSave";
            this.btnLotSchedSave.Size = new System.Drawing.Size(179, 62);
            this.btnLotSchedSave.TabIndex = 4;
            this.btnLotSchedSave.Text = "Save changes";
            this.btnLotSchedSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLotSchedSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLotSchedSave.UseVisualStyleBackColor = true;
            this.btnLotSchedSave.Click += new System.EventHandler(this.btnLotSchedSave_Click);
            // 
            // mainPanelBottom
            // 
            this.mainPanelBottom.Controls.Add(this.btnExit);
            this.mainPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainPanelBottom.Location = new System.Drawing.Point(0, 436);
            this.mainPanelBottom.Name = "mainPanelBottom";
            this.mainPanelBottom.Size = new System.Drawing.Size(1069, 63);
            this.mainPanelBottom.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::LottoDataManager.Properties.Resources.Exit_32;
            this.btnExit.Location = new System.Drawing.Point(942, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(119, 57);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LotterySettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1069, 499);
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
            this.lotteryConfig.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.lotteryOutletTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.lotteryWinPrizeTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbLWPABet1)).EndInit();
            this.gpbLWPA1.ResumeLayout(false);
            this.lotterySeqGenTabPage.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.lotterySchedTabPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSeqGenChars;
        private System.Windows.Forms.TextBox txtbGenSeqDescription;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lvSeqGenDescriptions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSeqGenSaveChanges;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbLotSchedLotteries;
        private System.Windows.Forms.Button btnLotSchedSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblLotSchedSelectedGame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkbLotSchedSun;
        private System.Windows.Forms.CheckBox chkbLotSchedSat;
        private System.Windows.Forms.CheckBox chkbLotSchedFri;
        private System.Windows.Forms.CheckBox chkbLotSchedThurs;
        private System.Windows.Forms.CheckBox chkbLotSchedWed;
        private System.Windows.Forms.CheckBox chkbLotSchedTue;
        private System.Windows.Forms.CheckBox chkbLotSchedMon;
        private System.Windows.Forms.TabPage lotteryConfig;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnConfigSave;
        private System.Windows.Forms.LinkLabel lnkLblConfigDB;
        private System.Windows.Forms.TextBox txtConfigDBSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkLblConfigML;
        private System.Windows.Forms.TextBox txtConfigFolderML;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfigNotes;
    }
}