using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Includes.Classes;
using LottoDataManager.Includes.Classes.Generator;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Forms
{
    public partial class AddBetFrm : Form
    {
        private LotteryDataServices lotteryDataServices;
        private LotteryTicketPanel lotteryTicketPanel;
        private List<LotteryOutlet> lotteryOutletArr;
        private List<LotterySequenceGenerator> lotterySeqGenArr;
        private List<Button> selTcktPnlNum = new List<Button>();
        private LotterySchedule lotterySchedule;
        private bool hasDataBeenSave = false;

        public AddBetFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();
            this.lotteryDataServices = lotteryDataServices;

            this.lotteryTicketPanel = this.lotteryDataServices.GetLotteryTicketPanel();
            this.lotteryOutletArr = this.lotteryDataServices.GetLotteryOutlets();
            this.lotterySchedule = this.lotteryDataServices.GetLotterySchedule();
            this.lotterySeqGenArr = this.lotteryDataServices.GetAllSequenceGenerators();

            //need to place it here so that other form calling this form may preset the combo box before showing the form
            cmbOutlet.Items.AddRange(lotteryOutletArr.ToArray());
            cmbSeqGenType.Items.AddRange(lotterySeqGenArr.ToArray());
            GenerateTicketPanelNumbers();
        }
        private void AddBetFrm_Load(object sender, EventArgs e)
        {
            textBoxInstruction.Text = "Please input your " + lotteryTicketPanel.GetGameDigitCount() +
                                      " digits number in the textbox below per line, " +
                                      "separated each numbers either with space, hypen or a tab. e.g. \r\n" +
                                      "21 34 57 45 28 44 (spaces) \r\n" +
                                      "22-25-48-55-18-15 (hypen) \r\n " +
                                      "etc...";

            lblGameDesc.Text = lotteryDataServices.LotteryDetails.Description;
            lblNextDrawDate.Text = lotteryDataServices.GetNextDrawDateFormatted();
            lblDrawDateEvery.Text = lotterySchedule.DrawDateEvery();
            AddSelectedTicketPanelNumber();
            radioBtnNextDrawDate.Checked = true;
            dtPickPreferredDate.Visible = false;

            //select default if no selection
            if(cmbSeqGenType.SelectedItem == null) SelectedSequenceGenerator = GeneratorType.PERSONAL_PICK;
        }
        public GeneratorType SelectedSequenceGenerator
        {
            set
            {
                GeneratorType genType = value;
                foreach(LotterySequenceGenerator g in cmbSeqGenType.Items)
                {
                    if (g.GetSeqGenCode() == (int)genType)
                    {
                        cmbSeqGenType.SelectedItem = g;
                        break;
                    }
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            if (!this.hasDataBeenSave) return;
            if (ClassReflectionUtil.IsMainForm(this.Owner))
            {
                MainForm f = (MainForm)this.Owner;
                f.RefreshBets();
            }
        }
        private void DisplayLog(String log)
        {
            txtStatus.AppendText("> " + log + Environment.NewLine);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                txtStatus.Clear();
                DisplayLog("Preparing to add your bet....");
                Application.DoEvents();
                InputFormDataValidation();

                DialogResult dr = MessageBox.Show("Check your inputs and hit ok to continue...", "Double check please!", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    DisplayLog("Compiling delimiter input bets...");
                    List<LotteryBet> lotteryBetArr = ValidateAndCompileData();
                    DisplayLog("Saving your bets ...");
                    this.Enabled = false;
                    Application.DoEvents();
                    this.lotteryDataServices.SaveLotteryBets(lotteryBetArr);
                    DisplayLog("FINISH SAVING your bets!!!!");
                    this.Enabled = true;
                    this.hasDataBeenSave = true;
                    Application.DoEvents();
                }
                else
                {
                    DisplayLog("Saving cancelled...");
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                DisplayLog(ex.Message);
                Application.DoEvents();
                MessageBox.Show(ex.Message, "Error!");
            }
        }
        private List<LotteryBet> ValidateAndCompileData()
        {
            List<LotteryBet> lotteryBetArr = new List<LotteryBet>();
            try
            {
                if (tabControlInputs.SelectedTab == tabPageDelimiters)
                {
                    foreach (string line in StringUtils.GetLines(textBoxDelimitersInput.Text))
                    {
                        if (String.IsNullOrWhiteSpace(line)) continue;
                        DisplayLog("Validating -> " + line);
                        //validation
                        String[] splitted = null;
                        foreach (String delimiter in StringUtils.COMMON_DELIMITERS)
                        {
                            splitted = line.Split(delimiter.ToCharArray());
                            if (splitted == null) continue;
                            if (splitted.Length != 6) continue;
                            if (IsNumberSequenceValid(splitted)) break;
                        }
                        LotteryBetSetup lotteryBet = new LotteryBetSetup();
                        lotteryBet.PutNumberSequence(line);
                        CompleteLotteryBetDetails(lotteryBet);
                        lotteryBetArr.Add(lotteryBet);
                    }
                    if (lotteryBetArr.Count <= 0) throw new Exception("Please put your bet in sequence");

                }
                else if (tabControlInputs.SelectedTab == tabPageClick)
                {
                    DisplayLog("Validating selected numbers... ");
                    LotteryBetSetup lotteryBet = new LotteryBetSetup();
                    lotteryBet.PutNumberSequence(lblSelectedNumber.Text.Replace(" ", ""));
                    CompleteLotteryBetDetails(lotteryBet);
                    lotteryBetArr.Add(lotteryBet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lotteryBetArr;
        }
        private void CompleteLotteryBetDetails(LotteryBetSetup lotteryBet)
        {
            lotteryBet.GameCode = this.lotteryDataServices.LotteryDetails.GameCode;
            lotteryBet.LotterySeqGen = (LotterySequenceGenerator) cmbSeqGenType.SelectedItem;
            lotteryBet.TargetDrawDate = (radioBtnPreferredDate.Checked) ? dtPickPreferredDate.Value : lotteryDataServices.GetNextDrawDate();
            lotteryBet.BetAmount = lotteryDataServices.LotteryDetails.Lottery.GetPricePerBet();
            lotteryBet.OutletCode = ((LotteryOutlet)cmbOutlet.SelectedItem).GetOutletCode();
        }
        private bool IsNumberSequenceValid(String[] numberSequence)
        {
            int convertedNum = 0;
            foreach (String num in numberSequence)
            {
                if (!int.TryParse(num, out convertedNum)) throw new Exception("Input number is not accepted or out of bounds for the game minimum and maximum number range");
                if (convertedNum < this.lotteryTicketPanel.GetMin() || convertedNum > this.lotteryTicketPanel.GetMax())
                {
                    throw new Exception(String.Format("Input number should be between {0} and {1}.", this.lotteryTicketPanel.GetMin(), this.lotteryTicketPanel.GetMax()));
                }
            }
            return true;
        }
        private bool InputFormDataValidation()
        {
            DateTime nextDrawDate = (radioBtnPreferredDate.Checked) ? dtPickPreferredDate.Value :
                                this.lotteryDataServices.GetNextDrawDate();
            DisplayLog("Checking selected draw date...");
            //RADIO BUTTON
            if (nextDrawDate.Date.CompareTo(DateTime.Now.Date) < 0)
            {
                DisplayLog("Selected date is a backdated date. Please be careful when choosing the date");
            }
            DisplayLog("Checking lotto outlet.");
            if (cmbOutlet.SelectedItem == null || String.IsNullOrWhiteSpace(cmbOutlet.SelectedItem.ToString()))
                throw new Exception("Please select the Lotto Outlet where you purchase the ticket.");

            DisplayLog("Checking Lotto Draw Date selection...");
            if (!radioBtnNextDrawDate.Checked && !radioBtnPreferredDate.Checked)
            {
                throw new Exception("Please select when your purchased ticket(s) draw date...");
            }
            if (radioBtnPreferredDate.Checked)
            {
                if (!lotterySchedule.IsDrawDateMatchLotterySchedule(dtPickPreferredDate.Value))
                {
                    String msg = String.Format("Please select the date where it match its scheduled draw date. \n" +
                        "You selected {0}, but the draw date is every {1}.",
                        dtPickPreferredDate.Value.Date.ToString("MMMM d - dddd"),
                        this.lotterySchedule.DrawDateEvery());
                    throw new Exception(msg);
                }
            }
            return true;
        }
        private void GenerateTicketPanelNumbers()
        {
            tblLayoutPnl.ColumnStyles.Clear();
            tblLayoutPnl.RowStyles.Clear();
            tblLayoutPnl.ColumnCount = lotteryTicketPanel.GetCols();
            tblLayoutPnl.RowCount = 1;

            int rowsCount = lotteryTicketPanel.GetRows();
            int colsCount = lotteryTicketPanel.GetCols();
            Single percHeight = ((Single)1 / (Single)rowsCount) * 100;
            Single percWidth = ((Single)1 / (Single)colsCount) * 100;

            for (int ctr = 1; ctr <= colsCount; ctr++)
            {
                tblLayoutPnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percWidth));
            }
            for (int rowCtr = 1; rowCtr <= rowsCount; rowCtr++)
            {
                tblLayoutPnl.RowCount = tblLayoutPnl.RowCount + 1;
                tblLayoutPnl.RowStyles.Add(new ColumnStyle(SizeType.AutoSize));

                for (int colCtr = 1; colCtr <= colsCount; colCtr++)
                {
                    int btnLbl = colCtr;
                    if (lotteryTicketPanel.GetNumberDirection() == NumberDirection.LEFT_TO_RIGHT)
                    {
                        btnLbl = colCtr + ((rowCtr - 1) * colsCount);
                    }
                    else //NumberDirection.TOP_TO_BOTTOM
                    {
                        btnLbl = rowCtr + ((colCtr * rowsCount) - rowsCount);
                    }

                    if (btnLbl <= lotteryTicketPanel.GetMax())
                    {
                        Button btn = new Button();
                        btn.Text = btnLbl.ToString();
                        btn.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = Color.Red;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.ForeColor = Color.Black;

                        DecorateTicketPanelButtonNum(btn, false);
                        btn.Dock = System.Windows.Forms.DockStyle.Fill;
                        btn.Click += TicketPanel_Btn_Click;
                        btn.Tag = btnLbl; //store the number it represents
                        btn.Name = "btnNum" + btnLbl;
                        tblLayoutPnl.Controls.Add(btn, colCtr - 1, tblLayoutPnl.RowCount - 1);
                    }
                    else
                    {
                        tblLayoutPnl.Controls.Add(new Label() { Text = "" }, colCtr - 1, tblLayoutPnl.RowCount - 1);
                    }
                }
            }

            /**
             * Excess row below, for same square cell purpose
             * so that the last row or column is the same square as everyone else.
             */
            tblLayoutPnl.RowCount = tblLayoutPnl.RowCount + 1;
            tblLayoutPnl.RowStyles.Add(new ColumnStyle(SizeType.AutoSize));
            for (int n = 1; n <= colsCount; n++)
            {
                tblLayoutPnl.Controls.Add(new Label() { Text = "" }, n - 1, tblLayoutPnl.RowCount - 1);
            }
        }
        private void DecorateTicketPanelButtonNum(Button targetButtonToDecorate, bool isClicked)
        {
            if (isClicked)
            {
                targetButtonToDecorate.BackColor = Color.Yellow;
            }
            else
            {
                targetButtonToDecorate.BackColor = Color.White;
            }
        }
        private bool IsTicketPanelButtonSelected(Button btn)
        {
            return (btn.BackColor == Color.Yellow);
        }
        private void TicketPanel_Btn_Click(object sender, EventArgs e)
        {
            Button btnNum = (Button)sender;
            if (IsTicketPanelButtonSelected(btnNum))
            {
                selTcktPnlNum.Remove(btnNum);
                DecorateTicketPanelButtonNum(btnNum, false);
                AddSelectedTicketPanelNumber();
            }
            else if (selTcktPnlNum.Count < (lotteryTicketPanel.GetGameDigitCount()))
            {
                DecorateTicketPanelButtonNum(btnNum, true);
                AddSelectedTicketPanelNumber(btnNum);
            }
        }
        private void AddSelectedTicketPanelNumber(Button btnNumClicked = null)
        {
            if (btnNumClicked != null) selTcktPnlNum.Add(btnNumClicked);
            String numSelected = "";
            for (int ctr = 0; ctr < lotteryTicketPanel.GetGameDigitCount(); ctr++)
            {
                if (ctr > 0) numSelected += " - ";
                Button btn = ((selTcktPnlNum.Count) >= (ctr + 1)) ? (Button)selTcktPnlNum[ctr] : null;
                numSelected += (btn == null) ? "00" : btn.Text.PadLeft(2, char.Parse("0"));
            }
            lblSelectedNumber.Text = numSelected;
        }
        private void linkLblClrSelNum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selTcktPnlNum.Clear();
            AddSelectedTicketPanelNumber();
            foreach (Control control in tblLayoutPnl.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    DecorateTicketPanelButtonNum((Button)control, false);
                }
            }
        }
        private void radioBtnPreferredDate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnPreferredDate.Checked)
            {
                dtPickPreferredDate.Visible = true;
                Application.DoEvents();
            }
        }
        private void radioBtnNextDrawDate_CheckedChanged(object sender, EventArgs e)
        {
            dtPickPreferredDate.Visible = false;
            Application.DoEvents();
        }


        #region Public Interface"
        public void AddSequenceEntry(String sequence)
        {
            if (textBoxDelimitersInput.Text.Length > 0) textBoxDelimitersInput.AppendText(Environment.NewLine);
            textBoxDelimitersInput.AppendText(sequence);
        }
        public void ClearSequenceEntries()
        {
            textBoxDelimitersInput.Text = "";
        }
        #endregion


    }
}
