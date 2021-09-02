using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Includes.Classes;
using LottoDataManager.Includes.Classes.Comparers;
using LottoDataManager.Includes.Database.DAO.Impl;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Details.Setup;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Forms
{
    public partial class LotterySettingsFrm : Form
    {
        private readonly ListviewTextSorter lvwTextSorter = new ListviewTextSorter();
        private readonly ListviewIntSorter lvwIntSorter = new ListviewIntSorter();
        private LotteryDataServices lotteryDataServices;
        private LotteryTicketPanel lotteryTicketPanel;
        private LotteryAppConfiguration lotteryAppConfiguration;
        private String NODE_NAME_OPTION_CONFIG = "nodeConfig";

        public object ResourcesUtil { get; private set; }

        public LotterySettingsFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();

            if (lotteryDataServices != null)
            {
                this.lotteryDataServices = lotteryDataServices;
                this.lotteryTicketPanel = this.lotteryDataServices.GetLotteryTicketPanel();
            }
            this.lotteryAppConfiguration = LotteryAppConfiguration.GetInstance();
            txtConfigDBSource.Text = this.lotteryAppConfiguration.DBSourcePath;
            txtConfigFolderML.Text = this.lotteryAppConfiguration.MLModelPath;
            txtConfigNotes.Text = String.Format(ResourcesUtils.GetMessage("lott_app_config_notes"),
                Environment.NewLine + Environment.NewLine, Environment.NewLine + Environment.NewLine,
                Environment.NewLine + Environment.NewLine, Environment.NewLine + Environment.NewLine);
        }

        #region MAIN FORM
        private void SetupForms()
        {
            this.Text = ResourcesUtils.GetMessage("lott_app_config_msg3");
            this.btnExit.Text = ResourcesUtils.GetMessage("common_btn_exit");
            this.btnConfigSave.Text = ResourcesUtils.GetMessage("common_btn_save_changes");
            this.btnLAWPASaveChanges.Text = ResourcesUtils.GetMessage("common_btn_save_changes");
            this.btnLotSchedSave.Text = ResourcesUtils.GetMessage("common_btn_save_changes");
            this.btnSaveModDesc.Text = ResourcesUtils.GetMessage("lott_app_config_msg4");
            this.btnSaveLotteryOutlet.Text = ResourcesUtils.GetMessage("lott_app_config_msg5");
            this.btnSeqGenSaveChanges.Text = ResourcesUtils.GetMessage("lott_app_config_msg6");
            this.gbLottoBuyCutOff.Text = ResourcesUtils.GetMessage("lott_app_config_msg34");
            this.lblCutoff.Text = ResourcesUtils.GetMessage("lott_app_config_msg35");
            this.lblNotify.Text = ResourcesUtils.GetMessage("lott_app_config_msg36");
            this.lblNotifyDesc.Text = ResourcesUtils.GetMessage("lott_app_config_msg37");

            foreach (TreeNode node in this.mainMenuTreeView.Nodes)
            {
                if(node.Name.Equals("nodeConfig", StringComparison.OrdinalIgnoreCase)){
                    node.Text = ResourcesUtils.GetMessage("lott_app_config_msg7");
                }
                else if (node.Name.Equals("nodeLottoOutlet", StringComparison.OrdinalIgnoreCase))
                {
                    node.Text = ResourcesUtils.GetMessage("lott_app_config_msg8");
                }
                else if (node.Name.Equals("nodeLotteryWinComb", StringComparison.OrdinalIgnoreCase))
                {
                    node.Text = ResourcesUtils.GetMessage("lott_app_config_msg9");
                }
                else if (node.Name.Equals("nodeLottoSeqGen", StringComparison.OrdinalIgnoreCase))
                {
                    node.Text = ResourcesUtils.GetMessage("lott_app_config_msg10");
                }
                else if (node.Name.Equals("nodeLottoSched", StringComparison.OrdinalIgnoreCase))
                {
                    node.Text = ResourcesUtils.GetMessage("lott_app_config_msg11");
                }
                else if (node.Name.Equals("nodeOthers", StringComparison.OrdinalIgnoreCase))
                {
                    node.Text = ResourcesUtils.GetMessage("lott_app_config_msg33");
                }
            }

            //Configurations
            this.groupBox4.Text = ResourcesUtils.GetMessage("lott_app_config_msg12");
            this.label2.Text = ResourcesUtils.GetMessage("lott_app_config_msg13");
            this.label4.Text = ResourcesUtils.GetMessage("lott_app_config_msg14");
            this.lnkLblConfigDB.Text = ResourcesUtils.GetMessage("lott_app_config_msg15");

            //Lotto Winning Prize Amount
            this.lnkLblConfigML.Text = ResourcesUtils.GetMessage("lott_app_config_msg16");
            this.gpbLWPA1.Text = ResourcesUtils.GetMessage("lott_app_config_msg17");
            this.groupBox1.Text = ResourcesUtils.GetMessage("lott_app_config_msg18");
            this.label1.Text = ResourcesUtils.GetMessage("lott_app_config_msg19");
            this.label11.Text = ResourcesUtils.GetMessage("lott_app_config_msg20");
            this.label10.Text = ResourcesUtils.GetMessage("lott_app_config_msg21");
            this.label12.Text = ResourcesUtils.GetMessage("lott_app_config_msg22");

            //Lottery Schedule
            this.groupBox2.Text = ResourcesUtils.GetMessage("lott_app_config_msg23");
            this.groupBox3.Text = ResourcesUtils.GetMessage("lott_app_config_msg24");
            this.label3.Text = ResourcesUtils.GetMessage("lott_app_config_msg25");
            this.chkbLotSchedMon.Text = ResourcesUtils.GetMessage("lott_app_config_msg26");
            this.chkbLotSchedTue.Text = ResourcesUtils.GetMessage("lott_app_config_msg27");
            this.chkbLotSchedWed.Text = ResourcesUtils.GetMessage("lott_app_config_msg28");
            this.chkbLotSchedThurs.Text = ResourcesUtils.GetMessage("lott_app_config_msg29");
            this.chkbLotSchedFri.Text = ResourcesUtils.GetMessage("lott_app_config_msg30");
            this.chkbLotSchedSat.Text = ResourcesUtils.GetMessage("lott_app_config_msg31");
            this.chkbLotSchedSun.Text = ResourcesUtils.GetMessage("lott_app_config_msg32");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LotterySettingsFrm_Load(object sender, EventArgs e)
        {
            HideAllTabsOnTabControl(mainTabControl);
            SetDefaultSelectedSetting();
        }
        private void SetDefaultSelectedSetting()
        {
            mainMenuTreeView.HideSelection = false;
            mainMenuTreeView.SelectedNode = mainMenuTreeView.Nodes[0];
            ShowNodeSettings(mainMenuTreeView.SelectedNode);
        }
        private void HideAllTabsOnTabControl(TabControl theTabControl)
        {
            //theTabControl.Appearance = TabAppearance.FlatButtons;
            //theTabControl.ItemSize = new Size(0, 1);
            //theTabControl.SizeMode = TabSizeMode.Fixed;
            theTabControl.TabPages.Clear();
        }
        private void mainMenuTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowNodeSettings(e.Node);
        }
        private void mainMenuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //ShowNodeSettings(e.Node);
        }
        private void ShowNodeSettings(TreeNode node)
        {
            HideAllTabsOnTabControl(mainTabControl);
            if (node.Name.Equals("nodeLottoOutlet", StringComparison.OrdinalIgnoreCase))
            {
                mainTabControl.TabPages.Add(lotteryOutletTabPage);
                LoadLotteryOutlet();
                lotterySeqGenTabPage.Show();
            }
            else if (node.Name.Equals("nodeLotteryWinComb", StringComparison.OrdinalIgnoreCase))
            {
                mainTabControl.TabPages.Add(lotteryWinPrizeTabPage);
                LoadWinningPrizeAmount();
                lotterySeqGenTabPage.Show();
            }
            else if (node.Name.Equals("nodeLottoSeqGen", StringComparison.OrdinalIgnoreCase))
            {
                mainTabControl.TabPages.Add(lotterySeqGenTabPage);
                LoadSequenceGenerators();
                lotterySeqGenTabPage.Show();
            }
            else if (node.Name.Equals("nodeLottoSched", StringComparison.OrdinalIgnoreCase))
            {
                mainTabControl.TabPages.Add(lotterySchedTabPage);
                LoadScheduleCodes();
                lotterySchedTabPage.Show();
            }
            else if (node.Name.Equals(NODE_NAME_OPTION_CONFIG, StringComparison.OrdinalIgnoreCase))
            {
                mainTabControl.TabPages.Add(lotteryConfigTabPage);
                LoadLotteryConfig();
                lotterySchedTabPage.Show();
            }
            else if (node.Name.Equals("nodeOthers", StringComparison.OrdinalIgnoreCase))
            {
                mainTabControl.TabPages.Add(lotteryOptionsTabPage);
                LoadLotteryOptions();
                lotteryOptionsTabPage.Show();
            }
        }
        #endregion

        #region LISTVIEW SORTER
        private void lvLotteryOutlets_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listviewSorter(sender, e);
        }
        private void lvSeqGenDescriptions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listviewSorter(sender, e);
        }
        private void listviewSorter(object sender, ColumnClickEventArgs e)
        {
            ListView lvObj = (ListView)sender;

            AbstractSorter absSorter = lvwTextSorter;
            if (e.Column > 0) absSorter = lvwIntSorter;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == absSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (absSorter.Order == SortOrder.Ascending) absSorter.Order = SortOrder.Descending;
                else absSorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                absSorter.SortColumn = e.Column;
                absSorter.Order = SortOrder.Ascending;
            }

            if (e.Column == 0) lvObj.ListViewItemSorter = lvwTextSorter;
            else lvObj.ListViewItemSorter = lvwIntSorter;

            // Perform the sort with these new sort options.
            lvObj.Sort();
        }
        #endregion

        #region LOTTERY OUTLET RELATED CODES
        private void LoadLotteryOutlet()
        {
            txtOutletCodeDesc.Text = "";
            UpdateLotteryOutletDescLenLbl();
            lvLotteryOutlets.Items.Clear();
            lvLotteryOutlets.BeginUpdate();
            List<LotteryOutlet> lotteryOutletList = lotteryDataServices.GetLotteryOutlets();

            foreach(LotteryOutlet outlet in lotteryOutletList)
            {
                ListViewItem item = new ListViewItem(outlet.GetDescription());
                item.Tag = outlet;
                lvLotteryOutlets.Items.Add(item);
            }
            lvLotteryOutlets.EndUpdate();
        }
        private void lvLotteryOutlets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLotteryOutlets.SelectedItems.Count <= 0) return;
            LotteryOutlet outlet = GetSelectedLotteryOutlet();
            txtOutletCodeDesc.Text = outlet.GetDescription();
        }
        private LotteryOutlet GetSelectedLotteryOutlet()
        {
            if (lvLotteryOutlets.SelectedItems.Count <= 0) return null;
            ListViewItem item = lvLotteryOutlets.SelectedItems[0];
            LotteryOutlet outlet = (LotteryOutlet)item.Tag;
            return outlet;
        }
        private void btnSaveModDesc_Click(object sender, EventArgs e)
        {
            try
            {
                LotteryOutlet outlet = GetSelectedLotteryOutlet();
                if(outlet == null)
                {
                    MessageBox.Show(ResourcesUtils.GetMessage("lot_sett_val_lot_out_msg3"));
                    return;
                }else if (IsValidateLotteryOutletDescription(txtOutletCodeDesc.Text))
                {
                    return;
                }

                LotteryOutletSetup setup = new LotteryOutletSetup()
                {
                    Id = outlet.GetId(),
                    OutletCode = outlet.GetOutletCode(),
                    Description = txtOutletCodeDesc.Text
                };

                this.lotteryDataServices.UpdateLotteryOutletDescription(setup);
                LoadLotteryOutlet();
                FocusItemOnLotteryOutletList(outlet.GetOutletCode());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FocusItemOnLotteryOutletList(int lotteryOutletCdOrId)
        {
            foreach(ListViewItem item in lvLotteryOutlets.Items)
            {
                LotteryOutlet outlet = (LotteryOutlet)item.Tag;
                if(outlet.GetOutletCode() == lotteryOutletCdOrId || outlet.GetId() == lotteryOutletCdOrId)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    break;
                }
            }
        }
        private void btnSaveLotteryOutlet_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidateLotteryOutletDescription(txtOutletCodeDesc.Text)) return;
                int newId = this.lotteryDataServices.AddLotteryOutlet(txtOutletCodeDesc.Text);
                LoadLotteryOutlet();
                FocusItemOnLotteryOutletList(newId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IsValidateLotteryOutletDescription(String description)
        {
            if (description.Length <= 0)
            {
                MessageBox.Show(ResourcesUtils.GetMessage("lot_sett_val_lot_out_msg1"));
                return true;
            }else if (description.Length > LotteryOutletDaoImpl.MAX_LEN_DESCRIPTION)
            {
                MessageBox.Show(ResourcesUtils.GetMessage("lot_sett_val_lot_out_msg2"));
                return true;
            }
            else if (StringUtils.ContainsInvalidCharacters(description))
            {
                MessageBox.Show(ResourcesUtils.GetMessage("lot_sett_val_lot_out_msg4"));
                return true;
            }
            return false;
        }
        private void txtOutletCodeDesc_TextChanged(object sender, EventArgs e)
        {
            UpdateLotteryOutletDescLenLbl();
        }
        private void UpdateLotteryOutletDescLenLbl()
        {
            lblLotteryOutletDescLen.Text = String.Format("({0}/{1} chars)", 
                txtOutletCodeDesc.Text.Length,
                LotteryOutletDaoImpl.MAX_LEN_DESCRIPTION);
        }
        private void btnLotteryOutletRemove_Click(object sender, EventArgs e)
        {
            try
            {
                LotteryOutlet outlet = GetSelectedLotteryOutlet();
                if (outlet == null)
                {
                    MessageBox.Show(ResourcesUtils.GetMessage("lot_sett_val_lot_out_msg3"));
                    return;
                }

                this.lotteryDataServices.RemoveLotteryOutlet(outlet);
                LoadLotteryOutlet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region LOTTERY WINNING PRIZE AMOUNT RELATED CODES
        private void LoadWinningPrizeAmount()
        {
            this.lblLWPAmatchBet1.Text = String.Format(ResourcesUtils.GetMessage("lott_lwpa_lbls_1"), 1, this.lotteryTicketPanel.GetGameDigitCount());
            this.lblLWPAmatchBet2.Text = String.Format(ResourcesUtils.GetMessage("lott_lwpa_lbls_1"), 2, this.lotteryTicketPanel.GetGameDigitCount());
            this.lblLWPAmatchBet3.Text = String.Format(ResourcesUtils.GetMessage("lott_lwpa_lbls_1"), 3, this.lotteryTicketPanel.GetGameDigitCount());
            this.lblLWPAmatchBet4.Text = String.Format(ResourcesUtils.GetMessage("lott_lwpa_lbls_1"), 4, this.lotteryTicketPanel.GetGameDigitCount());
            this.lblLWPAmatchBet5.Text = String.Format(ResourcesUtils.GetMessage("lott_lwpa_lbls_1"), 5, this.lotteryTicketPanel.GetGameDigitCount());
            this.lblLWPAmatchBet6.Text = String.Format(ResourcesUtils.GetMessage("lott_lwpa_lbls_1"), 6, this.lotteryTicketPanel.GetGameDigitCount());
            SetupLotteryWinningAmtFields();
        }
        private void SetupLotteryWinningAmtFields()
        {
            cmbLWPAGameMode.Items.Clear();
            cmbLWPAGameMode.Items.AddRange(lotteryDataServices.GetLotteries().ToArray());
            if (cmbLWPAGameMode.Items.Count > 0) cmbLWPAGameMode.SelectedItem = cmbLWPAGameMode.Items[0];
        }
        private void cmbLWPAGameMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lottery lottery = (Lottery) cmbLWPAGameMode.SelectedItem;
            lblLWPASelectedGame.Text = lottery.GetDescription();
            LotteryWinningCombination prize = this.lotteryDataServices.GetLotteryWinningCombinations(lottery.GetGameMode());
            txtbLWPABet1.Text = prize.GetMatch1().ToString();
            txtbLWPABet2.Text = prize.GetMatch2().ToString();
            txtbLWPABet3.Text = prize.GetMatch3().ToString();
            txtbLWPABet4.Text = prize.GetMatch4().ToString();
            txtbLWPABet5.Text = prize.GetMatch5().ToString();
            txtbLWPABet6.Text = prize.GetMatch6().ToString();
        }
        private void btnLAWPASaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show(ResourcesUtils.GetMessage("lott_lwpa_msg3"),
                                    ResourcesUtils.GetMessage("lott_lwpa_msg2"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No) return;

                Lottery lottery = (Lottery)cmbLWPAGameMode.SelectedItem;
                LotteryWinningCombination originalCombination = this.lotteryDataServices.GetLotteryWinningCombinations(lottery.GetGameMode());
                LotteryWinningCombinationSetup lotteryUpdated = (LotteryWinningCombinationSetup)originalCombination.Clone();
                lotteryUpdated.Match1 = int.Parse(txtbLWPABet1.Value.ToString());
                lotteryUpdated.Match2 = int.Parse(txtbLWPABet2.Value.ToString());
                lotteryUpdated.Match3 = int.Parse(txtbLWPABet3.Value.ToString());
                lotteryUpdated.Match4 = int.Parse(txtbLWPABet4.Value.ToString());
                lotteryUpdated.Match5 = int.Parse(txtbLWPABet5.Value.ToString());
                lotteryUpdated.Match6 = int.Parse(txtbLWPABet6.Value.ToString());
                this.lotteryDataServices.SaveWinningCombination(lotteryUpdated);
                MessageBox.Show(ResourcesUtils.GetMessage("lott_lwpa_msg1"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region LOTTERY SEQUENCE GENERATORS CODES
        private void LoadSequenceGenerators()
        {
            txtbGenSeqDescription.Text = "";
            UpdateSeqGenDescLenLbl();
            lvSeqGenDescriptions.Items.Clear();
            lvSeqGenDescriptions.BeginUpdate();
            List<LotterySequenceGenerator> lotteryOutletList = lotteryDataServices.GetAllSequenceGenerators();

            foreach (LotterySequenceGenerator seqGen in lotteryOutletList)
            {
                ListViewItem item = new ListViewItem(seqGen.GetDescription());
                item.Tag = seqGen;
                lvSeqGenDescriptions.Items.Add(item);
            }
            lvSeqGenDescriptions.EndUpdate();
        }
        private void btnSeqGenSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidateLotterySeqGenDescription(txtbGenSeqDescription.Text)) return;
                LotterySequenceGeneratorSetup selectedSeqGen = (LotterySequenceGeneratorSetup)GetSelectedLotterySequenceGenerator();
                selectedSeqGen.Description = txtbGenSeqDescription.Text;
                this.lotteryDataServices.UpdateDescriptionLotterySequenceGenerator(selectedSeqGen);
                MessageBox.Show(ResourcesUtils.GetMessage("lott_seq_gen_msg5"));
                LoadSequenceGenerators();
                FocusItemOnLotterySequenceGenerators(selectedSeqGen.GetID());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IsValidateLotterySeqGenDescription(String description)
        {
            if (description.Length <= 0)
            {
                MessageBox.Show(ResourcesUtils.GetMessage("lott_seq_gen_msg2"));
                return true;
            }
            else if (description.Length > LotteryOutletDaoImpl.MAX_LEN_DESCRIPTION)
            {
                MessageBox.Show(ResourcesUtils.GetMessage("lott_seq_gen_msg3"));
                return true;
            }
            else if (StringUtils.ContainsInvalidCharacters(description))
            {
                MessageBox.Show(ResourcesUtils.GetMessage("lott_seq_gen_msg4"));
                return true;
            }
            return false;
        }
        private void lvSeqGenDescriptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSeqGenDescriptions.SelectedItems.Count <= 0) return;
            LotterySequenceGenerator seqGen = GetSelectedLotterySequenceGenerator();
            txtbGenSeqDescription.Text = seqGen.GetDescription();
            UpdateSeqGenDescLenLbl();
        }
        private void txtbGenSeqDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateSeqGenDescLenLbl();
        }
        private LotterySequenceGenerator GetSelectedLotterySequenceGenerator()
        {
            if (lvSeqGenDescriptions.SelectedItems.Count <= 0) return null;
            ListViewItem item = lvSeqGenDescriptions.SelectedItems[0];
            LotterySequenceGenerator seqgen = (LotterySequenceGenerator)item.Tag;
            return seqgen;
        }
        private void UpdateSeqGenDescLenLbl()
        {
            lblSeqGenChars.Text = String.Format("({0}/{1} chars)",
                txtbGenSeqDescription.Text.Length,
                LotteryOutletDaoImpl.MAX_LEN_DESCRIPTION);
        }
        private void FocusItemOnLotterySequenceGenerators(int sequenceGenIdOrSeqId)
        {
            foreach (ListViewItem item in lvSeqGenDescriptions.Items)
            {
                LotterySequenceGenerator seqGen = (LotterySequenceGenerator)item.Tag;
                if (seqGen.GetSeqGenCode() == sequenceGenIdOrSeqId || seqGen.GetID() == sequenceGenIdOrSeqId)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    break;
                }
            }
        }
        #endregion

        #region LOTTERY SCHEDULE CODES
        private void LoadScheduleCodes()
        {
            DefaultLotSchedCheckboxes();
            cmbLotSchedLotteries.Items.Clear();
            cmbLotSchedLotteries.Items.AddRange(lotteryDataServices.GetLotteries().ToArray());
            if (cmbLotSchedLotteries.Items.Count > 0) cmbLotSchedLotteries.SelectedItem = cmbLotSchedLotteries.Items[0];
        }
        private void DefaultLotSchedCheckboxes()
        {
            chkbLotSchedMon.Checked = false;
            chkbLotSchedTue.Checked = false;
            chkbLotSchedWed.Checked = false;
            chkbLotSchedThurs.Checked = false;
            chkbLotSchedFri.Checked = false;
            chkbLotSchedSat.Checked = false;
            chkbLotSchedSun.Checked = false;
        }
        private void btnLotSchedSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show(ResourcesUtils.GetMessage("lott_sched_msg4"), 
                    ResourcesUtils.GetMessage("lott_sched_msg3"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No) return;

                Lottery lottery = (Lottery)cmbLotSchedLotteries.SelectedItem;
                LotteryScheduleSetup lotSchedNew = (LotteryScheduleSetup)this.lotteryDataServices.GetLotterySchedule(lottery.GetGameMode());
                lotSchedNew.Monday = chkbLotSchedMon.Checked;
                lotSchedNew.Tuesday = chkbLotSchedTue.Checked;
                lotSchedNew.Wednesday = chkbLotSchedWed.Checked;
                lotSchedNew.Thursday = chkbLotSchedThurs.Checked;
                lotSchedNew.Friday = chkbLotSchedFri.Checked;
                lotSchedNew.Saturday = chkbLotSchedSat.Checked;
                lotSchedNew.Sunday = chkbLotSchedSun.Checked;
                this.lotteryDataServices.AddNewLotterySchedule(lotSchedNew);
                MessageBox.Show(ResourcesUtils.GetMessage("lott_sched_msg2"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbLotSchedLotteries_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lottery lottery = (Lottery)cmbLotSchedLotteries.SelectedItem;
            lblLotSchedSelectedGame.Text = lottery.GetDescription();
            LotterySchedule lotSched= this.lotteryDataServices.GetLotterySchedule(lottery.GetGameMode());
            chkbLotSchedMon.Checked = lotSched.IsMonday();
            chkbLotSchedTue.Checked = lotSched.IsTuesday();
            chkbLotSchedWed.Checked = lotSched.IsWednesday();
            chkbLotSchedThurs.Checked = lotSched.IsThursday();
            chkbLotSchedFri.Checked = lotSched.IsFriday();
            chkbLotSchedSat.Checked = lotSched.IsSaturday();
            chkbLotSchedSun.Checked = lotSched.IsSunday();
        }
        #endregion

        #region LOTTERY CONFIGURATION
        private void LoadLotteryConfig()
        {

        }
        private void lnkLblConfigDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenDBFile();
        }
        private void lnkLblConfigML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenMLPath();
        }
        private void btnConfigSave_Click(object sender, EventArgs e)
        {
            SaveConfigChanges();
        }
        private void OpenDBFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ResourcesUtils.SourceDBFileDialogFilter;
            openFileDialog.Title = ResourcesUtils.GetMessage("lott_config_db_title");
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (String.IsNullOrWhiteSpace(openFileDialog.FileName)) return;
                txtConfigDBSource.Text = openFileDialog.FileName;
            }
        }
        private void OpenMLPath()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = txtConfigFolderML.Text;
            DialogResult dialogResult = folder.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (String.IsNullOrWhiteSpace(folder.SelectedPath)) return;
                txtConfigFolderML.Text = folder.SelectedPath;
            }
        }
        private bool IsLotteryConfigFieldsValid()
        {
            if (String.IsNullOrWhiteSpace(txtConfigDBSource.Text) || !File.Exists(txtConfigDBSource.Text))
            {
                MessageBox.Show(ResourcesUtils.GetMessage("lott_config_msg1"));
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtConfigFolderML.Text) || !Directory.Exists(txtConfigFolderML.Text))
            {
                MessageBox.Show(ResourcesUtils.GetMessage("lott_config_msg2"));
                return false;
            }
            return true;
        }
        private void SaveConfigChanges()
        {
            try
            {
                if (!IsLotteryConfigFieldsValid()) return;
                lotteryAppConfiguration.DBSourcePath = txtConfigDBSource.Text;
                lotteryAppConfiguration.MLModelPath = txtConfigFolderML.Text;
                lotteryAppConfiguration.SaveConfigFile();
                MessageBox.Show(ResourcesUtils.GetMessage("lott_config_msg3"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region LOTTERY OPTIONS
        private void LoadLotteryOptions()
        {
            dtCutoffTime.Value = this.lotteryDataServices.GetTicketCutoffTime();
            numNotify.Value = this.lotteryDataServices.GetTicketCutoffNotifyTime();
        }
        private void btnSaveOtherOptions_Click(object sender, EventArgs e)
        {
            try
            {
                this.lotteryDataServices.SaveTicketCutoffTime(dtCutoffTime.Value);
                this.lotteryDataServices.SaveTicketCutoffNotifyTime((int)numNotify.Value);
                MessageBox.Show(ResourcesUtils.GetMessage("lott_usr_settings_msg1"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region PUBLIC METHODS
        public void LimitOptionsToConfig()
        {
            TreeNode configNode=null;
            foreach(TreeNode node in this.mainMenuTreeView.Nodes)
            {
                if (node.Name.Equals(NODE_NAME_OPTION_CONFIG, StringComparison.OrdinalIgnoreCase))
                {
                    configNode = node;
                    break;
                }
            }
            this.mainMenuTreeView.Nodes.Clear();
            this.mainMenuTreeView.Nodes.Add(configNode);
        }
        #endregion


    }
}
