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
using LottoDataManager.Includes.Model.Game;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager
{
    public partial class MainForm : Form
    {
        private LotteryDetails lotteryDetails;
        private OLVColumn[] olvColumnTargetFilter;
        private LottoWebScraper lottoWebScraper = WebLottoScraperFactory.GetLottoScraper();
        private LotteryDataServices lotteryDataServices;

        public MainForm()
        {
            InitializeComponent();
            this.lotteryDetails = GameFactory.GetPreviousOpenGameInstance();
            this.lotteryDataServices = new LotteryDataServices(this.lotteryDetails);
            GenerateLotteriesGameMenu();
            InitializesFormContent();
            lottoWebScraper.WebScrapingStatus += LottoWebScraper_WebScrapingStatus;
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }
        
        private void ClearAllForms()
        {
            toolStripStatusLblUpdater.Text = "";
            toolStripStatusLblUpdater.Visible = false;
            toolStripProgressBarUpdater.Value = 0;
            toolStripProgressBarUpdater.Visible = false;
            lblGameMode.Text = "";
            lblLifetimeWinnins.Text = "";
            lblNextDrawDate.Text = "";
            lblWinningsThisMonth.Text = "";
            listViewOtherDetails.Items.Clear();
            objectLstVwLatestBet.SetObjects(null);
            objListVwWinningNum.SetObjects(null);
        }
        private void InitializesFormContent()
        {
            try
            {
                this.Enabled = false;
                ClearAllForms();
                Application.DoEvents();
                this.Show();
                Application.DoEvents();
                RefreshFieldDetails();
                SetBetsAndResultDefaultList();
                RefreshWinningNumbersGridContent();
                DisplayStatusLabel();
            }
            catch (Exception)
            {
                MessageBox.Show("Error when initializes content.");
            }
            finally
            {
                this.Enabled = true;
            }
            Application.DoEvents();
        }

        #region "Tab Dashboard"
        private void RefreshWinningNumbersGridContent()
        {
            try
            {
                DisplayStatusLabel("Getting the listing of winning numbers");
                objListVwWinningNum.SetObjects(lotteryDataServices.GetLotteryDrawResults(dateTimePickerDrawResult.Value));
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
                objectLstVwLatestBet.SetObjects(lotteryDataServices.GetLottoBets(dateTimePickerBets.Value));
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
            lblNextDrawDate.Text = this.lotteryDataServices.GetNextDrawDateFormatted();

            //Total Winnings amount
            DisplayStatusLabel("Getting your lifetime winnings for this game...");
            lblLifetimeWinnins.Text = this.lotteryDataServices.GetTotalWinningsAmount().ToString("C");

            //Total Winnings amount this month
            DisplayStatusLabel("Getting your winnings so far this month...");
            lblWinningsThisMonth.Text = this.lotteryDataServices.GetTotalWinningsAmountThisMonth().ToString("C");
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
        private void toolStripBtnWinBets_Click(object sender, EventArgs e)
        {
           LotteryDataWorker ld = new LotteryDataWorker();
           ld.ProcessCheckingForWinningBets(this.lotteryDetails.GameMode);
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

        #region "Main Menu"
        private void GenerateLotteriesGameMenu()
        {
            foreach(Lottery lottery in this.lotteryDataServices.GetLotteries())
            {
                ToolStripMenuItem lottoGameMenu = new ToolStripMenuItem(lottery.GetDescription());
                lottoGameMenu.Tag = lottery;
                this.openLotteryToolStripMenuItem.DropDownItems.Add(lottoGameMenu);
                lottoGameMenu.Click += LottoGameMenu_Click;
            }
        }
        private void LottoGameMenu_Click(object sender, EventArgs e)
        {
            ClearAllForms();
            ToolStripMenuItem lottoGameMenu = (ToolStripMenuItem) sender;
            Lottery lottery = (Lottery)lottoGameMenu.Tag;
            this.lotteryDetails = new LotteryDetails(lottery.GetGameMode());
            this.lotteryDataServices = new LotteryDataServices(this.lotteryDetails);
            Application.DoEvents();
            InitializesFormContent();
        }
        private void checkLotteryUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripBtnDownloadResults_Click(null, null);
        }
        #endregion

        #region "Main Form"
        private void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                this.lotteryDataServices.SaveLastOpenedLottery();
            }
            catch (Exception)
            {
                MessageBox.Show("Error on saving the current session...");
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}
