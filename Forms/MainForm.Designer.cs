
namespace LottoDataManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLotteryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.predictionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luckyPickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lossProfitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lotterySettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkLotteryUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mainLeftTabControl = new System.Windows.Forms.TabControl();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.objectLstVwLatestBet = new BrightIdeasSoftware.FastObjectListView();
            this.olvColBetDrawDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetNum1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetNum2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetNum3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetNum4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetNum5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetNum6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBetResult = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWinningsThisMonth = new System.Windows.Forms.Label();
            this.lblLifetimeWinnins = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGameMode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNextDrawDate = new System.Windows.Forms.Label();
            this.tabWinningNumbers = new System.Windows.Forms.TabPage();
            this.objListVwWinningNum = new BrightIdeasSoftware.FastObjectListView();
            this.olvColDrawDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColJackpot = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColWinners = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnAddBet = new System.Windows.Forms.ToolStripButton();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.mainLeftTabControl.SuspendLayout();
            this.tabDashboard.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectLstVwLatestBet)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabWinningNumbers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListVwWinningNum)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generatorsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.othersToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1233, 28);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLotteryToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openLotteryToolStripMenuItem
            // 
            this.openLotteryToolStripMenuItem.Name = "openLotteryToolStripMenuItem";
            this.openLotteryToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.openLotteryToolStripMenuItem.Text = "Open Lottery";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // generatorsToolStripMenuItem
            // 
            this.generatorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.predictionsToolStripMenuItem,
            this.luckyPickToolStripMenuItem});
            this.generatorsToolStripMenuItem.Name = "generatorsToolStripMenuItem";
            this.generatorsToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.generatorsToolStripMenuItem.Text = "Ticket Generators";
            // 
            // predictionsToolStripMenuItem
            // 
            this.predictionsToolStripMenuItem.Name = "predictionsToolStripMenuItem";
            this.predictionsToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.predictionsToolStripMenuItem.Text = "Predictions";
            // 
            // luckyPickToolStripMenuItem
            // 
            this.luckyPickToolStripMenuItem.Name = "luckyPickToolStripMenuItem";
            this.luckyPickToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.luckyPickToolStripMenuItem.Text = "Lucky Pick";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lossProfitToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // lossProfitToolStripMenuItem
            // 
            this.lossProfitToolStripMenuItem.Name = "lossProfitToolStripMenuItem";
            this.lossProfitToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.lossProfitToolStripMenuItem.Text = "Loss and Profit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lotterySettingToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // lotterySettingToolStripMenuItem
            // 
            this.lotterySettingToolStripMenuItem.Name = "lotterySettingToolStripMenuItem";
            this.lotterySettingToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.lotterySettingToolStripMenuItem.Text = "Lottery Setting";
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkLotteryUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            this.othersToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.othersToolStripMenuItem.Text = "Others";
            // 
            // checkLotteryUpdatesToolStripMenuItem
            // 
            this.checkLotteryUpdatesToolStripMenuItem.Name = "checkLotteryUpdatesToolStripMenuItem";
            this.checkLotteryUpdatesToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.checkLotteryUpdatesToolStripMenuItem.Text = "Check Lottery Updates";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(240, 26);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 556);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1233, 26);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(62, 20);
            this.toolStripStatusLabel1.Text = "Lottery: ";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 55);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.mainLeftTabControl);
            this.mainSplitContainer.Size = new System.Drawing.Size(1233, 501);
            this.mainSplitContainer.SplitterDistance = 557;
            this.mainSplitContainer.TabIndex = 2;
            // 
            // mainLeftTabControl
            // 
            this.mainLeftTabControl.Controls.Add(this.tabDashboard);
            this.mainLeftTabControl.Controls.Add(this.tabWinningNumbers);
            this.mainLeftTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLeftTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainLeftTabControl.Name = "mainLeftTabControl";
            this.mainLeftTabControl.SelectedIndex = 0;
            this.mainLeftTabControl.Size = new System.Drawing.Size(557, 501);
            this.mainLeftTabControl.TabIndex = 0;
            // 
            // tabDashboard
            // 
            this.tabDashboard.Controls.Add(this.panel2);
            this.tabDashboard.Controls.Add(this.panel1);
            this.tabDashboard.Location = new System.Drawing.Point(4, 25);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(549, 472);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "Dashboard";
            this.tabDashboard.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.objectLstVwLatestBet);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(543, 352);
            this.panel2.TabIndex = 11;
            // 
            // objectLstVwLatestBet
            // 
            this.objectLstVwLatestBet.AllColumns.Add(this.olvColBetDrawDate);
            this.objectLstVwLatestBet.AllColumns.Add(this.olvColBetNum1);
            this.objectLstVwLatestBet.AllColumns.Add(this.olvColBetNum2);
            this.objectLstVwLatestBet.AllColumns.Add(this.olvColBetNum3);
            this.objectLstVwLatestBet.AllColumns.Add(this.olvColBetNum4);
            this.objectLstVwLatestBet.AllColumns.Add(this.olvColBetNum5);
            this.objectLstVwLatestBet.AllColumns.Add(this.olvColBetNum6);
            this.objectLstVwLatestBet.AllColumns.Add(this.olvColBetResult);
            this.objectLstVwLatestBet.CellEditUseWholeCell = false;
            this.objectLstVwLatestBet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColBetDrawDate,
            this.olvColBetNum1,
            this.olvColBetNum2,
            this.olvColBetNum3,
            this.olvColBetNum4,
            this.olvColBetNum5,
            this.olvColBetNum6,
            this.olvColBetResult});
            this.objectLstVwLatestBet.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectLstVwLatestBet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectLstVwLatestBet.FullRowSelect = true;
            this.objectLstVwLatestBet.GridLines = true;
            this.objectLstVwLatestBet.HideSelection = false;
            this.objectLstVwLatestBet.Location = new System.Drawing.Point(0, 17);
            this.objectLstVwLatestBet.MultiSelect = false;
            this.objectLstVwLatestBet.Name = "objectLstVwLatestBet";
            this.objectLstVwLatestBet.ShowGroups = false;
            this.objectLstVwLatestBet.Size = new System.Drawing.Size(543, 335);
            this.objectLstVwLatestBet.TabIndex = 10;
            this.objectLstVwLatestBet.UseCompatibleStateImageBehavior = false;
            this.objectLstVwLatestBet.View = System.Windows.Forms.View.Details;
            this.objectLstVwLatestBet.VirtualMode = true;
            this.objectLstVwLatestBet.SelectionChanged += new System.EventHandler(this.objectLstVwLatestBet_SelectionChanged);
            // 
            // olvColBetDrawDate
            // 
            this.olvColBetDrawDate.AspectName = "GetTargetDrawDateFormatted";
            this.olvColBetDrawDate.Text = "Draw Date";
            // 
            // olvColBetNum1
            // 
            this.olvColBetNum1.AspectName = "GetNum1";
            this.olvColBetNum1.Text = "#1";
            // 
            // olvColBetNum2
            // 
            this.olvColBetNum2.AspectName = "GetNum2";
            this.olvColBetNum2.Text = "#2";
            // 
            // olvColBetNum3
            // 
            this.olvColBetNum3.AspectName = "GetNum3";
            this.olvColBetNum3.Text = "#3";
            // 
            // olvColBetNum4
            // 
            this.olvColBetNum4.AspectName = "GetNum4";
            this.olvColBetNum4.Text = "#4";
            // 
            // olvColBetNum5
            // 
            this.olvColBetNum5.AspectName = "GetNum5";
            this.olvColBetNum5.Text = "#5";
            // 
            // olvColBetNum6
            // 
            this.olvColBetNum6.AspectName = "GetNum6";
            this.olvColBetNum6.Text = "#6";
            // 
            // olvColBetResult
            // 
            this.olvColBetResult.Text = "Result";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Latest Bet: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblWinningsThisMonth);
            this.panel1.Controls.Add(this.lblLifetimeWinnins);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblGameMode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblNextDrawDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 114);
            this.panel1.TabIndex = 10;
            // 
            // lblWinningsThisMonth
            // 
            this.lblWinningsThisMonth.AutoSize = true;
            this.lblWinningsThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinningsThisMonth.Location = new System.Drawing.Point(193, 85);
            this.lblWinningsThisMonth.Name = "lblWinningsThisMonth";
            this.lblWinningsThisMonth.Size = new System.Drawing.Size(146, 20);
            this.lblWinningsThisMonth.TabIndex = 6;
            this.lblWinningsThisMonth.Text = "P999,999,000.00";
            // 
            // lblLifetimeWinnins
            // 
            this.lblLifetimeWinnins.AutoSize = true;
            this.lblLifetimeWinnins.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLifetimeWinnins.Location = new System.Drawing.Point(127, 56);
            this.lblLifetimeWinnins.Name = "lblLifetimeWinnins";
            this.lblLifetimeWinnins.Size = new System.Drawing.Size(146, 20);
            this.lblLifetimeWinnins.TabIndex = 8;
            this.lblLifetimeWinnins.Text = "P999,999,000.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Mode: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lifetime Winnings: ";
            // 
            // lblGameMode
            // 
            this.lblGameMode.AutoSize = true;
            this.lblGameMode.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameMode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblGameMode.Location = new System.Drawing.Point(94, -4);
            this.lblGameMode.Name = "lblGameMode";
            this.lblGameMode.Size = new System.Drawing.Size(128, 29);
            this.lblGameMode.TabIndex = 1;
            this.lblGameMode.Text = "6/42 - Lotto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Next Draw Date: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total winnings on this month: ";
            // 
            // lblNextDrawDate
            // 
            this.lblNextDrawDate.AutoSize = true;
            this.lblNextDrawDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextDrawDate.Location = new System.Drawing.Point(114, 27);
            this.lblNextDrawDate.Name = "lblNextDrawDate";
            this.lblNextDrawDate.Size = new System.Drawing.Size(213, 20);
            this.lblNextDrawDate.TabIndex = 4;
            this.lblNextDrawDate.Text = "January 5, 2020 - Friday";
            // 
            // tabWinningNumbers
            // 
            this.tabWinningNumbers.Controls.Add(this.objListVwWinningNum);
            this.tabWinningNumbers.Location = new System.Drawing.Point(4, 25);
            this.tabWinningNumbers.Name = "tabWinningNumbers";
            this.tabWinningNumbers.Padding = new System.Windows.Forms.Padding(3);
            this.tabWinningNumbers.Size = new System.Drawing.Size(549, 472);
            this.tabWinningNumbers.TabIndex = 1;
            this.tabWinningNumbers.Text = "Winning Numbers";
            this.tabWinningNumbers.UseVisualStyleBackColor = true;
            this.tabWinningNumbers.Enter += new System.EventHandler(this.tabWinningNumbers_Enter);
            // 
            // objListVwWinningNum
            // 
            this.objListVwWinningNum.AllColumns.Add(this.olvColDrawDate);
            this.objListVwWinningNum.AllColumns.Add(this.olvColNum1);
            this.objListVwWinningNum.AllColumns.Add(this.olvColNum2);
            this.objListVwWinningNum.AllColumns.Add(this.olvColNum3);
            this.objListVwWinningNum.AllColumns.Add(this.olvColNum4);
            this.objListVwWinningNum.AllColumns.Add(this.olvColNum5);
            this.objListVwWinningNum.AllColumns.Add(this.olvColNum6);
            this.objListVwWinningNum.AllColumns.Add(this.olvColJackpot);
            this.objListVwWinningNum.AllColumns.Add(this.olvColWinners);
            this.objListVwWinningNum.CellEditUseWholeCell = false;
            this.objListVwWinningNum.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColDrawDate,
            this.olvColNum1,
            this.olvColNum2,
            this.olvColNum3,
            this.olvColNum4,
            this.olvColNum5,
            this.olvColNum6,
            this.olvColJackpot,
            this.olvColWinners});
            this.objListVwWinningNum.Cursor = System.Windows.Forms.Cursors.Default;
            this.objListVwWinningNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objListVwWinningNum.FullRowSelect = true;
            this.objListVwWinningNum.GridLines = true;
            this.objListVwWinningNum.HideSelection = false;
            this.objListVwWinningNum.Location = new System.Drawing.Point(3, 3);
            this.objListVwWinningNum.MultiSelect = false;
            this.objListVwWinningNum.Name = "objListVwWinningNum";
            this.objListVwWinningNum.ShowGroups = false;
            this.objListVwWinningNum.Size = new System.Drawing.Size(543, 466);
            this.objListVwWinningNum.TabIndex = 1;
            this.objListVwWinningNum.UseCompatibleStateImageBehavior = false;
            this.objListVwWinningNum.View = System.Windows.Forms.View.Details;
            this.objListVwWinningNum.VirtualMode = true;
            this.objListVwWinningNum.SelectionChanged += new System.EventHandler(this.objListVwWinningNum_SelectionChanged);
            // 
            // olvColDrawDate
            // 
            this.olvColDrawDate.AspectName = "GetDrawDateFormatted";
            this.olvColDrawDate.Text = "Draw Date";
            this.olvColDrawDate.UseFiltering = false;
            // 
            // olvColNum1
            // 
            this.olvColNum1.AspectName = "GetNum1";
            this.olvColNum1.Text = "#1";
            // 
            // olvColNum2
            // 
            this.olvColNum2.AspectName = "GetNum2";
            this.olvColNum2.Text = "#2";
            // 
            // olvColNum3
            // 
            this.olvColNum3.AspectName = "GetNum3";
            this.olvColNum3.Text = "#3";
            // 
            // olvColNum4
            // 
            this.olvColNum4.AspectName = "GetNum4";
            this.olvColNum4.Text = "#4";
            // 
            // olvColNum5
            // 
            this.olvColNum5.AspectName = "GetNum5";
            this.olvColNum5.Text = "#5";
            // 
            // olvColNum6
            // 
            this.olvColNum6.AspectName = "GetNum6";
            this.olvColNum6.Text = "#6";
            // 
            // olvColJackpot
            // 
            this.olvColJackpot.AspectName = "GetJackpotAmt";
            this.olvColJackpot.AspectToStringFormat = "{0:C}";
            this.olvColJackpot.Text = "Jackpot Amount";
            this.olvColJackpot.UseFiltering = false;
            // 
            // olvColWinners
            // 
            this.olvColWinners.AspectName = "Winners";
            this.olvColWinners.Searchable = false;
            this.olvColWinners.Text = "Winners Count";
            this.olvColWinners.UseFiltering = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnAddBet});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1233, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnAddBet
            // 
            this.toolStripBtnAddBet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnAddBet.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAddBet.Image")));
            this.toolStripBtnAddBet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAddBet.Name = "toolStripBtnAddBet";
            this.toolStripBtnAddBet.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnAddBet.Text = "Place A Bet";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 582);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lotto Data Manager";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.mainLeftTabControl.ResumeLayout(false);
            this.tabDashboard.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectLstVwLatestBet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabWinningNumbers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objListVwWinningNum)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLotteryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkLotteryUpdatesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem lotterySettingToolStripMenuItem;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem generatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem predictionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem luckyPickToolStripMenuItem;
        private System.Windows.Forms.TabControl mainLeftTabControl;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabWinningNumbers;
        private BrightIdeasSoftware.FastObjectListView objListVwWinningNum;
        private BrightIdeasSoftware.OLVColumn olvColDrawDate;
        private BrightIdeasSoftware.OLVColumn olvColNum1;
        private BrightIdeasSoftware.OLVColumn olvColNum2;
        private BrightIdeasSoftware.OLVColumn olvColNum3;
        private BrightIdeasSoftware.OLVColumn olvColNum4;
        private BrightIdeasSoftware.OLVColumn olvColNum5;
        private BrightIdeasSoftware.OLVColumn olvColNum6;
        private BrightIdeasSoftware.OLVColumn olvColJackpot;
        private BrightIdeasSoftware.OLVColumn olvColWinners;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnAddBet;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lossProfitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGameMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNextDrawDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblWinningsThisMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLifetimeWinnins;
        private System.Windows.Forms.Panel panel2;
        private BrightIdeasSoftware.FastObjectListView objectLstVwLatestBet;
        private System.Windows.Forms.Panel panel1;
        private BrightIdeasSoftware.OLVColumn olvColBetDrawDate;
        private BrightIdeasSoftware.OLVColumn olvColBetNum1;
        private BrightIdeasSoftware.OLVColumn olvColBetNum2;
        private BrightIdeasSoftware.OLVColumn olvColBetNum3;
        private BrightIdeasSoftware.OLVColumn olvColBetNum4;
        private BrightIdeasSoftware.OLVColumn olvColBetNum5;
        private BrightIdeasSoftware.OLVColumn olvColBetNum6;
        private BrightIdeasSoftware.OLVColumn olvColBetResult;
    }
}

