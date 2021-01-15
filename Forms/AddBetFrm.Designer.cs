
namespace LottoDataManager.Forms
{
    partial class AddBetFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBetFrm));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tabControlInputs = new System.Windows.Forms.TabControl();
            this.tabPageDelimiters = new System.Windows.Forms.TabPage();
            this.tabPageClick = new System.Windows.Forms.TabPage();
            this.textBoxInstruction = new System.Windows.Forms.TextBox();
            this.textBoxDelimitersInput = new System.Windows.Forms.TextBox();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxDateSelection = new System.Windows.Forms.GroupBox();
            this.dtPickPreferredDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNextDrawDate = new System.Windows.Forms.Label();
            this.lblGameDesc = new System.Windows.Forms.Label();
            this.radioBtnPreferredDate = new System.Windows.Forms.RadioButton();
            this.radioBtnNextDrawDate = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.checkBoxLuckyPick = new System.Windows.Forms.CheckBox();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTicketControls = new System.Windows.Forms.Panel();
            this.panelTicketNumbers = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxTicketPanel = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControlInputs.SuspendLayout();
            this.tabPageDelimiters.SuspendLayout();
            this.tabPageClick.SuspendLayout();
            this.groupDetails.SuspendLayout();
            this.groupBoxDateSelection.SuspendLayout();
            this.panelTicketControls.SuspendLayout();
            this.panelTicketNumbers.SuspendLayout();
            this.groupBoxTicketPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabControlInputs);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.txtStatus);
            this.splitContainerMain.Panel2.Controls.Add(this.btnAdd);
            this.splitContainerMain.Panel2.Controls.Add(this.btnExit);
            this.splitContainerMain.Panel2.Controls.Add(this.groupBoxDateSelection);
            this.splitContainerMain.Panel2.Controls.Add(this.groupDetails);
            this.splitContainerMain.Size = new System.Drawing.Size(1225, 596);
            this.splitContainerMain.SplitterDistance = 450;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tabControlInputs
            // 
            this.tabControlInputs.Controls.Add(this.tabPageDelimiters);
            this.tabControlInputs.Controls.Add(this.tabPageClick);
            this.tabControlInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInputs.Location = new System.Drawing.Point(0, 0);
            this.tabControlInputs.Name = "tabControlInputs";
            this.tabControlInputs.SelectedIndex = 0;
            this.tabControlInputs.Size = new System.Drawing.Size(450, 596);
            this.tabControlInputs.TabIndex = 0;
            // 
            // tabPageDelimiters
            // 
            this.tabPageDelimiters.Controls.Add(this.textBoxDelimitersInput);
            this.tabPageDelimiters.Controls.Add(this.textBoxInstruction);
            this.tabPageDelimiters.Location = new System.Drawing.Point(4, 25);
            this.tabPageDelimiters.Name = "tabPageDelimiters";
            this.tabPageDelimiters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDelimiters.Size = new System.Drawing.Size(442, 620);
            this.tabPageDelimiters.TabIndex = 0;
            this.tabPageDelimiters.Text = "Input by Delimiters";
            this.tabPageDelimiters.UseVisualStyleBackColor = true;
            // 
            // tabPageClick
            // 
            this.tabPageClick.Controls.Add(this.panelTicketNumbers);
            this.tabPageClick.Controls.Add(this.panelTicketControls);
            this.tabPageClick.Location = new System.Drawing.Point(4, 25);
            this.tabPageClick.Name = "tabPageClick";
            this.tabPageClick.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClick.Size = new System.Drawing.Size(442, 567);
            this.tabPageClick.TabIndex = 1;
            this.tabPageClick.Text = "Input By Ticket Layout";
            this.tabPageClick.UseVisualStyleBackColor = true;
            // 
            // textBoxInstruction
            // 
            this.textBoxInstruction.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxInstruction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxInstruction.Location = new System.Drawing.Point(3, 3);
            this.textBoxInstruction.Multiline = true;
            this.textBoxInstruction.Name = "textBoxInstruction";
            this.textBoxInstruction.ReadOnly = true;
            this.textBoxInstruction.Size = new System.Drawing.Size(436, 101);
            this.textBoxInstruction.TabIndex = 0;
            this.textBoxInstruction.Text = "Please input your 6 digits number in the textbox below per line, separated either" +
    " with space, hypen or a tab";
            // 
            // textBoxDelimitersInput
            // 
            this.textBoxDelimitersInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDelimitersInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDelimitersInput.Location = new System.Drawing.Point(3, 104);
            this.textBoxDelimitersInput.Multiline = true;
            this.textBoxDelimitersInput.Name = "textBoxDelimitersInput";
            this.textBoxDelimitersInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDelimitersInput.Size = new System.Drawing.Size(436, 513);
            this.textBoxDelimitersInput.TabIndex = 1;
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.lblGameDesc);
            this.groupDetails.Controls.Add(this.lblNextDrawDate);
            this.groupDetails.Controls.Add(this.label4);
            this.groupDetails.Controls.Add(this.label3);
            this.groupDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDetails.Location = new System.Drawing.Point(0, 0);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(771, 81);
            this.groupDetails.TabIndex = 1;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Current game: ";
            // 
            // groupBoxDateSelection
            // 
            this.groupBoxDateSelection.Controls.Add(this.label1);
            this.groupBoxDateSelection.Controls.Add(this.cmbOutlet);
            this.groupBoxDateSelection.Controls.Add(this.checkBoxLuckyPick);
            this.groupBoxDateSelection.Controls.Add(this.radioBtnNextDrawDate);
            this.groupBoxDateSelection.Controls.Add(this.radioBtnPreferredDate);
            this.groupBoxDateSelection.Controls.Add(this.dtPickPreferredDate);
            this.groupBoxDateSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDateSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDateSelection.Location = new System.Drawing.Point(0, 81);
            this.groupBoxDateSelection.Name = "groupBoxDateSelection";
            this.groupBoxDateSelection.Size = new System.Drawing.Size(771, 162);
            this.groupBoxDateSelection.TabIndex = 2;
            this.groupBoxDateSelection.TabStop = false;
            this.groupBoxDateSelection.Text = "Select Draw Date for the inputted Numbers";
            // 
            // dtPickPreferredDate
            // 
            this.dtPickPreferredDate.Location = new System.Drawing.Point(16, 56);
            this.dtPickPreferredDate.Name = "dtPickPreferredDate";
            this.dtPickPreferredDate.Size = new System.Drawing.Size(407, 22);
            this.dtPickPreferredDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Game Mode: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Next Draw Date: ";
            // 
            // lblNextDrawDate
            // 
            this.lblNextDrawDate.AutoSize = true;
            this.lblNextDrawDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextDrawDate.ForeColor = System.Drawing.Color.Tomato;
            this.lblNextDrawDate.Location = new System.Drawing.Point(113, 49);
            this.lblNextDrawDate.Name = "lblNextDrawDate";
            this.lblNextDrawDate.Size = new System.Drawing.Size(206, 18);
            this.lblNextDrawDate.TabIndex = 5;
            this.lblNextDrawDate.Text = "January 5, 2020 - Tuesday";
            // 
            // lblGameDesc
            // 
            this.lblGameDesc.AutoSize = true;
            this.lblGameDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameDesc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblGameDesc.Location = new System.Drawing.Point(95, 21);
            this.lblGameDesc.Name = "lblGameDesc";
            this.lblGameDesc.Size = new System.Drawing.Size(158, 24);
            this.lblGameDesc.TabIndex = 6;
            this.lblGameDesc.Text = "6/58 Mega Lotto";
            // 
            // radioBtnPreferredDate
            // 
            this.radioBtnPreferredDate.AutoSize = true;
            this.radioBtnPreferredDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnPreferredDate.Location = new System.Drawing.Point(16, 29);
            this.radioBtnPreferredDate.Name = "radioBtnPreferredDate";
            this.radioBtnPreferredDate.Size = new System.Drawing.Size(123, 21);
            this.radioBtnPreferredDate.TabIndex = 2;
            this.radioBtnPreferredDate.Text = "Preferred Date";
            this.radioBtnPreferredDate.UseVisualStyleBackColor = true;
            // 
            // radioBtnNextDrawDate
            // 
            this.radioBtnNextDrawDate.AutoSize = true;
            this.radioBtnNextDrawDate.Checked = true;
            this.radioBtnNextDrawDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnNextDrawDate.Location = new System.Drawing.Point(145, 29);
            this.radioBtnNextDrawDate.Name = "radioBtnNextDrawDate";
            this.radioBtnNextDrawDate.Size = new System.Drawing.Size(127, 21);
            this.radioBtnNextDrawDate.TabIndex = 3;
            this.radioBtnNextDrawDate.TabStop = true;
            this.radioBtnNextDrawDate.Text = "Next Draw Date";
            this.radioBtnNextDrawDate.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(626, 523);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 61);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(487, 523);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 61);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add bets";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(4, 249);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(764, 268);
            this.txtStatus.TabIndex = 5;
            // 
            // checkBoxLuckyPick
            // 
            this.checkBoxLuckyPick.AutoSize = true;
            this.checkBoxLuckyPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLuckyPick.Location = new System.Drawing.Point(16, 135);
            this.checkBoxLuckyPick.Name = "checkBoxLuckyPick";
            this.checkBoxLuckyPick.Size = new System.Drawing.Size(105, 21);
            this.checkBoxLuckyPick.TabIndex = 4;
            this.checkBoxLuckyPick.Text = "Lucky Pick?";
            this.checkBoxLuckyPick.UseVisualStyleBackColor = true;
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.BackColor = System.Drawing.SystemColors.Window;
            this.cmbOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutlet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutlet.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(16, 104);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(407, 24);
            this.cmbOutlet.Sorted = true;
            this.cmbOutlet.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Lotto Outlet:";
            // 
            // panelTicketControls
            // 
            this.panelTicketControls.Controls.Add(this.label2);
            this.panelTicketControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTicketControls.Location = new System.Drawing.Point(3, 3);
            this.panelTicketControls.Name = "panelTicketControls";
            this.panelTicketControls.Size = new System.Drawing.Size(436, 154);
            this.panelTicketControls.TabIndex = 0;
            // 
            // panelTicketNumbers
            // 
            this.panelTicketNumbers.Controls.Add(this.groupBoxTicketPanel);
            this.panelTicketNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTicketNumbers.Location = new System.Drawing.Point(3, 157);
            this.panelTicketNumbers.Name = "panelTicketNumbers";
            this.panelTicketNumbers.Size = new System.Drawing.Size(436, 407);
            this.panelTicketNumbers.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please choose number below";
            // 
            // groupBoxTicketPanel
            // 
            this.groupBoxTicketPanel.Controls.Add(this.panel1);
            this.groupBoxTicketPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTicketPanel.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTicketPanel.Name = "groupBoxTicketPanel";
            this.groupBoxTicketPanel.Size = new System.Drawing.Size(436, 407);
            this.groupBoxTicketPanel.TabIndex = 0;
            this.groupBoxTicketPanel.TabStop = false;
            this.groupBoxTicketPanel.Text = "Select number on this game ticket";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tblLayoutPnl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 386);
            this.panel1.TabIndex = 2;
            // 
            // tblLayoutPnl
            // 
            this.tblLayoutPnl.ColumnCount = 2;
            this.tblLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPnl.Location = new System.Drawing.Point(5, 3);
            this.tblLayoutPnl.Name = "tblLayoutPnl";
            this.tblLayoutPnl.RowCount = 2;
            this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPnl.Size = new System.Drawing.Size(480, 433);
            this.tblLayoutPnl.TabIndex = 3;
            // 
            // AddBetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 596);
            this.Controls.Add(this.splitContainerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddBetFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Bet Template";
            this.Load += new System.EventHandler(this.AddBetFrm_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabControlInputs.ResumeLayout(false);
            this.tabPageDelimiters.ResumeLayout(false);
            this.tabPageDelimiters.PerformLayout();
            this.tabPageClick.ResumeLayout(false);
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.groupBoxDateSelection.ResumeLayout(false);
            this.groupBoxDateSelection.PerformLayout();
            this.panelTicketControls.ResumeLayout(false);
            this.panelTicketControls.PerformLayout();
            this.panelTicketNumbers.ResumeLayout(false);
            this.groupBoxTicketPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabControl tabControlInputs;
        private System.Windows.Forms.TabPage tabPageDelimiters;
        private System.Windows.Forms.TabPage tabPageClick;
        private System.Windows.Forms.TextBox textBoxInstruction;
        private System.Windows.Forms.TextBox textBoxDelimitersInput;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.GroupBox groupBoxDateSelection;
        private System.Windows.Forms.DateTimePicker dtPickPreferredDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGameDesc;
        private System.Windows.Forms.Label lblNextDrawDate;
        private System.Windows.Forms.RadioButton radioBtnNextDrawDate;
        private System.Windows.Forms.RadioButton radioBtnPreferredDate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.CheckBox checkBoxLuckyPick;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTicketNumbers;
        private System.Windows.Forms.Panel panelTicketControls;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxTicketPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPnl;
    }
}