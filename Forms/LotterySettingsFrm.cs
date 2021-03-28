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

        public LotterySettingsFrm(LotteryDataServices lotteryDataServices)
        {
            //Debugging
            if (lotteryDataServices == null) lotteryDataServices = new LotteryDataServices(new Game658());
            //this.betDateTime = new DateTime(2021,01,3,0,0,0);
            //end debugging

            InitializeComponent();
            this.lotteryDataServices = lotteryDataServices;
            this.lotteryTicketPanel = this.lotteryDataServices.GetLotteryTicketPanel();
        }

        #region MAIN FORM
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
        }
        #endregion

        #region "LISTVIEW SORTER"
        private void lvLotteryOutlets_ColumnClick(object sender, ColumnClickEventArgs e)
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

        }
        #endregion

        #region LOTTERY SEQUENCE GENERATORS CODES
        private void LoadSequenceGenerators()
        {

        }
        #endregion

        #region LOTTERY SCHEDULE CODES
        private void LoadScheduleCodes()
        {

        }




        #endregion


    }
}
