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
using LottoDataManager.Includes.Classes.Scraping;
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
        private LottoWebScraper lottoWebScraper = WebLottoScraperFactory.GetLottoScraper();

        public MainForm()
        {
            InitializeComponent();
            InitializesFormContent();
        }

        private void InitializesFormContent()
        {
            //debug
            this.lotteryDetails = new Game645();
            //debug end

            lottoWebScraper.WebScrapingStatus += LottoWebScraper_WebScrapingStatus;
            toolStripStatusLblUpdater.Text = "";
            toolStripStatusLblUpdater.Visible = false;
            toolStripProgressBarUpdater.Value = 0;
            toolStripProgressBarUpdater.Visible = false;

            Application.DoEvents();
            this.Show();
            Application.DoEvents();
            RefreshFieldDetails();
            SetBetsAndResultDefaultList();
            RefreshWinningNumbersGridContent();
            DisplayStatusLabel();

            /*            LotteryDataWorker ld = new LotteryDataWorker();
                        //ld.ProcessAdjustCorrectTargetDrawDate(lotteryDetails.GameCode);
                        ld.ProcessCheckingForWinningBets(lotteryDetails.GameCode);

                        this.lotteryDetails = new Game658();
                        //ld.ProcessAdjustCorrectTargetDrawDate(lotteryDetails.GameCode);
                        ld.ProcessCheckingForWinningBets(lotteryDetails.GameCode);*/
        }

        #region "Tab Dashboard"
        private void RefreshWinningNumbersGridContent()
        {
            try
            {
                DisplayStatusLabel("Getting the listing of winning numbers");
                objListVwWinningNum.SetObjects(lotteryDetails.GetLotteryDrawResults(dateTimePickerDrawResult.Value));
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                DisplayStatusLabel();
            }
        }
        private void RefreshBetListViewGridContent()
        {
            try
            {
                DisplayStatusLabel("Getting the listing of your bets");
                objectLstVwLatestBet.SetObjects(lotteryDetails.GetLottoBets(dateTimePickerBets.Value));
                this.olvColBetDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.olvColBetNum1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.olvColBetNum2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.olvColBetNum3.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.olvColBetNum4.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.olvColBetNum5.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.olvColBetNum6.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.olvColBetResult.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                DisplayStatusLabel();
            }
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
            DisplayStatusLabel("Getting the next draw date");
            lblNextDrawDate.Text = "";
            DateTime nextScheduledDate = this.lotteryDetails.LotteryDataDerivation.GetNextDrawDate();
            if (nextScheduledDate.Date == DateTime.Today) lblNextDrawDate.Text = "Today! ";
            lblNextDrawDate.Text += nextScheduledDate.ToString(DateTimeConverterUtils.DATE_FORMAT_LONG);

            //Total Winnings amount
            DisplayStatusLabel("Getting your lifetime winnings for this game...");
            lblLifetimeWinnins.Text = this.lotteryDetails.GetTotalWinningsAmount().ToString("C");

            //Total Winnings amount this month
            DisplayStatusLabel("Getting your winnings so far this month...");
            lblWinningsThisMonth.Text = this.lotteryDetails.GetTotalWinningsAmountThisMonth().ToString("C");
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
        #endregion

        #region "Draw Result"
        private void objListVwWinningNum_SelectionChanged(object sender, EventArgs e)
        {
            if (this.objListVwWinningNum.SelectedObjects.Count <= 0) return;
            LotteryDrawResult lotteryDrawResult = (LotteryDrawResult)objListVwWinningNum.SelectedObjects[0];
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
            highlightTextRenderer.FramePen = new Pen(Color.Empty);
            highlightTextRenderer.FillBrush = new SolidBrush(Color.YellowGreen);
            highlightTextRenderer.CellPadding = new Rectangle(0, 0, 0, 0);
            highlightTextRenderer.Bounds = new Rectangle(2, 2, 2, 2);
            this.objListVwWinningNum.ModelFilter = filter;
            this.objListVwWinningNum.DefaultRenderer = highlightTextRenderer;
            this.objListVwWinningNum.SelectedForeColor = Color.Black;
        }

        private void objectLstVwLatestBet_SelectionChanged(object sender, EventArgs e)
        {
            if (this.objectLstVwLatestBet.SelectedObjects.Count <= 0) return;
            LotteryBet lotteryBet = (LotteryBet)objectLstVwLatestBet.SelectedObjects[0];
            TextMatchFilter filter = new TextMatchFilter(this.objectLstVwLatestBet);

            List<String> regex = new List<string>();
            regex.Add("^" + lotteryBet.GetNum1().ToString() + "$");
            regex.Add("^" + lotteryBet.GetNum2().ToString() + "$");
            regex.Add("^" + lotteryBet.GetNum3().ToString() + "$");
            regex.Add("^" + lotteryBet.GetNum4().ToString() + "$");
            regex.Add("^" + lotteryBet.GetNum5().ToString() + "$");
            regex.Add("^" + lotteryBet.GetNum6().ToString() + "$");
            filter.RegexStrings = regex;

            HighlightTextRenderer highlightTextRenderer = new HighlightTextRenderer(filter);
            highlightTextRenderer.CornerRoundness = 1;
            highlightTextRenderer.FramePen = new Pen(Color.Empty);
            highlightTextRenderer.FillBrush = new SolidBrush(Color.YellowGreen);
            highlightTextRenderer.CellPadding = new Rectangle(0, 0, 0, 0);
            highlightTextRenderer.Bounds = new Rectangle(2, 2, 2, 2);
            this.objectLstVwLatestBet.ModelFilter = filter;
            this.objectLstVwLatestBet.DefaultRenderer = highlightTextRenderer;
            this.objectLstVwLatestBet.SelectedForeColor = Color.Black;
        }
        #endregion

        #region "Status Strip"
        private void DisplayStatusLabel(String status="")
        {
            if (String.IsNullOrWhiteSpace(status))
            {
                statusLabelLoading.Text = "";
            }
            else
            {
                statusLabelLoading.Text = "*** " + status;
                Application.DoEvents();
            }
        }
        #endregion

        #region "Bets and Draw Result Side"
        private void SetBetsAndResultDefaultList()
        {
            //Prepare the Dates
            dateTimePickerDrawResult.Value = DateTime.Now.AddYears(-1);
            dateTimePickerBets.Value = DateTime.Now.AddYears(-1);
            RefreshWinningNumbersGridContent();
            RefreshBetListViewGridContent();
        }
        private void linkFilterGoBet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshBetListViewGridContent();
        }
        private void linkLabelFilterDraw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshWinningNumbersGridContent();
        }
        private void toolStripBtnDefaultViewListing_Click(object sender, EventArgs e)
        {
            SetBetsAndResultDefaultList();
        }
        #endregion

        #region "Lotto Scraper"

        private void toolStripBtnDownloadResults_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripBtnDownloadResults.Enabled = false;
                toolStripStatusLblUpdater.Text = "Lotto Draw Result Updater...";
                toolStripStatusLblUpdater.Visible = true;
                toolStripProgressBarUpdater.Value = 0;
                Application.DoEvents();
                List<LotteryDetails> lotteryArr = new List<LotteryDetails>();
                lotteryArr.Add(this.lotteryDetails);
                lottoWebScraper.StartScraping(lotteryArr);
            }
            catch (Exception ex)
            {
                toolStripBtnDownloadResults.Enabled = true;
                MessageBox.Show(ex.Message);
                Application.DoEvents();
            }
        }

        private void LottoWebScraper_WebScrapingStatus(object sender, LottoWebScraperEvent e)
        {
            toolStripStatusLblUpdater.Text = e.CustomStatusMessage;
            toolStripProgressBarUpdater.Value = e.Progress;
            if (e.LottoWebScrapingStage == LottoWebScrapingStages.INSERT)
            {
                if(!toolStripProgressBarUpdater.Visible) toolStripProgressBarUpdater.Visible = true;
            }
            else if (e.LottoWebScrapingStage == LottoWebScrapingStages.FINISH)
            {
                toolStripBtnDownloadResults.Enabled = true;
                toolStripStatusLblUpdater.Text = "";
                toolStripStatusLblUpdater.Visible = false;
                toolStripProgressBarUpdater.Value = 0;
                toolStripProgressBarUpdater.Visible = false;
            }
            else
            {
                if (toolStripProgressBarUpdater.Visible) toolStripProgressBarUpdater.Visible = false;
            }
            Application.DoEvents();
        }

        #endregion

        private void checkLotteryUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripBtnDownloadResults_Click(null, null);
        }

    }
}
