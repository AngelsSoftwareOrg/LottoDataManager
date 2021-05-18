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
using LottoDataManager.Forms.Reports;
using LottoDataManager.Includes;
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
using AngelsRepositoryLib;
using LottoDataManager.Forms.Ticket;

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
        private ProcessingStatusLogFrm processingStatusLogFrm;
        private String LOG_STATUS_MODULE_NAME_WEBSCRAP = "Web Scraping";
        private String LOG_STATUS_MODULE_NAME_GRID_CONTENT = "Grid Content";
        private String LOG_STATUS_MODULE_NAME_FIELD_DETAILS = "Refreshing Field Details";
        private String LOG_STATUS_MODULE_NAME_WINNING_BETS = "Processing Winning Bets";
        private String LOG_STATUS_MODULE_NAME_DRAWN_RESULT = "Download drawn results";
        private int processingLogStatusCtr = 0;

        public MainForm()
        {
            InitializeComponent();
            this.lotteryDetails = GameFactory.GetPreviousOpenGameInstance();
            this.processingStatusLogFrm = new ProcessingStatusLogFrm();
            this.Text = String.Format("{0} - {1}", ResourcesUtils.GetMessage("mainf_title"), AppSettings.GetAppVersionWithPrefix());
            this.label1.Text = ResourcesUtils.GetMessage("mainf_labels_1");
            this.label3.Text = ResourcesUtils.GetMessage("mainf_labels_2");
            this.label4.Text = ResourcesUtils.GetMessage("mainf_labels_3");
            this.label5.Text = ResourcesUtils.GetMessage("mainf_labels_4");
            AddProcessingStatusLogs(LOG_STATUS_MODULE_NAME_WEBSCRAP, ResourcesUtils.GetMessage("mainf_labels_5"));
            this.toolStripProcessingLogs.Text = ResourcesUtils.GetMessage("mainf_labels_46");
            this.tabPage1.Text = ResourcesUtils.GetMessage("mainf_labels_6");
            this.groupBox1.Text = ResourcesUtils.GetMessage("mainf_labels_7");
            this.groupBox2.Text = ResourcesUtils.GetMessage("mainf_labels_8");
            this.label2.Text = ResourcesUtils.GetMessage("mainf_labels_9");
            this.label6.Text = ResourcesUtils.GetMessage("mainf_labels_10");
            this.label7.Text = ResourcesUtils.GetMessage("mainf_labels_47");
            this.label7.Text = ResourcesUtils.GetMessage("mainf_labels_48");
            this.linkFilterGoBet.Text = ResourcesUtils.GetMessage("mainf_labels_11");
            this.linkLabelFilterDraw.Text = ResourcesUtils.GetMessage("mainf_labels_12");

            this.fileToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_13");
            this.ticketToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_14");
            this.reportsToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_15");
            this.settingsToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_16");
            this.othersToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_17");

            this.openLotteryToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_18");
            this.exitToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_19");
            this.seqGenToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_20");
            this.addBetToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_21");
            this.modifyBetToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_22");
            this.modifyClaimStatusToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_23");
            this.moveDrawDateToolStripMenuItem1.Text = ResourcesUtils.GetMessage("mainf_labels_24");
            this.lossProfitToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_25");
            this.lotterySettingToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_26");
            this.checkWinningBetsToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_27");
            this.checkLotteryUpdatesToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_28");
            this.machineLearningToolStripMenuItem.Text = ResourcesUtils.GetMessage("mainf_labels_29");
            this.aboutToolStripMenuItem1.Text = ResourcesUtils.GetMessage("mainf_labels_30");
            this.toolStripBtnNewBet.ToolTipText = ResourcesUtils.GetMessage("mainf_labels_31");
            this.toolStripBtnDefaultViewListing.ToolTipText = ResourcesUtils.GetMessage("mainf_labels_32");
            this.toolStripBtnModifyBet.ToolTipText = ResourcesUtils.GetMessage("mainf_labels_33");
            this.toolStripModifyClaimStatus.ToolTipText = ResourcesUtils.GetMessage("mainf_labels_34");
            this.toolStripBtnMoveDrawDate.ToolTipText = ResourcesUtils.GetMessage("mainf_labels_35");
            this.machineLearningToolStripButton2.ToolTipText = ResourcesUtils.GetMessage("mainf_labels_36");
            this.pickGeneratorToolStripButton2.ToolTipText = ResourcesUtils.GetMessage("mainf_labels_37");
            this.toolStripBtnWinBets.ToolTipText = ResourcesUtils.GetMessage("mainf_labels_38");
            this.toolStripBtnDownloadResults.ToolTipText = ResourcesUtils.GetMessage("mainf_labels_39");

            this.tabPageBetFilter.Text = ResourcesUtils.GetMessage("mainf_labels_49");
            this.tabPageDrawFilter.Text = ResourcesUtils.GetMessage("mainf_labels_50");

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
            processingLogStatusCtr = 0;
            this.lotteryDataServices = new LotteryDataServices(this.lotteryDetails);
            this.lotteryDataWorker = new LotteryDataWorker();
            this.dashboardReport = new DashboardReport(this.lotteryDataServices);
        }
        private void ClearAllForms()
        {
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
                AddProcessingStatusLogs(LOG_STATUS_MODULE_NAME_GRID_CONTENT, ResourcesUtils.GetMessage("mainf_win_num_grid_cont"));
                objListVwWinningNum.SetObjects(lotteryDataServices.GetLotteryDrawResults(dateTimePickerDrawResult.Value, dateTimePickerDrawResultTo.Value));
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
        }
        private void RefreshBetListViewGridContent()
        {
            try
            {
                AddProcessingStatusLogs(LOG_STATUS_MODULE_NAME_GRID_CONTENT, ResourcesUtils.GetMessage("mainf_labels_40"));
                objectLstVwLatestBet.SetObjects(lotteryDataServices.GetLottoBets(dateTimePickerBets.Value, dateTimePickerBetsTo.Value));
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
            AddProcessingStatusLogs(LOG_STATUS_MODULE_NAME_FIELD_DETAILS, ResourcesUtils.GetMessage("mainf_labels_41"));
            lblNextDrawDate.Text = this.lotteryDataServices.GetNextDrawDateFormatted();

            //Total Winnings amount
            AddProcessingStatusLogs(LOG_STATUS_MODULE_NAME_FIELD_DETAILS, ResourcesUtils.GetMessage("mainf_labels_42"));
            lblLifetimeWinnins.Text = this.lotteryDataServices.GetTotalWinningsAmount().ToString("C");

            //Total Winnings amount this month
            AddProcessingStatusLogs(LOG_STATUS_MODULE_NAME_FIELD_DETAILS, ResourcesUtils.GetMessage("mainf_labels_43"));
            lblWinningsThisMonth.Text = this.lotteryDataServices.GetTotalWinningsAmountThisMonth().ToString("C");
        }
        private OLVColumn[] GenerateOLVColumnForHighlighting()
        {
            if (this.olvColumnTargetFilter != null && this.olvColumnTargetFilter.Length > 0) return this.olvColumnTargetFilter;
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
                if (dpitm.GetFontColor() != Color.Black) itm.ForeColor = dpitm.GetFontColor();
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
            if (rptItem.GetDashboardReportItemActions() != DashboardReportItemActions.NONE)
            {
                ActionableDashboardReportItem(rptItem);
            }
        }
        private void ActionableDashboardReportItem(DashboardReportItem rptItem)
        {
            if (rptItem.GetDashboardReportItemActions() == DashboardReportItemActions.OPEN_CLAIM_FORM)
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
            foreach (int n in lotteryDrawResult.GetAllNumberSequenceSorted())
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
            this.objListVwWinningNum.ModelFilter = filter;
            this.objListVwWinningNum.DefaultRenderer = highlightTextRenderer;
            this.objListVwWinningNum.SelectedForeColor = Color.Black;
            this.objListVwWinningNum.Refresh();
        }
        private void objectLstVwLatestBet_SelectionChanged(object sender, EventArgs e)
        {
            if (this.objectLstVwLatestBet.SelectedObjects.Count <= 0) return;
            LotteryBet lotteryBet = (LotteryBet)objectLstVwLatestBet.SelectedObjects[0];
            TextMatchFilter filter = new TextMatchFilter(this.objectLstVwLatestBet);

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
            this.objectLstVwLatestBet.ModelFilter = filter;
            this.objectLstVwLatestBet.DefaultRenderer = highlightTextRenderer;
            this.objectLstVwLatestBet.SelectedForeColor = Color.Black;
            this.objectLstVwLatestBet.Refresh();
        }
        #endregion

        #region "Status Strip"
        private void AddProcessingStatusLogs(String moduleName, String logs = "")
        {
            if (String.IsNullOrWhiteSpace(logs)) return;
            processingLogStatusCtr++;
            processingStatusLogFrm.AddStatusLogs(moduleName, logs);
            UpdateProcessingStatusLogsLabel();
            Application.DoEvents();
        }
        private void toolStripProcessingLogs_Click(object sender, EventArgs e)
        {
            processingStatusLogFrm.ShowDialog(this);
            processingLogStatusCtr = 0;
            UpdateProcessingStatusLogsLabel();
        }
        private void UpdateProcessingStatusLogsLabel()
        {
            if (processingLogStatusCtr > 0)
            {
                this.toolStripProcessingLogs.Text = String.Format("({0})* {1}",
                processingLogStatusCtr, ResourcesUtils.GetMessage("mainf_labels_46"));
                return;
            }
            this.toolStripProcessingLogs.Text = ResourcesUtils.GetMessage("mainf_labels_46");
        }
        #endregion

        #region "Bets and Draw Result Side"
        private void SetBetsAndResultDefaultList()
        {
            //Prepare the Dates
            dateTimePickerDrawResult.Value = DateTime.Now.AddYears(-1);
            dateTimePickerBets.Value = DateTime.Now.AddYears(-1);
            dateTimePickerBetsTo.Value = DateTime.Now.Date;
            dateTimePickerDrawResultTo.Value = DateTime.Now.Date;
            RefreshWinningNumbersGridContent();
            RefreshBets();
        }
        public void RefreshBets()
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
            CheckWinningBets();
        }
        private void CheckWinningBets()
        {
            lotteryDataWorker.ProcessCheckingForWinningBets(this.lotteryDetails.GameMode);
            RefreshBets();
        }
        private void LotteryDataWorker_LotteryDataWorkerProcessingStatus(object sender, LotteryDataWorkerEvent e)
        {
            AddProcessingStatusLogs(LOG_STATUS_MODULE_NAME_WINNING_BETS, e.CustomStatusMessage);
            Application.DoEvents();
        }
        private void toolStripBtnNewBet_Click(object sender, EventArgs e)
        {
            AddBet();
        }
        private void addBetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBet();
        }
        private void AddBet()
        {
            AddBetFrm betForm = new AddBetFrm(this.lotteryDataServices);
            betForm.ShowDialog(this);
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
            foreach (LotteryBet bet in objectLstVwLatestBet.SelectedObjects)
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
            OpenBetsAndDrawResultMatchMakingForm(bet.GetTargetDrawDate(), bet.GetId());
        }
        private void SelectDrawResultAndOpenMatchMakingForm()
        {
            LotteryDrawResult drawResult = (LotteryDrawResult)objListVwWinningNum.SelectedObject;
            if (drawResult == null) return;
            OpenBetsAndDrawResultMatchMakingForm(drawResult.GetDrawDate(), 0);
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
                AddProcessingStatusLogs(LOG_STATUS_MODULE_NAME_DRAWN_RESULT, ResourcesUtils.GetMessage("mainf_labels_44"));
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
            AddProcessingStatusLogs(LOG_STATUS_MODULE_NAME_WEBSCRAP, e.CustomStatusMessage);

            if (e.LottoWebScrapingStage == LottoWebScrapingStages.FINISH)
            {
                toolStripBtnDownloadResults.Enabled = true;
                RefreshWinningNumbersGridContent();
                RefreshBets();
            }
            Application.DoEvents();
        }
        #endregion

        #region "Main Menu"
        private void GenerateLotteriesGameMenu()
        {
            foreach (Lottery lottery in this.lotteryDataServices.GetLotteries())
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
                ToolStripMenuItem lottoGameMenu = (ToolStripMenuItem)sender;
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
        private void modifyBetToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void toolStripModifyClaimStatus_Click(object sender, EventArgs e)
        {
            ShowModifyClaimStatus();
        }
        private void modifyClaimStatusToolStripMenuItem_Click(object sender, EventArgs e)
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
            ShowPickGeneratorForm();
        }
        private void ShowPickGeneratorForm()
        {
            PickGeneratorFrm pick = new PickGeneratorFrm(lotteryDataServices);
            pick.ShowDialog(this);
            pick.Dispose();
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutFrm f = new AboutFrm();
            f.ShowDialog();
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBetsAndResultDefaultList();
        }
        private void machineLearningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMachineLearningForm();
        }
        private void machineLearningToolStripButton2_Click(object sender, EventArgs e)
        {
            OpenMachineLearningForm();
        }
        private void OpenMachineLearningForm()
        {
            MachineLearningFrm m = new MachineLearningFrm(this.lotteryDataServices);
            m.ShowDialog();
        }
        private void pickGeneratorToolStripButton2_Click(object sender, EventArgs e)
        {
            ShowPickGeneratorForm();
        }
        private void lotterySettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LotterySettingsFrm settings = new LotterySettingsFrm(lotteryDataServices);
            settings.ShowDialog(this);
            RefreshBets();
        }
        private void checkWinningBetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckWinningBets();
        }
        private void moveDrawDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveDrawDate(true);
        }
        private void MoveDrawDate(bool fromContextMenu = false)
        {
            ModifyBetDateFrm m = new ModifyBetDateFrm(this.lotteryDataServices);
            if (fromContextMenu)
            {
                foreach (LotteryBet bet in objectLstVwLatestBet.SelectedObjects)
                {
                    m.AddAutoSelectBet(bet.GetId(), bet.GetTargetDrawDate());
                }
            }
            m.ShowDialog(this);
        }
        private void toolStripBtnMoveDrawDate_Click(object sender, EventArgs e)
        {
            MoveDrawDate();
        }
        private void moveDrawDateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MoveDrawDate();
        }
        private void lossProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfitAndLossFrm frm = new ProfitAndLossFrm(this.lotteryDataServices);
            frm.ShowDialog();
        }
        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdatesFrm updateFrm = new UpdatesFrm(AppSettings.GetRepositoryName, AppSettings.GetAppVersion());
                updateFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void hitComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHitComparisonForm();
        }
        private void toolStripBtnHitCompare_Click(object sender, EventArgs e)
        {
            ShowHitComparisonForm();
        }
        private void hitComparisonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowHitComparisonForm();
        }
        private void ShowHitComparisonForm()
        {
            HitComparisonFrm hitFrm = new HitComparisonFrm(this.lotteryDataServices);
            hitFrm.ShowDialog();
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
                MessageBox.Show(ResourcesUtils.GetMessage("mainf_labels_45"));
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
        private void tabControlFilter_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControlFilter.TabPages[e.Index];
            Color fontColor = e.Index == 0 ? Color.Green : Color.Tomato;
            e.Graphics.FillRectangle(new SolidBrush(Color.Transparent), e.Bounds);

            Font font = new System.Drawing.Font("Microsoft Sans Serif", 9F, 
                FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, font, paddedBounds, fontColor);
        }
        #endregion

    }
}
