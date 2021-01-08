using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using LottoDataManager.Includes.Classes;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager
{
    public partial class MainForm : Form
    {
        private LotteryDetails lotteryDetails;
        private OLVColumn[] olvColumnTargetFilter;

        public MainForm()
        {
            InitializeComponent();
            InitializesFormContent();
        }

        private void InitializesFormContent()
        {
            //debug
            this.lotteryDetails = new Game655();
            //debug end

            RefreshFieldDetails();
            RefreshDrawResultListViewGridContent();
            RefreshBetListViewGridContent();

            LotteryDataWorker ld = new LotteryDataWorker();
            //ld.ProcessAdjustCorrectTargetDrawDate(lotteryDetails.GameCode);
            ld.ProcessCheckingForWinningBets(lotteryDetails.GameCode);
            
        }

        #region "Tab Dashboard"
        private void RefreshWinningNumbersGridContent()
        {
            if (objListVwWinningNum.Items.Count > 0) return;
            objListVwWinningNum.SetObjects(lotteryDetails.GetAllLotteryDrawResults());
            this.olvColDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum3.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum4.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum5.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum6.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColJackpot.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColWinners.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            //objListVwWinningNum.EnsureVisible(objListVwWinningNum.Items.Count - 1);
        }
        private void RefreshBetListViewGridContent()
        {
            DateTime lastXDays = DateTime.Now.AddDays(-100);
            objectLstVwLatestBet.SetObjects(lotteryDetails.GetLottoBets(lastXDays));
            this.olvColBetDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum3.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum4.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum5.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum6.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetResult.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void RefreshDrawResultListViewGridContent()
        {
            this.olvColBetDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum3.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum4.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum5.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetNum6.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColBetResult.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void RefreshFieldDetails()
        {
            //Game642 Mode
            lblGameMode.Text = this.lotteryDetails.Description;

            //Schedule Date
            lblNextDrawDate.Text = "";
            DateTime nextScheduledDate = this.lotteryDetails.LotteryDataDerivation.GetNextDrawDate();
            if (nextScheduledDate.Date == DateTime.Today) lblNextDrawDate.Text = "Today! ";
            lblNextDrawDate.Text += nextScheduledDate.ToString(DateTimeConverterUtils.DATE_FORMAT_LONG);
        }
        private OLVColumn[] GenerateOLVColumnForHighlighting()
        {
            if (this.olvColumnTargetFilter !=null && this.olvColumnTargetFilter.Length > 0) return this.olvColumnTargetFilter;
            List<OLVColumn> tmpOLVColumns = new List<OLVColumn>();
            tmpOLVColumns.Add(objListVwWinningNum.GetColumn(1));
            tmpOLVColumns.Add(objListVwWinningNum.GetColumn(2));
            tmpOLVColumns.Add(objListVwWinningNum.GetColumn(3));
            tmpOLVColumns.Add(objListVwWinningNum.GetColumn(4));
            tmpOLVColumns.Add(objListVwWinningNum.GetColumn(5));
            tmpOLVColumns.Add(objListVwWinningNum.GetColumn(6));
            this.olvColumnTargetFilter = tmpOLVColumns.ToArray();
            return this.olvColumnTargetFilter;
        }
        private void tabWinningNumbers_Enter(object sender, EventArgs e)
        {
            RefreshWinningNumbersGridContent();
        }
        #endregion

        #region "Draw Result"
        private void objListVwWinningNum_SelectionChanged(object sender, EventArgs e)
        {
            if (objListVwWinningNum.SelectedObjects.Count <= 0) return;
            LotteryDrawResult lotteryDrawResult = (LotteryDrawResult) objListVwWinningNum.SelectedObjects[0];
            TextMatchFilter filter = new TextMatchFilter(this.objListVwWinningNum);
            filter.Columns = GenerateOLVColumnForHighlighting();

            List<String> regex = new List<string>();
            regex.Add("^" + lotteryDrawResult.GetNum1().ToString() + "$");
            regex.Add("^" + lotteryDrawResult.GetNum2().ToString() + "$");
            regex.Add("^" + lotteryDrawResult.GetNum3().ToString() + "$");
            regex.Add("^" + lotteryDrawResult.GetNum4().ToString() + "$");
            regex.Add("^" + lotteryDrawResult.GetNum5().ToString() + "$");
            regex.Add("^" + lotteryDrawResult.GetNum6().ToString() + "$");
            filter.RegexStrings = regex;

            HighlightTextRenderer highlightTextRenderer = new HighlightTextRenderer(filter);
            highlightTextRenderer.CornerRoundness = 1;
            highlightTextRenderer.FramePen = new Pen(Color.White);
            highlightTextRenderer.FillBrush = new SolidBrush(Color.Yellow);
            highlightTextRenderer.CellPadding = new Rectangle(0,0,0,0);
            this.objListVwWinningNum.ModelFilter = filter;
            this.objListVwWinningNum.DefaultRenderer = highlightTextRenderer;
            this.objListVwWinningNum.SelectedForeColor = Color.Black;
        }
        #endregion

    }
}
