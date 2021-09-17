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
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Forms
{
    public partial class ModifyBetDateFrm : Form
    {
        private LotteryDataServices lotteryDataServices;
        private LotteryTicketPanel lotteryTicketPanel;
        private List<LotteryOutlet> lotteryOutletArr;
        private LotterySchedule lotterySchedule;
        private List<long> autoSelectBetList;
        private DateTime autoSelectBetLowestDate;
        private bool hasDataUpdate = false;
        public ModifyBetDateFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();
            this.lotteryDataServices = lotteryDataServices;
            this.lotteryTicketPanel = this.lotteryDataServices.GetLotteryTicketPanel();
            this.lotteryOutletArr = this.lotteryDataServices.GetLotteryOutlets();
            this.lotterySchedule = this.lotteryDataServices.GetLotterySchedule();
            this.autoSelectBetList = new List<long>();
            this.autoSelectBetLowestDate = DateTime.Now;
            InitializesFormLabels();
            InitializesListViewColumns();
        }

        private void InitializesFormLabels()
        {
            gbStartingDates.Text = ResourcesUtils.GetMessage("mdd_form_starting_dates");
            gbDateCal.Text = ResourcesUtils.GetMessage("mdd_form_date_cal"); 
            gbTargetDrawDate.Text = ResourcesUtils.GetMessage("mdd_form_target_draw_date");
            gbSelectedDate.Text = ResourcesUtils.GetMessage("mdd_form_selected_date"); 
            btnExit.Text = ResourcesUtils.GetMessage("common_btn_exit");
            btnRefresh.Text = ResourcesUtils.GetMessage("common_btn_refresh");
            btnSaveChanges.Text = ResourcesUtils.GetMessage("common_btn_save_changes");
            lblDateEvery.Text = String.Format(ResourcesUtils.GetMessage("mdd_form_every_draw_dates"),lotterySchedule.DrawDateEvery());
            label1.Text = ResourcesUtils.GetMessage("common_cal_date_from");
            label2.Text = ResourcesUtils.GetMessage("common_cal_date_to");
            txtStatus.Text = "";
            linkLabelFilterNow.Text = ResourcesUtils.GetMessage("common_link_filter_now");
        }

        #region MAIN FORMS
        private void ModifyBetDateFrm_Load(object sender, EventArgs e)
        {
            dateTimePickerBets.Value = DateTimeConverterUtils.GetDefaultFilterDateFrom();
            dateTimePickerBetsTo.Value = DateTimeConverterUtils.GetDefaultFilterDateTo();
            FillUpBetList();
            ResizeColumnsBetList();
            LoadTheAutoSelect();
        }
        #endregion

        #region Bottom Buttons
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(ResourcesUtils.GetMessage("mdd_form_others_mgs7"),
                ResourcesUtils.GetMessage("mdd_form_others_mgs8"), MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK)
            {
                SaveChanges();
            }
            else
            {
                log(ResourcesUtils.GetMessage("mdd_form_validation_msg7"));
            }
        }
        private void btnRestoreBack_Click(object sender, EventArgs e)
        {
            FillUpBetList();
        }
        private void SaveChanges()
        {
            try
            {
                txtStatus.Text = "";
                if (oblViewBets.CheckedItems.Count <= 0)
                {
                    log(ResourcesUtils.GetMessage("mdd_form_validation_msg1"));
                    return;
                }
                log(ResourcesUtils.GetMessage("mdd_form_others_mgs2"));
                if (!IsValidated())
                {
                    log(ResourcesUtils.GetMessage("mdd_form_others_mgs4"));
                    return;
                }

                log(ResourcesUtils.GetMessage("mdd_form_others_mgs1"));
                DateTime newDateTime = dtDrawDate.Value.Date;

                foreach(OLVListItem item in oblViewBets.CheckedItems)
                {
                    LotteryBetSetup bet = (LotteryBetSetup) item.RowObject;
                    bet.TargetDrawDate = newDateTime;

                    if (lotteryDataServices.IsLotteryBetExist(bet))
                    {
                        log(String.Format(ResourcesUtils.GetMessage("mdd_form_validation_msg3"), 
                            bet.GetTargetDrawDateFormatted(), bet.GetGNUFormat()));
                    }
                    else
                    {
                        this.lotteryDataServices.SaveLotteryBetChange(bet);
                        hasDataUpdate = true;
                        log(String.Format(ResourcesUtils.GetMessage("mdd_form_validation_msg4"),
                            bet.GetTargetDrawDateFormatted(), bet.GetGNUFormat()));
                    }
                }

                log(ResourcesUtils.GetMessage("mdd_form_others_mgs3"));
                log(ResourcesUtils.GetMessage("mdd_form_others_mgs5"));
                FillUpBetList();
                log(ResourcesUtils.GetMessage("mdd_form_others_mgs6"));
            }
            catch (Exception ex)
            {
                log(ex.Message);
                log(ResourcesUtils.GetMessage("mdd_form_others_mgs4"));
            }
        }
        private bool IsValidated()
        {
            DateTime newDateTime = dtDrawDate.Value.Date;
            if (!lotterySchedule.IsDrawDateMatchLotterySchedule(newDateTime))
            {
                log(String.Format(ResourcesUtils.GetMessage("mdd_form_validation_msg2"),
                    newDateTime.Date.ToString("dddd"),
                    lotterySchedule.DrawDateEvery()));
                return false;
            }
            else if (newDateTime.CompareTo(DateTimeConverterUtils.GetYear2011())<0) //if earlier
            {
                log(ResourcesUtils.GetMessage("mdd_form_validation_msg5"));
                return false;
            }
            else if (newDateTime.CompareTo(DateTime.Now.Date) == 0) //if the same
            {
                log(ResourcesUtils.GetMessage("mdd_form_validation_msg6"));
                return false;
            }
            return true;
        }
        private void log(String msg)
        {
            if (txtStatus.Text.Length > 0) txtStatus.AppendText("\r\n");
            txtStatus.AppendText(msg);
        }
        public bool HasDataUpdates
        {
            get { return hasDataUpdate; }
        }
        #endregion

        #region Bet List
        private void linkLabelFilterNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FillUpBetList();
        }
        private void FillUpBetList()
        {
            try
            {
                oblViewBets.SetObjects(lotteryDataServices.GetLottoBets(dateTimePickerBets.Value, dateTimePickerBetsTo.Value));
                oblViewBets.Sort(olvColDrawDate, SortOrder.Descending);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void ResizeColumnsBetList()
        {
            this.olvColChkbox.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvColNumComb.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.olvLottoOutlet.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvLottoSeqGen.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.oblViewBets.Refresh();
        }
        private void InitializesListViewColumns()
        {
            this.olvColNumComb.AspectName = "GetGNUFormat";
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
        #endregion

        #region Public Interface
        public void AddAutoSelectBet(long betId, DateTime betDrawDate)
        {
            if (!autoSelectBetList.Contains(betId)) autoSelectBetList.Add(betId);

            if(autoSelectBetLowestDate.Date.CompareTo(betDrawDate) > 0){
                //keep our date lower and lower so we can auto select those bet ID's
                autoSelectBetLowestDate = betDrawDate; 
            }
        }
        private void LoadTheAutoSelect()
        {
            if (autoSelectBetList.Count <= 0) return;
            if (autoSelectBetLowestDate == null) return;

            dateTimePickerBets.Value = autoSelectBetLowestDate;
            FillUpBetList();
            foreach (OLVListItem item in oblViewBets.Items)
            {
                LotteryBet bet = (LotteryBet)item.RowObject;
                if (autoSelectBetList.Contains(bet.GetId()))
                {
                    item.Checked = true;
                }
            }
        }
        #endregion
    }
}
