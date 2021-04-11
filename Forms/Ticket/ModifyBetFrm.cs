﻿using System;
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
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Forms
{
    public partial class ModifyBetFrm : Form
    {
        private LotteryDataServices lotteryDataServices;
        private LotteryTicketPanel lotteryTicketPanel;
        private readonly String MODIFIED_TAG = "modified";
        private List<LotteryOutlet> lotteryOutletList;
        private List<LotterySequenceGenerator> lotterySequenceGeneratorList;

        public ModifyBetFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();
            this.lotteryDataServices = lotteryDataServices;
            this.lotteryTicketPanel = this.lotteryDataServices.GetLotteryTicketPanel();
            this.lotteryOutletList = this.lotteryDataServices.GetLotteryOutlets();
            this.lotterySequenceGeneratorList = this.lotteryDataServices.GetAllSequenceGenerators();
            InitializesForms();
        }
        private void InitializesForms()
        {
            SetupForms();
            dateTimePickerBets.Value = DateTime.Now.AddYears(-1);
            InitializesListViewColumns();
            FillUpBetList();
            ResizeColumnsBetList();
            objectListViewBets.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways;
            objectListViewBets.CellEditStarting += ObjectListViewBets_CellEditStarting;
            objectListViewBets.CellEditFinishing += ObjectListViewBets_CellEditFinishing;
            objectListViewBets.CellEditFinished += ObjectListViewBets_CellEditFinished;
            objectListViewBets.UseHotControls = false;
            objectListViewBets.UseCellFormatEvents = false;
            toolStripProgBar.Visible = false;
            toolStripStatusLbl.Text = "";
        }
        private void SetupForms()
        {
            this.Text = ResourcesUtils.GetMessage("modfy_bets_msg_1");
            this.label1.Text = ResourcesUtils.GetMessage("modfy_bets_msg_2");
            this.linkLabelFilterNow.Text = ResourcesUtils.GetMessage("modfy_bets_msg_3");
            this.label2.Text = ResourcesUtils.GetMessage("modfy_bets_msg_4");
            this.btnRestoreBack.Text = ResourcesUtils.GetMessage("common_btn_restore_back");
            this.btnSaveChanges.Text = ResourcesUtils.GetMessage("common_btn_save_changes");
            this.btnExit.Text = ResourcesUtils.GetMessage("common_btn_exit");
        }
        private void InitializesListViewColumns()
        {
            this.olvLottoOutlet.AspectGetter = delegate (object rowObject)
            {
                LotteryBet lotteryBet = (LotteryBet)rowObject;
                LotteryOutlet outlet = lotteryBet.GetLotteryOutlet();
                return outlet;
            };

            this.olvLottoOutlet.AspectToStringConverter = delegate (object rowObject)
            {
                LotteryOutlet outlet = (LotteryOutlet)rowObject;
                return outlet.GetDescription();
            };

            this.olvLottoSeqGen.AspectGetter = delegate (object rowObject)
            {
                LotteryBet lotteryBet = (LotteryBet)rowObject;
                LotterySequenceGenerator outlet = lotteryBet.GetLotterySequenceGenerator();
                return outlet;
            };

            this.olvLottoSeqGen.AspectToStringConverter = delegate (object rowObject)
            {
                LotterySequenceGenerator seqgen = (LotterySequenceGenerator)rowObject;
                return seqgen.GetDescription();
            };
        }
        #region "Forms functions"
        private LotteryOutlet GetOutletObject(int outletCd)
        {
            return lotteryOutletList.Find(item => item.GetOutletCode() == outletCd);
        }
        private LotterySequenceGenerator GetSeqGenObject(int seqgencd)
        {
            return lotterySequenceGeneratorList.Find(item => item.GetSeqGenCode() == seqgencd);
        }
        private void ObjectListViewBets_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column == this.olvLottoOutlet || e.Column == this.olvLottoSeqGen)
            {
                ComboBox cmb = (ComboBox)e.Control;
                if (cmb.SelectedItem != null) e.NewValue = cmb.SelectedItem;
            }
        }
        private void ObjectListViewBets_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            try
            {
                if (e.Column == this.olvLottoOutlet)
                {
                    LotteryOutlet oldval = (LotteryOutlet)e.Value;
                    LotteryOutlet newval = (LotteryOutlet)e.NewValue;
                    if (newval == null) { e.Cancel = true; return; }
                    if (oldval.GetOutletCode() == newval.GetOutletCode()) e.Cancel = true;
                    if (e.Cancel == false)
                    {
                        ObjectListView lv = (ObjectListView)sender;
                        LotteryBetSetup setup = (LotteryBetSetup)e.RowObject;
                        setup.OutletCode = newval.GetOutletCode();
                        e.ListViewItem.Tag = MODIFIED_TAG;
                        setup.LotteryOutlet = GetOutletObject(newval.GetOutletCode());
                        lv.RefreshObject(e.RowObject);
                        lv.Refresh();
                    }
                }
                else if (e.Column == this.olvLottoSeqGen)
                {
                    LotterySequenceGenerator oldval = (LotterySequenceGenerator)e.Value;
                    LotterySequenceGenerator newval = (LotterySequenceGenerator)e.NewValue;
                    if (newval == null) { e.Cancel = true; return; }
                    if (oldval.GetSeqGenCode() == newval.GetSeqGenCode()) e.Cancel = true;
                    if (e.Cancel == false)
                    {
                        ObjectListView lv = (ObjectListView)sender;
                        LotteryBetSetup setup = (LotteryBetSetup)e.RowObject;
                        e.ListViewItem.Tag = MODIFIED_TAG;
                        setup.LotterySeqGen = GetSeqGenObject(newval.GetSeqGenCode());
                        lv.RefreshObject(e.RowObject);
                        lv.Refresh();
                    }
                }
                else
                {
                    if (e.NewValue.ToString() == e.Value.ToString()) e.Cancel = true;
                    if (e.Cancel == false)
                    {
                        int newValue = int.Parse(e.NewValue.ToString());
                        if (!lotteryTicketPanel.IsWithinMinMax(newValue))
                            throw new Exception(String.Format(ResourcesUtils.GetMessage("modfy_bets_msg_5"),
                                lotteryTicketPanel.GetMin(), lotteryTicketPanel.GetMax()));

                        ObjectListView lv = (ObjectListView)sender;
                        LotteryBetSetup setup = (LotteryBetSetup)e.RowObject;
                        setup.FillNumberBySeq(e.SubItemIndex - 1, newValue);
                        e.ListViewItem.Tag = MODIFIED_TAG;
                        lv.RefreshObject(e.RowObject);
                        lv.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ResourcesUtils.GetMessage("modfy_bets_msg_6"));
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
                item.BackColor = Color.Tomato;
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
        private void ObjectListViewBets_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column == this.olvLottoOutlet)
            {
                ComboBox outletCodeEditorCmb = new ComboBox();
                outletCodeEditorCmb.Items.AddRange(lotteryOutletList.ToArray());
                outletCodeEditorCmb.Bounds = e.CellBounds;
                outletCodeEditorCmb.Font = ((ObjectListView)sender).Font;

                int selectedIndex = 0;
                LotteryBet bet = (LotteryBet)e.RowObject;
                for (int i = 0; i < outletCodeEditorCmb.Items.Count; i++)
                {
                    LotteryOutlet outlet = (LotteryOutlet) outletCodeEditorCmb.Items[i];
                    if (outlet.GetOutletCode() == bet.GetOutletCode())
                    {
                        selectedIndex = i;
                        break;
                    }
                }
                // should select the entry that reflects the current value
                if (outletCodeEditorCmb.Items.Count>0) outletCodeEditorCmb.SelectedIndex = selectedIndex; 
                e.Control = outletCodeEditorCmb;

            }else if (e.Column == this.olvLottoSeqGen)
            {
                ComboBox seqgenEditorCmb = new ComboBox();
                seqgenEditorCmb.Items.AddRange(lotterySequenceGeneratorList.ToArray());
                seqgenEditorCmb.Bounds = e.CellBounds;
                seqgenEditorCmb.Font = ((ObjectListView)sender).Font;

                int selectedIndex = 0;
                LotteryBet bet = (LotteryBet)e.RowObject;
                for (int i = 0; i < seqgenEditorCmb.Items.Count; i++)
                {
                    LotterySequenceGenerator seqGen = (LotterySequenceGenerator)seqgenEditorCmb.Items[i];
                    if (seqGen.GetSeqGenCode() == bet.GetLotterySequenceGenerator().GetSeqGenCode())
                    {
                        selectedIndex = i;
                        break;
                    }
                }
                // should select the entry that reflects the current value
                if (seqgenEditorCmb.Items.Count > 0) seqgenEditorCmb.SelectedIndex = selectedIndex;
                e.Control = seqgenEditorCmb;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRestoreBack_Click(object sender, EventArgs e)
        {
            FillUpBetList();
        }
        private void btnDeleteChecked_Click(object sender, EventArgs e)
        {
            DeleteLotteryBets();
        }
        private void DeleteLotteryBets()
        {
            if (objectListViewBets.CheckedObjects.Count <= 0) return;
            try
            {
                DialogResult dr = MessageBox.Show(ResourcesUtils.GetMessage("modfy_bets_msg_7"),
                         ResourcesUtils.GetMessage("modfy_bets_msg_8"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    toolStripProgBar.Value = 0;
                    toolStripProgBar.Visible = true;
                    Application.DoEvents();
                    int ctr = 0;
                    int totalCheckedObjects = objectListViewBets.CheckedObjects.Count;
                    foreach (LotteryBet lotBet in objectListViewBets.CheckedObjects)
                    {
                        toolStripStatusLbl.Text = String.Format(ResourcesUtils.GetMessage("modfy_bets_msg_9"), lotBet.GetSimpleContentDetails());
                        toolStripProgBar.Value = ConverterUtils.GetPercentageFloored(++ctr, totalCheckedObjects);
                        this.lotteryDataServices.DeleteLotteryBet(lotBet);
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ResourcesUtils.GetMessage("modfy_bets_msg_10"));
            }
            finally
            {
                toolStripStatusLbl.Text = "";
                toolStripProgBar.Value = 0;
                toolStripProgBar.Visible = false;
                FillUpBetList();
            }
        }
        private void SaveLotteryBetsChanges()
        {
            //get all rows with modification
            List<LotteryBet> modifiedBetsArr = new List<LotteryBet>();
            foreach (OLVListItem item in objectListViewBets.Items)
            {
                if (IsListViewItemModified(item))
                {
                    modifiedBetsArr.Add((LotteryBet) item.RowObject);
                }
            }
            if (modifiedBetsArr.Count <= 0) return;

            try
            {
                DialogResult dr = MessageBox.Show(ResourcesUtils.GetMessage("modfy_bets_msg_11"),
                         ResourcesUtils.GetMessage("modfy_bets_msg_12"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {

                    toolStripProgBar.Value = 0;
                    toolStripProgBar.Visible = true;
                    Application.DoEvents();
                    int ctr = 0;
                    int totalCheckedObjects = modifiedBetsArr.Count;
                    foreach (LotteryBet lotBet in modifiedBetsArr)
                    {
                        toolStripStatusLbl.Text = String.Format(ResourcesUtils.GetMessage("modfy_bets_msg_13"), lotBet.GetSimpleContentDetails());
                        toolStripProgBar.Value = ConverterUtils.GetPercentageFloored(++ctr, totalCheckedObjects);
                        this.lotteryDataServices.SaveLotteryBetChange(lotBet);
                        Application.DoEvents();
                    }
                    FillUpBetList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ResourcesUtils.GetMessage("modfy_bets_msg_14"));
                FillUpBetList();
            }
            finally
            {
                toolStripStatusLbl.Text = "";
                toolStripProgBar.Value = 0;
                toolStripProgBar.Visible = false;
            }
        }
        #endregion

        #region "List View Bets"
        private void FillUpBetList()
        {
            objectListViewBets.SetObjects(lotteryDataServices.GetLottoBets(dateTimePickerBets.Value));
        }
        private void ResizeColumnsBetList()
        {
            this.olvColChkbox.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum2.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum3.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum4.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum5.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNum6.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvLottoOutlet.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvLottoSeqGen.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.objectListViewBets.Refresh();
        }
        private void linkLabelFilterNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FillUpBetList();
        }
        private void objectListViewBets_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ColorListViewItemIfModified((OLVListItem)e.Item);
        }
        #endregion

        #region "Context Menu for List View Bet Details"
        private void SetCheckListViewBetsSelected(bool isCheck)
        {
            if(isCheck) objectListViewBets.CheckObjects(objectListViewBets.SelectedObjects);
            if(!isCheck) objectListViewBets.UncheckObjects(objectListViewBets.SelectedObjects);
        }
        private void SetCheckListViewBets(bool isCheck)
        {
            if (isCheck) objectListViewBets.CheckObjects(objectListViewBets.Objects);
            if (!isCheck) objectListViewBets.UncheckObjects(objectListViewBets.Objects);
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
