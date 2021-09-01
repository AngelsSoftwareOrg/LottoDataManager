using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;
using LottoDataManager.Includes.Classes;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Details.Setup;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Forms
{
    public partial class ModifyClaimsFrm : Form
    {
        private LotteryDataServices lotteryDataServices;
        private LotteryTicketPanel lotteryTicketPanel;
        private readonly String MODIFIED_TAG = "modified";

        public ModifyClaimsFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();
            this.lotteryDataServices = lotteryDataServices;

            //Debugging
            //if(lotteryDataServices==null)
            //    this.lotteryDataServices = new LotteryDataServices(new Game658());
            //end debugging

            this.lotteryTicketPanel = this.lotteryDataServices.GetLotteryTicketPanel();
            InitializesForms();
        }

        private void InitializesForms()
        {
            SetupForms();
            dateTimePickerBets.Value = DateTime.Now.AddYears(-1);
            FillUpBetList();
            ResizeColumnsBetList();
            objectListViewWinningBets.UseHotControls = false;
            objectListViewWinningBets.UseCellFormatEvents = false;
            toolStripProgBar.Visible = false;
            toolStripStatusLbl.Text = "";
        }
        private void SetupForms()
        {
            this.Text = String.Format(ResourcesUtils.GetMessage("mod_clm_stat_msg_1"),
                this.lotteryDataServices.LotteryDetails.Description);
            this.label1.Text = ResourcesUtils.GetMessage("mod_clm_stat_msg_2");
            this.linkLabelFilterNow.Text = ResourcesUtils.GetMessage("mod_clm_stat_msg_3");
            this.label2.Text = ResourcesUtils.GetMessage("mod_clm_stat_msg_4");
            this.linkCheckAll.Text = ResourcesUtils.GetMessage("common_link_check_all");
            this.linkUnCheckAll.Text = ResourcesUtils.GetMessage("common_link_uncheck_all");
            this.btnRestoreBack.Text = ResourcesUtils.GetMessage("common_btn_restore_back");
            this.btnSaveChanges.Text = ResourcesUtils.GetMessage("common_btn_save_changes");
            this.btnExit.Text = ResourcesUtils.GetMessage("common_btn_exit");
        }

        #region "Forms functions"
        private void ObjectListViewBets_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            try
            {
                if (e.NewValue.ToString() == e.Value.ToString()) e.Cancel = true;
                if (e.Cancel == false)
                {
                    int newValue = int.Parse(e.NewValue.ToString());
                    if (!lotteryTicketPanel.IsWithinMinMax(newValue)) 
                        throw new Exception(String.Format(ResourcesUtils.GetMessage("mod_clm_stat_msg_6"), 
                            lotteryTicketPanel.GetMin(), lotteryTicketPanel.GetMax()));

                    ObjectListView lv = (ObjectListView)sender;
                    LotteryBetSetup setup = (LotteryBetSetup)e.RowObject;
                    setup.FillNumberBySeq(e.SubItemIndex - 1, newValue);
                    e.ListViewItem.Tag = MODIFIED_TAG;
                    lv.RefreshObject(e.RowObject);
                    lv.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ResourcesUtils.GetMessage("mod_clm_stat_msg_7"));
                e.Cancel = true;
            }
            finally
            {
                ColorListViewItemIfModified(e.ListViewItem);
            }
        }
        private void ColorListViewItemIfModified(OLVListItem item)
        {
            if (IsListViewItemModified(item))
            {
                for(int x=0; x<item.SubItems.Count; x++)
                {
                    item.GetSubItem(x).BackColor = Color.Tomato;
                }
            }
        }
        private bool IsListViewItemModified(OLVListItem item)
        {
            if (item.Tag == null) return false;
            if (!String.IsNullOrEmpty(item.Tag.ToString()))
            {
                if (item.Tag.ToString().Equals(MODIFIED_TAG, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRestoreBack_Click(object sender, EventArgs e)
        {
            FillUpBetList();
        }
        private void SaveLotteryBetsChanges()
        {
            //get all rows with modification
            List<LotteryWinningBetSetup> modifiedWinBetsArr = new List<LotteryWinningBetSetup>();
            foreach (OLVListItem item in objectListViewWinningBets.Items)
            {
                if (IsListViewItemModified(item))
                {
                    LotteryWinningBetSetup winbet = (LotteryWinningBetSetup)item.RowObject;
                    winbet.ClaimStatus = item.Checked;
                    modifiedWinBetsArr.Add(winbet);
                }
            }
            if (modifiedWinBetsArr.Count <= 0) return;

            try
            {
                DialogResult dr = MessageBox.Show(ResourcesUtils.GetMessage("mod_clm_stat_msg_8"),
                         ResourcesUtils.GetMessage("mod_clm_stat_msg_9"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    toolStripProgBar.Value = 0;
                    toolStripProgBar.Visible = true;
                    Application.DoEvents();
                    int ctr = 0;
                    int totalCheckedObjects = modifiedWinBetsArr.Count;
                    foreach (LotteryWinningBet lotWinBet in modifiedWinBetsArr)
                    {
                        toolStripStatusLbl.Text = String.Format(ResourcesUtils.GetMessage("mod_clm_stat_msg_10"), String.Join("-",lotWinBet.GetAllNumberSequence()));
                        toolStripProgBar.Value = ConverterUtils.GetPercentageFloored(++ctr, totalCheckedObjects);
                        this.lotteryDataServices.UpdateClaimStatus(lotWinBet);
                        Application.DoEvents();
                    }
                    FillUpBetList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ResourcesUtils.GetMessage("mod_clm_stat_msg_11"));
                FillUpBetList();
            }
            finally
            {
                toolStripStatusLbl.Text = "";
                toolStripProgBar.Value = 0;
                toolStripProgBar.Visible = false;
            }
        }
        private void linkCheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetCheckListViewBets(true);
        }
        private void linkUnCheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetCheckListViewBets(false);
        }
        #endregion

        #region "List View Bets"
        private void FillUpBetList()
        {
            objectListViewWinningBets.SetObjects(lotteryDataServices.GetLotteryWinningBets(dateTimePickerBets.Value));
            foreach (OLVListItem item in objectListViewWinningBets.Items)
            {
                LotteryWinningBet bet = (LotteryWinningBet)item.RowObject;
                item.Checked = bet.IsClaimed();
            }
        }
        private void objectListViewWinningBets_FormatRow(object sender, FormatRowEventArgs e)
        {
            e.UseCellFormatEvents = true;
        }
        private void objectListViewWinningBets_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.CellValue == null) return;
            if (e.ColumnIndex < 3 || e.ColumnIndex > 8) return;
            LotteryWinningBet bet = (LotteryWinningBet)e.Model;
            if (bet.IsWinningNum(int.Parse(e.CellValue.ToString())))
            {
                e.SubItem.BackColor = Color.LightGoldenrodYellow;
            }
        }
        private void ResizeColumnsBetList()
        {
            this.olvColChkbox.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColWinAmt.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum2.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum3.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum4.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum5.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum6.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.objectListViewWinningBets.Refresh();
        }
        private void linkLabelFilterNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FillUpBetList();
        }
        private void objectListViewBets_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            OLVListItem eOlv = (OLVListItem)e.Item;
            LotteryWinningBet bet = (LotteryWinningBet)eOlv.RowObject;
            e.Item.Tag = (eOlv.Checked == bet.IsClaimed()) ? null : MODIFIED_TAG;
            ColorListViewItemIfModified((OLVListItem)e.Item);
        }
        #endregion

        #region "Context Menu for List View Bet Details"
        private void SetCheckListViewBetsSelected(bool isCheck)
        {
            if(isCheck) objectListViewWinningBets.CheckObjects(objectListViewWinningBets.SelectedObjects);
            if(!isCheck) objectListViewWinningBets.UncheckObjects(objectListViewWinningBets.SelectedObjects);
        }
        private void SetCheckListViewBets(bool isCheck)
        {
            if (isCheck) objectListViewWinningBets.CheckObjects(objectListViewWinningBets.Objects);
            if (!isCheck) objectListViewWinningBets.UncheckObjects(objectListViewWinningBets.Objects);
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillUpBetList();
        }
        private void checkedHighlightedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckListViewBetsSelected(true);
        }
        private void uncheckedIghlightedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckListViewBetsSelected(false);
        }
        private void checkAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckListViewBets(true);
        }
        private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckListViewBets(false);
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            SaveLotteryBetsChanges();
        }
        #endregion


    }
}
