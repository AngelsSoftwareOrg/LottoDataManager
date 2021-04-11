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
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;
using LottoDataManager.Properties;

namespace LottoDataManager.Forms
{
    public partial class DrawAndBetMatchFrm : Form
    {
        private DateTime betDateTime;
        private LotteryDataServices lotteryDataServices;
        private LotteryTicketPanel lotteryTicketPanel;
        private LotteryDrawResult drawResult;
        private readonly String FILLER_NAME = "filler";
        private long betIdDefault;

        public DrawAndBetMatchFrm(LotteryDataServices lotteryDataServices, DateTime betDateTime, long betIdDefault=0)
        {
            InitializeComponent();
            this.betDateTime = betDateTime;
            this.lotteryDataServices = lotteryDataServices;
            this.betIdDefault = betIdDefault;
            this.lotteryTicketPanel = this.lotteryDataServices.GetLotteryTicketPanel();
            SetupForms();
            InitialzesContents();
        }
        private void SetupForms()
        {
            this.Text = ResourcesUtils.GetMessage("dabm_form_msg_1");
            this.groupBoxDrawResult.Text = ResourcesUtils.GetMessage("dabm_form_msg_2");
            this.groupBoxYourBet.Text = ResourcesUtils.GetMessage("dabm_form_msg_3");
            this.label1.Text = ResourcesUtils.GetMessage("dabm_form_msg_4");
            this.btnExit.Text = ResourcesUtils.GetMessage("common_btn_exit");
        }
        private void InitialzesContents()
        {
            objListViewBet.SetObjects(lotteryDataServices.GetLottoBetsByDrawDate(betDateTime));
            this.olvColDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum2.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum3.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum4.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum5.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum6.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.drawResult = lotteryDataServices.GetLotteryDrawResultByDrawDate(this.betDateTime);

            //Print the draw result
            if(this.drawResult == null)
            {
                GenerateResultPanels(GetBlankSequence(), tblLyPnlDrawResult, groupBoxDrawResult.ForeColor);
            }
            else
            {
                GenerateResultPanels(this.drawResult.GetAllNumberSequenceSorted(), tblLyPnlDrawResult, groupBoxDrawResult.ForeColor);
            }

            //print your first bet
            if (objListViewBet.GetItemCount() > 0)
            {
                if(this.betIdDefault > 0)
                {
                    foreach (LotteryBet bet in objListViewBet.Objects)
                    {
                        if (bet.GetId() == this.betIdDefault)
                        {
                            GenerateResultPanels(bet.GetAllNumberSequenceSorted(), tblLyPnlBet, groupBoxYourBet.ForeColor);
                            objListViewBet.SelectedIndex = objListViewBet.IndexOf(bet);
                            break;
                        }
                    }
                }
                else
                {
                    LotteryBet bet = (LotteryBet) objListViewBet.GetModelObject(0);
                    GenerateResultPanels(bet.GetAllNumberSequenceSorted(), tblLyPnlBet, groupBoxYourBet.ForeColor);
                    objListViewBet.SelectedIndex = 0;
                }
            }
            else
            {
                GenerateResultPanels(GetBlankSequence(), tblLyPnlBet, groupBoxYourBet.ForeColor);
            }
            MatchMaking();
        }
        private int[] GetBlankSequence()
        {
            int[] betSeq = new int[lotteryTicketPanel.GetGameDigitCount()];
            for (int a = 0; a < lotteryTicketPanel.GetGameDigitCount(); a++)
            {
                betSeq[a] = 0;
            }
            return betSeq;
        }
        private void ObjListViewBet_SelectionChanged(object sender, EventArgs e)
        {
            LotteryBet bet = (LotteryBet)objListViewBet.SelectedObject;
            if (bet == null) return;
            //clearing and redrawing the layout to draw the numbers on the box is CPU expensive
            //we'll change the text label of the label instead
            int ctr = 0;
            int[] seq = bet.GetAllNumberSequence();
            foreach(Label lbl in GetCardNumbers(tblLyPnlBet))
            {
                if (ctr <= seq.Length) lbl.Text = seq[ctr++].ToString();//.PadLeft(2, char.Parse("0"));
            }
            MatchMaking();
        }
        private List<Label> GetCardNumbers(TableLayoutPanel tblLayoutPanel)
        {
            List<Label> labelArr = new List<Label>();
            foreach (Control control in tblLayoutPanel.Controls)
            {
                if (control.GetType() == typeof(Label))
                {
                    Label lbl = (Label)control;
                    if (!lbl.Name.Contains(FILLER_NAME))
                    {
                        labelArr.Add(lbl);
                    }
                }
            }
            return labelArr;
        }
        private void GenerateResultPanels(int[] numberSeq, TableLayoutPanel tblLayoutPanel, Color fontColor)
        {
            tblLayoutPanel.SuspendLayout();
            tblLayoutPanel.Controls.Clear();
            int skipSide = 2; //skip number of rows starting on the left
            int colsCount = lotteryTicketPanel.GetGameDigitCount() + 4; // excess 2 for each sides
            int rowsCount = 1;
            tblLayoutPanel.ColumnStyles.Clear();
            tblLayoutPanel.RowStyles.Clear();
            tblLayoutPanel.ColumnCount = colsCount;
            tblLayoutPanel.RowCount = 1;
            Single percHeight = ((Single)1 / (Single)rowsCount) * 100;
            Single percWidth = ((Single)1 / (Single)colsCount) * 100;

            int ctrItemSeq = 0;
            for (int colCtr = 0; colCtr < colsCount; colCtr++)
            {
                tblLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percWidth));
                if ((skipSide > colCtr) || (skipSide > (colsCount-(colCtr+1))))
                {
                    tblLayoutPanel.Controls.Add(new Label() { Name= FILLER_NAME + colCtr, Text = " " }, colCtr, tblLayoutPanel.RowCount);
                    continue;
                }
                tblLayoutPanel.RowStyles.Add(new ColumnStyle(SizeType.AutoSize));

                Label numLbl = new Label();
                numLbl.Dock = DockStyle.Fill;
                numLbl.Text = numberSeq[ctrItemSeq].ToString(); //.PadLeft(2,char.Parse("0"));
                numLbl.Font = new Font("Microsoft Sans Serif", 23F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                numLbl.FlatStyle = FlatStyle.Flat;
                numLbl.ForeColor = fontColor;

                //get the next item sequence
                ctrItemSeq++;

                numLbl.ImageAlign = ContentAlignment.TopRight;
                numLbl.BorderStyle = BorderStyle.Fixed3D;
                numLbl.TextAlign = ContentAlignment.MiddleCenter;

                tblLayoutPanel.Controls.Add(numLbl, colCtr, tblLayoutPanel.RowCount);
            }
            tblLayoutPanel.ResumeLayout();
        }
        private void MatchMaking()
        {
            List<Label> drawArr = GetCardNumbers(tblLyPnlDrawResult);
            List<Label> betArr = GetCardNumbers(tblLyPnlBet);

            tblLyPnlDrawResult.SuspendLayout();
            tblLyPnlBet.SuspendLayout();

            //cleaning first
            foreach (Label betLabel in betArr) MarkLabel(betLabel, false, groupBoxYourBet.ForeColor);
            foreach (Label drawLabel in drawArr) MarkLabel(drawLabel, false, groupBoxDrawResult.ForeColor);

            //marking same number
            foreach (Label betLabel in betArr)
            {
                Label drawLabel = drawArr.Find(lbl => lbl.Text.Equals(betLabel.Text, StringComparison.OrdinalIgnoreCase));
                if (drawLabel != null)
                {
                    MarkLabel(betLabel, true, groupBoxYourBet.ForeColor);
                    MarkLabel(drawLabel, true, groupBoxDrawResult.ForeColor);
                }
            }
            tblLyPnlDrawResult.ResumeLayout();
            tblLyPnlBet.ResumeLayout();
        }
        private void MarkLabel(Label label, bool isMatch, Color defaultColor)
        {
            if (isMatch)
            {
                label.ForeColor = Color.White;
                label.Image = Resources.torch_24x;
                label.BackColor = Color.Tomato;
            }
            else
            {
                label.ForeColor = defaultColor;
                label.Image = null;
                label.BackColor = Color.Transparent;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
