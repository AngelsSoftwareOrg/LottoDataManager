using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BrightIdeasSoftware;
using LottoDataManager.Includes.Classes;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Forms.Ticket
{
    public partial class HitComparisonFrm : Form
    { 
        private LotteryDataServices lotteryDataServices;
        public HitComparisonFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();
            SetupFormLabels();
            this.lotteryDataServices = lotteryDataServices;

            //Debugging
            //#if DEBUG
            //if(lotteryDataServices==null)
            //    this.lotteryDataServices = new LotteryDataServices(new Game642());
            //#endif
            //end debugging

            dateTimePickerFrom.Value = DateTime.Now.AddYears(-1);
            InitializesObjectListViewDataBinding();
            StartInitialization();
        }

        #region BET LISTVIEW
        private void InitialieBetListView()
        {
            try
            {
                objListVwBet.SetObjects(lotteryDataServices.GetLottoBets(dateTimePickerFrom.Value));
                this.olvColBetTargetDate.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetN1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetN2.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetN3.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetN4.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetN5.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetN6.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void objListVwBet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.objListVwBet.SelectedObjects.Count <= 0) return;
            LotteryBet lotteryBet = (LotteryBet)objListVwBet.SelectedObjects[0];
            TextMatchFilter filter = new TextMatchFilter(this.objListVwDrawResult);

            List<String> regex = new List<string>();
            foreach (int n in lotteryBet.GetAllNumberSequenceSorted())
            {
                regex.Add("^" + n.ToString() + "$");
            }
            filter.RegexStrings = regex;

            HighlightTextRenderer highlightTextRenderer = new HighlightTextRenderer(filter);
            highlightTextRenderer.CornerRoundness = 1;
            highlightTextRenderer.FramePen = new Pen(Color.Empty);
            highlightTextRenderer.FillBrush = new SolidBrush(Color.LightBlue);
            highlightTextRenderer.CellPadding = new Rectangle(0, 0, 0, 0);
            highlightTextRenderer.Bounds = new Rectangle(2, 2, 2, 2);
            this.objListVwDrawResult.ModelFilter = filter;
            this.objListVwDrawResult.DefaultRenderer = highlightTextRenderer;
            this.objListVwDrawResult.SelectedForeColor = Color.Black;
            foreach (OLVListItem item in this.objListVwDrawResult.Items)
            {
                this.objListVwDrawResult.RefreshObject(item.RowObject);
            }
            this.objListVwDrawResult.Sort();
        }
        #endregion

        #region DRAW RESULT LISTVIEW
        private void InitialieDrawResultListView()
        {
            try
            {
                objListVwDrawResult.SetObjects(lotteryDataServices.GetLotteryDrawResults(dateTimePickerFrom.Value));
                this.olvColDrawResultDate.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColDrawN1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColDrawN2.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColDrawN3.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColDrawN4.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColDrawN5.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColDrawN6.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColDrawWinner.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region MAIN FORM
        private void SetupFormLabels()
        {
            this.Text = ResourcesUtils.GetMessage("hit_comp_frm_title");
            this.btnExit.Text = ResourcesUtils.GetMessage("common_btn_exit");
            this.label1.Text = ResourcesUtils.GetMessage("hit_comp_frm_msg1");
            this.lnkFilter.Text = ResourcesUtils.GetMessage("common_link_filter_now");
            this.label2.Text = ResourcesUtils.GetMessage("hit_comp_frm_msg2");
            this.label3.Text = ResourcesUtils.GetMessage("hit_comp_frm_msg3");
            this.label4.Text = ResourcesUtils.GetMessage("hit_comp_frm_msg4");
        }
        private void StartInitialization()
        {
            try
            {
                InitialieBetListView();
                InitialieDrawResultListView();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void InitializesObjectListViewDataBinding()
        {
            this.olvColBetMatch.ImageGetter = delegate (object rowObject) {
                if (rowObject == null) return 0;
                LotteryBet p = (LotteryBet)rowObject;
                if (p.GetMatchNumCount() <= 0) return 0;
                return ImageUtils.GetStarWonImage(p.GetMatchNumCount());
            };
            this.olvColBetMatch.AspectGetter = delegate (object rowObject) {
                if (rowObject == null) return 0;
                LotteryBet p = (LotteryBet)rowObject;
                return p.GetMatchNumCount();
            };
            this.olvColBetMatch.AspectToStringConverter = delegate (object rowObject) {
                return String.Empty;
            };

            this.olvColDrawWinner.ImageGetter = delegate (object rowObject) {
                if (rowObject == null) return 0;
                LotteryDrawResult p = (LotteryDrawResult)rowObject;
                if (p.GetWinners() <= 0) return 0;
                return ImageUtils.GetStarJackpotImage(5);
            };
            this.olvColDrawWinner.AspectGetter = delegate (object rowObject) {
                if (rowObject == null) return 0;
                LotteryDrawResult p = (LotteryDrawResult)rowObject;
                return p.GetWinners();
            };
            this.olvColDrawWinner.AspectToStringConverter = delegate (object rowObject) {
                return String.Empty;
            };

            this.olvColDrawMatch.ImageGetter = delegate (object rowObject) {
                if (rowObject == null) return 0;
                int matchCnt = CountMatchingBetToDrawnResult(rowObject);
                if (matchCnt <= 0) return 0;
                return ImageUtils.GetStarWonImage(matchCnt);
            };
            this.olvColDrawMatch.AspectGetter = delegate (object rowObject) {
                if (rowObject == null) return 0;
                return CountMatchingBetToDrawnResult(rowObject);
            };
            this.olvColDrawMatch.AspectToStringConverter = delegate (object rowObject) {
                return String.Empty;
            };

        }
        private int CountMatchingBetToDrawnResult(object rowObject)
        {
            if (this.objListVwBet.SelectedObjects.Count <= 0) return 0;
            LotteryBet lotteryBet = (LotteryBet)objListVwBet.SelectedObjects[0];
            int matchCnt = 0;
            LotteryDrawResult drawResult = (LotteryDrawResult)rowObject;
            foreach (int n in lotteryBet.GetAllNumberSequenceSorted())
            {
                if (drawResult.IsWithinDrawResult(n)) matchCnt++;
            }
            return matchCnt;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lnkFilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartInitialization();
        }

        #endregion
    }
}
