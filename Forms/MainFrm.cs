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
using LottoDataManager.Forms;
using LottoDataManager.Includes.Classes;
using LottoDataManager.Includes.Classes.Reports;
using LottoDataManager.Includes.Classes.Scraping;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Game;
using LottoDataManager.Includes.Model.Reports;
using LottoDataManager.Includes.Model.Structs;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager
{
    public partial class MainForm : Form
    {
        private LotteryDetails lotteryDetails;
        private OLVColumn[] olvColumnTargetFilter;
        private LottoWebScraper lottoWebScraper = WebLottoScraperFactory.GetLottoScraper();
        private LotteryDataServices lotteryDataServices;
        private LotteryDataWorker lotteryDataWorker;
        private DashboardReport dashboardReport;

        public MainForm()
        {
            InitializeComponent();
            this.lotteryDetails = GameFactory.GetPreviousOpenGameInstance();
            ReinitateLotteryServices();
            GenerateLotteriesGameMenu();
            InitializesFormContent();
            RefreshSubscription();
        }
        private void RefreshSubscription()
        {
            this.lottoWebScraper.WebScrapingStatus += LottoWebScraper_WebScrapingStatus;
        }
        private void ReinitateLotteryServices()
        {
            this.lotteryDataServices = new LotteryDataServices(this.lotteryDetails);
            this.lotteryDataWorker = new LotteryDataWorker();
            this.dashboardReport = new DashboardReport(this.lotteryDataServices);
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
                Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
                this.lotteryDataWorker.LotteryDataWorkerProcessingStatus += LotteryDataWorker_LotteryDataWorkerProcessingStatus;

                this.olvColBetResult.ImageGetter = delegate (object rowObject) {
                    if (rowObject == null) return 0;
                    LotteryBet p = (LotteryBet)rowObject;
                    if (p.GetMatchNumCount() <= 0) return 0;
                    return ImageUtils.GetStarWonImage(p.GetMatchNumCount());
                };
                this.olvColBetResult.AspectGetter = delegate (object rowObject) {
                    if (rowObject == null) return 0;
                    LotteryBet p = (LotteryBet)rowObject;
                    return p.GetMatchNumCount();
                };
                this.olvColBetResult.AspectToStringConverter = delegate (object rowObject) {
                    return String.Empty;
                };
                this.olvColWinners.AspectGetter = delegate (object rowObject)
                {
                    if (rowObject == null) return 0;
                    LotteryDrawResult p = (LotteryDrawResult)rowObject;
                    if (p.GetWinners() <= 0) return "0";
                    return p.GetWinners();
                };
                this.olvColWinStamp.ImageGetter = delegate (object rowObject) {
                    if (rowObject == null) return 0;
                    LotteryDrawResult p = (LotteryDrawResult)rowObject;
                    if (p.GetWinners() <= 0) return 0;
                    return ImageUtils.GetStarJackpotImage(5);
                };
                this.olvColWinStamp.AspectGetter = delegate (object rowObject) {
                    if (rowObject == null) return 0;
                    LotteryDrawResult p = (LotteryDrawResult)rowObject;
                    return p.GetWinners();
                };
                this.olvColWinStamp.AspectToStringConverter = delegate (object rowObject) {
                    return String.Empty;
                };

                this.Enabled = false;
                ClearAllForms();
                Application.DoEvents();
                RefreshFieldDetails();
                SetBetsAndResultDefaultList();
                RefreshWinningNumbersGridContent();
                DisplayStatusLabel();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ResourcesUtils.GetMessage("mainf_error1"));
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
                DisplayStatusLabel(ResourcesUtils.GetMessage("mainf_win_num_grid_cont"));
                objListVwWinningNum.SetObjects(lotteryDataServices.GetLotteryDrawResults(dateTimePickerDrawResult.Value));
                this.olvColDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColNum1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColNum2.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColNum3.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColNum4.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColNum5.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColNum6.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColJackpot.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColWinners.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                //this.olvColWinStamp.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.olvColWinStamp.Width = 100;
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
                this.olvColBetDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetNum1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetNum2.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetNum3.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetNum4.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetNum5.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetNum6.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                this.olvColBetResult.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
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
        private void RefreshDashboardReport()
        {
            listViewOtherDetails.BeginUpdate();
            listViewOtherDetails.Items.Clear();
            foreach (DashboardReportItem dpitm in dashboardReport.GetDashboardReport())
            {
                ListViewItem itm = new ListViewItem(dpitm.GetDescription());
                itm.SubItems.Add(dpitm.GetValue());
                itm.Tag = dpitm;
                if (dpitm.IsHighlight()) itm.BackColor = dpitm.GetHighlightColor();
                if (dpitm.GetFontColor() != Color.Black) itm.ForeColor= dpitm.GetFontColor();
                listViewOtherDetails.Items.Add(itm);
            }
            listViewOtherDetails.EndUpdate();
        }
        private void listViewOtherDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listViewOtherDetails.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item == null)
            {
                this.listViewOtherDetails.SelectedItems.Clear();
                return;
            }

            DashboardReportItem rptItem = (DashboardReportItem)item.Tag;
            if(rptItem.GetDashboardReportItemActions() != DashboardReportItemActions.NONE)
            {
                ActionableDashboardReportItem(rptItem);
            }
        }
        private void ActionableDashboardReportItem(DashboardReportItem rptItem)
        {
            if(rptItem.GetDashboardReportItemActions() == DashboardReportItemActions.OPEN_CLAIM_FORM)
            {
                ShowModifyClaimStatus();
            }
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
            highlightTextRenderer.FillBrush = new SolidBrush(Color.LightBlue);
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
            highlightTextRenderer.FillBrush = new SolidBrush(Color.LightBlue);
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
            }
            Application.DoEvents();
        }
        #endregion

        #region "Bets and Draw Result Side"
        private void SetBetsAndResultDefaultList()
        {
            //Prepare the Dates
            dateTimePickerDrawResult.Value = DateTime.Now.AddYears(-1);
            dateTimePickerBets.Value = DateTime.Now.AddYears(-1);
            RefreshWinningNumbersGridContent();
            RefreshBets();
        }
        private void RefreshBets()
        {
            RefreshFieldDetails();
            RefreshBetListViewGridContent();
            RefreshDashboardReport();
            Application.DoEvents();
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
            statusLabelLoading.Visible = true;
            //RefreshSubscription();
            lotteryDataWorker.ProcessCheckingForWinningBets(this.lotteryDetails.GameMode);
            statusLabelLoading.Text = "";
            RefreshBets();
        }
        private void LotteryDataWorker_LotteryDataWorkerProcessingStatus(object sender, LotteryDataWorkerEvent e)
        {
            statusLabelLoading.Text = e.CustomStatusMessage;
            Application.DoEvents();
        }
        private void toolStripBtnNewBet_Click(object sender, EventArgs e)
        {
            AddBetFrm betForm = new AddBetFrm(this.lotteryDataServices);
            betForm.ShowDialog();
            betForm.Dispose();
            RefreshBets();
        }
        private void compareDrawResultAndBetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectBetAndOpenMatchMakingForm();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objectLstVwLatestBet.SelectAll();
        }
        private void copySelectedAsLinearCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(LotteryBet bet in objectLstVwLatestBet.SelectedObjects)
            {
                if (sb.Length > 0) sb.Append(",");
                sb.Append(bet.GetGNUFormat());
            }
            if (sb.Length > 0) Clipboard.SetText(sb.ToString());
        }
        private void objectLstVwLatestBet_DoubleClick(object sender, EventArgs e)
        {
            SelectBetAndOpenMatchMakingForm();
        }
        private void objListVwWinningNum_DoubleClick(object sender, EventArgs e)
        {
            SelectDrawResultAndOpenMatchMakingForm();
        }
        private void objectLstVwLatestBet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SelectBetAndOpenMatchMakingForm();
        }
        private void objListVwWinningNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SelectDrawResultAndOpenMatchMakingForm();
        }
        private void SelectBetAndOpenMatchMakingForm()
        {
            LotteryBet bet = (LotteryBet)objectLstVwLatestBet.SelectedObject;
            if (bet == null) return;
            OpenBetsAndDrawResultMatchMakingForm(bet.GetTargetDrawDate(),bet.GetId());
        }
        private void SelectDrawResultAndOpenMatchMakingForm()
        {
            LotteryDrawResult drawResult = (LotteryDrawResult)objListVwWinningNum.SelectedObject;
            if (drawResult == null) return;
            OpenBetsAndDrawResultMatchMakingForm(drawResult.GetDrawDate(),0);
        }
        private void OpenBetsAndDrawResultMatchMakingForm(DateTime dateRef, long betIdDefault)
        {
            DrawAndBetMatchFrm m = new DrawAndBetMatchFrm(this.lotteryDataServices, dateRef, betIdDefault);
            m.ShowDialog();
            m.Dispose();
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
                RefreshWinningNumbersGridContent();
                RefreshBets();
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
            try
            {
                ClearAllForms();
                ToolStripMenuItem lottoGameMenu = (ToolStripMenuItem) sender;
                Lottery lottery = (Lottery)lottoGameMenu.Tag;
                this.lotteryDetails = new LotteryDetails(lottery.GetGameMode());
                ReinitateLotteryServices();
                Application.DoEvents();
                InitializesFormContent();
                this.lotteryDataServices.SaveLastOpenedLottery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void checkLotteryUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripBtnDownloadResults_Click(null, null);
        }
        private void toolStripBtnModifyBet_Click(object sender, EventArgs e)
        {
            ShowModifyBets();
        }
        private void editYourBetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowModifyBets();
        }
        private void ShowModifyBets()
        {
            ModifyBetFrm bet = new ModifyBetFrm(lotteryDataServices);
            bet.ShowDialog();
            bet.Dispose();
            RefreshBets();
        }
        private void editClaimStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowModifyClaimStatus();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShowModifyClaimStatus();
        }
        private void ShowModifyClaimStatus()
        {
            ModifyClaimsFrm m = new ModifyClaimsFrm(this.lotteryDataServices);
            m.ShowDialog();
            m.Dispose();
            RefreshBets();
        }
        private void seqGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PickGeneratorFrm pick = new PickGeneratorFrm(lotteryDataServices);
            pick.ShowDialog();
            pick.Dispose();
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutFrm f = new AboutFrm();
            f.ShowDialog();
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            SplashScreenFrm.GetIntance().DisposeInstance();
            this.Show();
        }
        #endregion
    }
}
