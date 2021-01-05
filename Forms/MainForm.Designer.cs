
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
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkLotteryUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lotterySettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.generatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.predictionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luckyPickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLeftTabControl = new System.Windows.Forms.TabControl();
            this.tabWinningNumbers = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewWinningNumbers = new System.Windows.Forms.DataGridView();
            this.mainMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.mainLeftTabControl.SuspendLayout();
            this.tabWinningNumbers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWinningNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generatorsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.othersToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1215, 28);
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
            this.openLotteryToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openLotteryToolStripMenuItem.Text = "Open Lottery";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lotterySettingToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
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
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 561);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1215, 26);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(62, 20);
            this.toolStripStatusLabel1.Text = "Lottery: ";
            // 
            // lotterySettingToolStripMenuItem
            // 
            this.lotterySettingToolStripMenuItem.Name = "lotterySettingToolStripMenuItem";
            this.lotterySettingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.lotterySettingToolStripMenuItem.Text = "Lottery Setting";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 28);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.mainLeftTabControl);
            this.mainSplitContainer.Size = new System.Drawing.Size(1215, 533);
            this.mainSplitContainer.SplitterDistance = 750;
            this.mainSplitContainer.TabIndex = 2;
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
            this.predictionsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.predictionsToolStripMenuItem.Text = "Predictions";
            // 
            // luckyPickToolStripMenuItem
            // 
            this.luckyPickToolStripMenuItem.Name = "luckyPickToolStripMenuItem";
            this.luckyPickToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.luckyPickToolStripMenuItem.Text = "Lucky Pick";
            // 
            // mainLeftTabControl
            // 
            this.mainLeftTabControl.Controls.Add(this.tabWinningNumbers);
            this.mainLeftTabControl.Controls.Add(this.tabPage2);
            this.mainLeftTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLeftTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainLeftTabControl.Name = "mainLeftTabControl";
            this.mainLeftTabControl.SelectedIndex = 0;
            this.mainLeftTabControl.Size = new System.Drawing.Size(750, 533);
            this.mainLeftTabControl.TabIndex = 0;
            // 
            // tabWinningNumbers
            // 
            this.tabWinningNumbers.Controls.Add(this.dataGridViewWinningNumbers);
            this.tabWinningNumbers.Location = new System.Drawing.Point(4, 25);
            this.tabWinningNumbers.Name = "tabWinningNumbers";
            this.tabWinningNumbers.Padding = new System.Windows.Forms.Padding(3);
            this.tabWinningNumbers.Size = new System.Drawing.Size(742, 504);
            this.tabWinningNumbers.TabIndex = 0;
            this.tabWinningNumbers.Text = "Winning Numbers";
            this.tabWinningNumbers.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(742, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWinningNumbers
            // 
            this.dataGridViewWinningNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWinningNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWinningNumbers.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWinningNumbers.Name = "dataGridViewWinningNumbers";
            this.dataGridViewWinningNumbers.RowHeadersWidth = 51;
            this.dataGridViewWinningNumbers.RowTemplate.Height = 24;
            this.dataGridViewWinningNumbers.Size = new System.Drawing.Size(736, 498);
            this.dataGridViewWinningNumbers.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 587);
            this.Controls.Add(this.mainSplitContainer);
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
            this.tabWinningNumbers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWinningNumbers)).EndInit();
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
        private System.Windows.Forms.TabPage tabWinningNumbers;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewWinningNumbers;
    }
}

