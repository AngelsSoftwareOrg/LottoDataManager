
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
            this.textBoxDelimitersInput = new System.Windows.Forms.TextBox();
            this.textBoxInstruction = new System.Windows.Forms.TextBox();
            this.tabPageClick = new System.Windows.Forms.TabPage();
            this.panelTicketNumbers = new System.Windows.Forms.Panel();
            this.groupBoxTicketPanel = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblLayoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.panelTicketControls = new System.Windows.Forms.Panel();
            this.linkLblClrSelNum = new System.Windows.Forms.LinkLabel();
            this.lblSelectedNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxLuckyPick = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBoxDateSelection = new System.Windows.Forms.GroupBox();
            this.radioBtnNextDrawDate = new System.Windows.Forms.RadioButton();
            this.radioBtnPreferredDate = new System.Windows.Forms.RadioButton();
            this.dtPickPreferredDate = new System.Windows.Forms.DateTimePicker();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.lblGameDesc = new System.Windows.Forms.Label();
            this.lblNextDrawDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControlInputs.SuspendLayout();
            this.tabPageDelimiters.SuspendLayout();
            this.tabPageClick.SuspendLayout();
            this.panelTicketNumbers.SuspendLayout();
            this.groupBoxTicketPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTicketControls.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxDateSelection.SuspendLayout();
            this.groupDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabControlInputs);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.groupBox1);
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
            this.tabControlInputs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.tabPageDelimiters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageDelimiters.Name = "tabPageDelimiters";
            this.tabPageDelimiters.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageDelimiters.Size = new System.Drawing.Size(442, 567);
            this.tabPageDelimiters.TabIndex = 0;
            this.tabPageDelimiters.Text = "Input by Delimiters";
            this.tabPageDelimiters.UseVisualStyleBackColor = true;
            // 
            // textBoxDelimitersInput
            // 
            this.textBoxDelimitersInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDelimitersInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDelimitersInput.Location = new System.Drawing.Point(3, 94);
            this.textBoxDelimitersInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDelimitersInput.Multiline = true;
            this.textBoxDelimitersInput.Name = "textBoxDelimitersInput";
            this.textBoxDelimitersInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDelimitersInput.Size = new System.Drawing.Size(436, 471);
            this.textBoxDelimitersInput.TabIndex = 1;
            // 
            // textBoxInstruction
            // 
            this.textBoxInstruction.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxInstruction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxInstruction.Location = new System.Drawing.Point(3, 2);
            this.textBoxInstruction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInstruction.Multiline = true;
            this.textBoxInstruction.Name = "textBoxInstruction";
            this.textBoxInstruction.ReadOnly = true;
            this.textBoxInstruction.Size = new System.Drawing.Size(436, 92);
            this.textBoxInstruction.TabIndex = 0;
            this.textBoxInstruction.Text = "Please input your 6 digits number in the textbox below per line, separated either" +
    " with space, hypen or a tab";
            // 
            // tabPageClick
            // 
            this.tabPageClick.Controls.Add(this.panelTicketNumbers);
            this.tabPageClick.Controls.Add(this.panelTicketControls);
            this.tabPageClick.Location = new System.Drawing.Point(4, 25);
            this.tabPageClick.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageClick.Name = "tabPageClick";
            this.tabPageClick.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageClick.Size = new System.Drawing.Size(442, 567);
            this.tabPageClick.TabIndex = 1;
            this.tabPageClick.Text = "Input By Ticket Layout";
            this.tabPageClick.UseVisualStyleBackColor = true;
            // 
            // panelTicketNumbers
            // 
            this.panelTicketNumbers.Controls.Add(this.groupBoxTicketPanel);
            this.panelTicketNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTicketNumbers.Location = new System.Drawing.Point(3, 139);
            this.panelTicketNumbers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTicketNumbers.Name = "panelTicketNumbers";
            this.panelTicketNumbers.Size = new System.Drawing.Size(436, 426);
            this.panelTicketNumbers.TabIndex = 1;
            // 
            // groupBoxTicketPanel
            // 
            this.groupBoxTicketPanel.Controls.Add(this.panel1);
            this.groupBoxTicketPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTicketPanel.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTicketPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxTicketPanel.Name = "groupBoxTicketPanel";
            this.groupBoxTicketPanel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxTicketPanel.Size = new System.Drawing.Size(436, 426);
            this.groupBoxTicketPanel.TabIndex = 0;
            this.groupBoxTicketPanel.TabStop = false;
            this.groupBoxTicketPanel.Text = "Select number on this game ticket";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tblLayoutPnl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 407);
            this.panel1.TabIndex = 2;
            // 
            // tblLayoutPnl
            // 
            this.tblLayoutPnl.ColumnCount = 2;
            this.tblLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPnl.Location = new System.Drawing.Point(5, 2);
            this.tblLayoutPnl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblLayoutPnl.Name = "tblLayoutPnl";
            this.tblLayoutPnl.RowCount = 2;
            this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutPnl.Size = new System.Drawing.Size(480, 433);
            this.tblLayoutPnl.TabIndex = 3;
            // 
            // panelTicketControls
            // 
            this.panelTicketControls.Controls.Add(this.linkLblClrSelNum);
            this.panelTicketControls.Controls.Add(this.lblSelectedNumber);
            this.panelTicketControls.Controls.Add(this.label2);
            this.panelTicketControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTicketControls.Location = new System.Drawing.Point(3, 2);
            this.panelTicketControls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTicketControls.Name = "panelTicketControls";
            this.panelTicketControls.Size = new System.Drawing.Size(436, 137);
            this.panelTicketControls.TabIndex = 0;
            // 
            // linkLblClrSelNum
            // 
            this.linkLblClrSelNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLblClrSelNum.AutoSize = true;
            this.linkLblClrSelNum.Location = new System.Drawing.Point(323, 114);
            this.linkLblClrSelNum.Name = "linkLblClrSelNum";
            this.linkLblClrSelNum.Size = new System.Drawing.Size(110, 17);
            this.linkLblClrSelNum.TabIndex = 10;
            this.linkLblClrSelNum.TabStop = true;
            this.linkLblClrSelNum.Text = "Clear Selections";
            this.linkLblClrSelNum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblClrSelNum_LinkClicked);
            // 
            // lblSelectedNumber
            // 
            this.lblSelectedNumber.AutoSize = true;
            this.lblSelectedNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedNumber.ForeColor = System.Drawing.Color.Teal;
            this.lblSelectedNumber.Location = new System.Drawing.Point(43, 51);
            this.lblSelectedNumber.Name = "lblSelectedNumber";
            this.lblSelectedNumber.Size = new System.Drawing.Size(339, 44);
            this.lblSelectedNumber.TabIndex = 9;
            this.lblSelectedNumber.Text = "11 10 20 30 40 50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "You selected number: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxLuckyPick);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbOutlet);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 145);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(771, 95);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Where did you buy the ticket?";
            // 
            // checkBoxLuckyPick
            // 
            this.checkBoxLuckyPick.AutoSize = true;
            this.checkBoxLuckyPick.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLuckyPick.Location = new System.Drawing.Point(16, 61);
            this.checkBoxLuckyPick.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxLuckyPick.Name = "checkBoxLuckyPick";
            this.checkBoxLuckyPick.Size = new System.Drawing.Size(130, 21);
            this.checkBoxLuckyPick.TabIndex = 11;
            this.checkBoxLuckyPick.Text = "Is it Lucky Pick?";
            this.checkBoxLuckyPick.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Lotto Outlet:";
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOutlet.BackColor = System.Drawing.SystemColors.Window;
            this.cmbOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutlet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutlet.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(117, 25);
            this.cmbOutlet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(491, 26);
            this.cmbOutlet.Sorted = true;
            this.cmbOutlet.TabIndex = 9;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(4, 244);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(766, 273);
            this.txtStatus.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(421, 523);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(201, 62);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Save Sequence(s)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(629, 523);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 62);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBoxDateSelection
            // 
            this.groupBoxDateSelection.Controls.Add(this.radioBtnNextDrawDate);
            this.groupBoxDateSelection.Controls.Add(this.radioBtnPreferredDate);
            this.groupBoxDateSelection.Controls.Add(this.dtPickPreferredDate);
            this.groupBoxDateSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDateSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDateSelection.Location = new System.Drawing.Point(0, 81);
            this.groupBoxDateSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDateSelection.Name = "groupBoxDateSelection";
            this.groupBoxDateSelection.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDateSelection.Size = new System.Drawing.Size(771, 64);
            this.groupBoxDateSelection.TabIndex = 2;
            this.groupBoxDateSelection.TabStop = false;
            this.groupBoxDateSelection.Text = "Select Draw Date for the inputted Numbers";
            // 
            // radioBtnNextDrawDate
            // 
            this.radioBtnNextDrawDate.AutoSize = true;
            this.radioBtnNextDrawDate.Checked = true;
            this.radioBtnNextDrawDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnNextDrawDate.Location = new System.Drawing.Point(16, 30);
            this.radioBtnNextDrawDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioBtnNextDrawDate.Name = "radioBtnNextDrawDate";
            this.radioBtnNextDrawDate.Size = new System.Drawing.Size(127, 21);
            this.radioBtnNextDrawDate.TabIndex = 3;
            this.radioBtnNextDrawDate.TabStop = true;
            this.radioBtnNextDrawDate.Text = "Next Draw Date";
            this.radioBtnNextDrawDate.UseVisualStyleBackColor = true;
            this.radioBtnNextDrawDate.CheckedChanged += new System.EventHandler(this.radioBtnNextDrawDate_CheckedChanged);
            // 
            // radioBtnPreferredDate
            // 
            this.radioBtnPreferredDate.AutoSize = true;
            this.radioBtnPreferredDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnPreferredDate.Location = new System.Drawing.Point(155, 30);
            this.radioBtnPreferredDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioBtnPreferredDate.Name = "radioBtnPreferredDate";
            this.radioBtnPreferredDate.Size = new System.Drawing.Size(123, 21);
            this.radioBtnPreferredDate.TabIndex = 2;
            this.radioBtnPreferredDate.Text = "Preferred Date";
            this.radioBtnPreferredDate.UseVisualStyleBackColor = true;
            this.radioBtnPreferredDate.CheckedChanged += new System.EventHandler(this.radioBtnPreferredDate_CheckedChanged);
            // 
            // dtPickPreferredDate
            // 
            this.dtPickPreferredDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickPreferredDate.Location = new System.Drawing.Point(287, 30);
            this.dtPickPreferredDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtPickPreferredDate.Name = "dtPickPreferredDate";
            this.dtPickPreferredDate.Size = new System.Drawing.Size(321, 24);
            this.dtPickPreferredDate.TabIndex = 1;
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
            this.groupDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupDetails.Size = new System.Drawing.Size(771, 81);
            this.groupDetails.TabIndex = 1;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Current game: ";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Next Draw Date: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Game Mode: ";
            // 
            // AddBetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 596);
            this.Controls.Add(this.splitContainerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.panelTicketNumbers.ResumeLayout(false);
            this.groupBoxTicketPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelTicketControls.ResumeLayout(false);
            this.panelTicketControls.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxDateSelection.ResumeLayout(false);
            this.groupBoxDateSelection.PerformLayout();
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
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
        private System.Windows.Forms.Panel panelTicketNumbers;
        private System.Windows.Forms.Panel panelTicketControls;
        private System.Windows.Forms.GroupBox groupBoxTicketPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPnl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxLuckyPick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelectedNumber;
        private System.Windows.Forms.LinkLabel linkLblClrSelNum;
    }
}