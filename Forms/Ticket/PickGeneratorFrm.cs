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
using LottoDataManager.Forms.Others;
using LottoDataManager.Includes.Classes;
using LottoDataManager.Includes.Classes.Comparers;
using LottoDataManager.Includes.Classes.Generator;
using LottoDataManager.Includes.Classes.Generator.PickGenerationProgress;
using LottoDataManager.Includes.Classes.Generator.Types;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Model.Details.Setup;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager.Forms
{
    public partial class PickGeneratorFrm : Form
    {
        private readonly ListviewTextSorter lvwTextSorter = new ListviewTextSorter();
        private readonly ListviewIntSorter lvwIntSorter = new ListviewIntSorter();
        private LotteryDataServices lotteryDataServices;
        private LotteryTicketPanel lotteryTicketPanel;
        private SequenceGeneratorParamFieldsFormFactory seqFactory = SequenceGeneratorParamFieldsFormFactory.GetInstance();
        private String statusPickGenerationLabelCache;
        private bool isPickGeneratorRunningStatus;
        public PickGeneratorFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();
            this.lotteryDataServices = lotteryDataServices;
            this.lotteryTicketPanel = this.lotteryDataServices.GetLotteryTicketPanel();
        }

        private void PickGeneratorFrm_Load(object sender, EventArgs e)
        {
            statusLabel.Text = String.Empty;
            this.Text = String.Format(ResourcesUtils.GetMessage("pick_grp_gen_form_title"),
                this.lotteryDataServices.LotteryDetails.Description);
            btnViewCompareHits.Text = ResourcesUtils.GetMessage("pick_btn_compare_hits");
            grpbxGenType.Text = ResourcesUtils.GetMessage("pick_grp_gen_type");
            grpbxParam.Text = ResourcesUtils.GetMessage("pick_grp_param");
            grpbxActions.Text = ResourcesUtils.GetMessage("pick_grp_actions");
            grpbxOutput.Text = ResourcesUtils.GetMessage("pick_grp_gen_out");
            grpbxFinalActions.Text = ResourcesUtils.GetMessage("pick_grp_fnl_actions");
            btnClearSel.Text = ResourcesUtils.GetMessage("pick_btn_clr_sel");
            btnGenerate.Text = ResourcesUtils.GetMessage("pick_btn_generate");
            btnAddSelected.Text = ResourcesUtils.GetMessage("pick_btn_place_bet");
            btnExit.Text = ResourcesUtils.GetMessage("common_btn_exit");
            linkUncheckAll.Text = ResourcesUtils.GetMessage("common_link_uncheck_all");
            btnStop.Text = ResourcesUtils.GetMessage("common_btn_stop");
            statusPickGenerationLabelCache = ResourcesUtils.GetMessage("pick_status_lbl_pick_generation");
            btnStop.Visible = false;
            isPickGeneratorRunningStatus = false;
            SetupObjectListView();
            EnlistGenerators();
        }
        private void SetupObjectListView()
        {
            this.olvSeq.AspectGetter = delegate (object rowObject)
            {
                LotteryBet lotteryBet = (LotteryBet)rowObject;
                return lotteryBet.GetId();
            };
            this.olvSeq.AspectToStringConverter = delegate (object rowObject)
            {
                return String.Format(" {0}. ) ", rowObject.ToString());
            };

            this.olvNum1.AspectGetter = delegate (object rowObject)
            {
                LotteryBet lotteryBet = (LotteryBet)rowObject;
                return (lotteryBet.GetNum1() == 0) ? "": lotteryBet.GetNum1().ToString();
            };
            this.olvNum2.AspectGetter = delegate (object rowObject)
            {
                LotteryBet lotteryBet = (LotteryBet)rowObject;
                return (lotteryBet.GetNum2() == 0) ? "" : lotteryBet.GetNum2().ToString();
            };
            this.olvNum3.AspectGetter = delegate (object rowObject)
            {
                LotteryBet lotteryBet = (LotteryBet)rowObject;
                return (lotteryBet.GetNum3() == 0) ? "" : lotteryBet.GetNum3().ToString();
            };
            this.olvNum4.AspectGetter = delegate (object rowObject)
            {
                LotteryBet lotteryBet = (LotteryBet)rowObject;
                return (lotteryBet.GetNum4() == 0) ? "" : lotteryBet.GetNum4().ToString();
            };
            this.olvNum5.AspectGetter = delegate (object rowObject)
            {
                LotteryBet lotteryBet = (LotteryBet)rowObject;
                return (lotteryBet.GetNum5() == 0) ? "" : lotteryBet.GetNum5().ToString();
            };
            this.olvNum6.AspectGetter = delegate (object rowObject)
            {
                LotteryBet lotteryBet = (LotteryBet)rowObject;
                return (lotteryBet.GetNum6() == 0) ? "" : lotteryBet.GetNum6().ToString();
            };
        }
        private void objLvGenSeq_SelectionChanged(object sender, EventArgs e)
        {
            if (this.objLvGenSeq.SelectedObjects.Count <= 0) return;
            LotteryBet lotteryBet = (LotteryBet)objLvGenSeq.SelectedObjects[0];
            TextMatchFilter filter = new TextMatchFilter(this.objLvGenSeq);
            List<OLVColumn> tmpOLVColumns = new List<OLVColumn>();
            tmpOLVColumns.Add(objLvGenSeq.GetColumn(1));
            tmpOLVColumns.Add(objLvGenSeq.GetColumn(2));
            tmpOLVColumns.Add(objLvGenSeq.GetColumn(3));
            tmpOLVColumns.Add(objLvGenSeq.GetColumn(4));
            tmpOLVColumns.Add(objLvGenSeq.GetColumn(5));
            tmpOLVColumns.Add(objLvGenSeq.GetColumn(6));
            filter.Columns = tmpOLVColumns.ToArray();

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
            this.objLvGenSeq.ModelFilter = filter;
            this.objLvGenSeq.DefaultRenderer = highlightTextRenderer;
            this.objLvGenSeq.SelectedForeColor = Color.Black;
            this.objLvGenSeq.Refresh();
        }
        private void EnlistGenerators()
        {
            DisplayGenerators(new LuckyPickGenerator(this.lotteryDataServices));
            DisplayGenerators(new TopDrawCurrentSeasonGenerator(this.lotteryDataServices));
            DisplayGenerators(new TopDrawPreviousSeasonGenerator(this.lotteryDataServices));
            DisplayGenerators(new TopDrawnNumbersFromJackpotGenerator(this.lotteryDataServices));
            DisplayGenerators(new RandomNumbersFromJackpotsDigitsGenerator(this.lotteryDataServices));
            DisplayGenerators(new TopDrawNumbersFromDateRange(this.lotteryDataServices));
            DisplayGenerators(new NumberNotYetPickUpGenerator(this.lotteryDataServices));
            DisplayGenerators(new RandomPatternSequenceGenerator(this.lotteryDataServices));
            DisplayGenerators(new NumsNotYetBetCurSeasonGenerator(this.lotteryDataServices));
            DisplayGenerators(new HistoricalFrequencyRandomGenerator(this.lotteryDataServices));
            DisplayGenerators(new RandomPickTotalSumBetweenGenerators(this.lotteryDataServices));
            DisplayGenerators(new RandomPickTotalSumBetweenGenerators1n31(this.lotteryDataServices));
            DisplayGenerators(new RandomPickTotalSumBetweenGeneratorsUsingTopPickCurSeason(this.lotteryDataServices));
            DisplayGenerators(new RandomPrediction(this.lotteryDataServices));
            DisplayGenerators(new RandomPredictionDrawResults(this.lotteryDataServices));
            DisplayGenerators(new RandomPredictionSDCARegression(this.lotteryDataServices));
            DisplayGenerators(new RandomPredictionSDCARegressionInBetween(this.lotteryDataServices));
            DisplayGenerators(new LottoCountMatchPredictionFastTreeRegression(this.lotteryDataServices));
            DisplayGenerators(new DrawResultWinCountFastTreeTweedieRandomGenerator(this.lotteryDataServices));
        }
        private void DisplayGenerators(SequenceGenerator seqGen)
        {
            lvGenType.AddObject(seqGen);
        }
        private void LayoutGeneratorsParams(SequenceGenerator seqGen)
        {
            tblPnlLayParams.SuspendLayout();
            List<SequenceGeneratorParams> seqParams = seqGen.GetFieldParameters();
            tblPnlLayParams.ColumnStyles.Clear();
            tblPnlLayParams.RowStyles.Clear();
            tblPnlLayParams.ColumnCount = 2;
            tblPnlLayParams.RowCount = seqParams.Count+1;
            
            int rowsCount = tblPnlLayParams.RowCount;
            int colsCount = tblPnlLayParams.ColumnCount;
            //Single percHeight = ((Single)1 / (Single)rowsCount) * 100;
            Single percWidth = ((Single)1 / (Single)colsCount) * 100;

            //generate the require columns
            for (int ctr = 1; ctr <= colsCount; ctr++)
            {
                tblPnlLayParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percWidth));
            }

            //add each rows
            for (int rowCtr = 0; rowCtr <= rowsCount; rowCtr++)
            {
                SequenceGeneratorParams sgp = ((seqParams.Count-1) >= rowCtr) ? seqParams[rowCtr] : null;
                //add each column and its content in the current row that to add
                for (int colCtr = 0; colCtr < colsCount; colCtr++)
                {
                    Control control;
                    if (colCtr == 0 && sgp !=null) //put the label
                    {
                        control = new Label() { 
                            Text = sgp.Description, 
                            Dock = DockStyle.Fill, 
                            TextAlign = ContentAlignment.MiddleLeft 
                        };
                    }
                    else if (colCtr == 1 && sgp != null) // put the control here.
                    {
                        control = seqFactory.GetControl(sgp);
                    }
                    else
                    {
                        control = new Label() { Text = "" };
                    }
                    tblPnlLayParams.Controls.Add(control, colCtr, tblPnlLayParams.RowCount-1);
                }
                tblPnlLayParams.RowCount = tblPnlLayParams.RowCount + 1;
                tblPnlLayParams.RowStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }
            tblPnlLayParams.ResumeLayout();
        }
        private void DisplayGeneratedSequence(List<int[]> seqArr)
        {
            List<LotteryBet> arrLottery = new List<LotteryBet>();
            int ctrId = 0;
            foreach (int[] seq in seqArr)
            {
                LotteryBetSetup bet = new LotteryBetSetup();
                bet.Id = ++ctrId;
                for (int seqCtr = 0; seqCtr < seq.Length; seqCtr++)
                {
                    bet.FillNumberBySeq(seqCtr+1, seq[seqCtr]);
                }
                arrLottery.Add(bet);
            }
            objLvGenSeq.Tag = lvGenType.SelectedObject;
            objLvGenSeq.SetObjects(arrLottery);
        }
        private void btnClearSel_Click(object sender, EventArgs e)
        {
            lvGenType.SelectedItems.Clear();
            objLvGenSeq.SetObjects(null);
            objLvGenSeq.Tag = null;
            ClearSequenceGenParametersValue();
            statusLabel.Text = String.Empty;
            this.objLvGenSeq.ModelFilter = null;
            this.objLvGenSeq.DefaultRenderer = null;
        }
        private void ClearSequenceGenParametersValue()
        {
            tblPnlLayParams.Controls.Clear();
            objLvGenSeq.Tag = null;
            foreach (SequenceGenerator seqGen in lvGenType.Objects)
            {
                seqGen.ResetParamsValue();
            }
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (lvGenType.SelectedObjects.Count > 0)
            {
                SequenceGenerator seqGen = (SequenceGenerator)lvGenType.SelectedObject;
                AbstractSequenceGenerator seqGenAbstract = (AbstractSequenceGenerator) seqGen;
                seqGenAbstract.PickGenerationProgress += SeqGenAbstract_PickGenerationProgress;
                isPickGeneratorRunningStatus = true;
                String errMsg = "";
                if(!seqGen.AreParametersValueValid(out errMsg))
                {
                    MessageBox.Show(errMsg);
                    return;
                }
                ButtonAvailabilityWhilePicking(true);
                DisplayGeneratedSequence(seqGen.GenerateSequence());
            }
            ButtonAvailabilityWhilePicking(false);
        }
        private void SeqGenAbstract_PickGenerationProgress(object sender, PickGenerationProgressEvent e)
        {
            if(isPickGeneratorRunningStatus == false)
            {
                SequenceGenerator seqGen = (SequenceGenerator)lvGenType.SelectedObject;
                AbstractSequenceGenerator seqGenAbstract = (AbstractSequenceGenerator)seqGen;
                if (seqGenAbstract == null) return;
                seqGenAbstract.StopPickGeneration();
            }
            statusLabel.Text = String.Format(statusPickGenerationLabelCache, e.GeneratedPickCount, e.GenerationAttemptCount);
            if (e.GenerationAttemptCount % 200 == 0) Application.DoEvents();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            isPickGeneratorRunningStatus = false;
        }
        private void ButtonAvailabilityWhilePicking(bool isPicking)
        {
            if (isPicking)
            {
                addBetToolStripMenuItem.Enabled = false;
                lvGenType.Enabled = false;
                btnAddSelected.Enabled = false;
                btnViewCompareHits.Enabled = false;
                btnClearSel.Enabled = false;
                btnGenerate.Enabled = false;
                btnStop.Visible = true;
                this.objLvGenSeq.ModelFilter = null;
                this.objLvGenSeq.DefaultRenderer = null;
            }
            else
            {
                addBetToolStripMenuItem.Enabled = true;
                lvGenType.Enabled = true;
                btnAddSelected.Enabled = true;
                btnViewCompareHits.Enabled = true;
                btnClearSel.Enabled = true;
                btnGenerate.Enabled = true;
                btnStop.Visible = false;
                isPickGeneratorRunningStatus = false;
                statusLabel.Text = String.Empty;
            }
        }
        private void lvGenType_SelectionChanged(object sender, EventArgs e)
        {
            if (lvGenType.SelectedObjects.Count <= 0) return;
            ClearSequenceGenParametersValue();
            LayoutGeneratorsParams((SequenceGenerator) lvGenType.SelectedObject);
        }
        #region "Listview Sorter"
        private void lvGenSeq_ColumnClick(object sender, ColumnClickEventArgs e)
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

            if(e.Column == 0) lvObj.ListViewItemSorter = lvwTextSorter;
            else lvObj.ListViewItemSorter = lvwIntSorter;

            // Perform the sort with these new sort options.
            lvObj.Sort();
        }
        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.btnStop_Click(sender, e);
            this.Close();
        }
        private void linkUncheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UncheckAllSequences();
        }
        private void UncheckAllSequences()
        {
            foreach (OLVListItem item in objLvGenSeq.CheckedItems)
            {
                item.Checked = false;
            }
        }
        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            AddChosenBets();
        }
        private void addBetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChosenBets();
        }
        private void AddChosenBets()
        {
            List<LotteryBet> merge = new List<LotteryBet>();
            foreach (LotteryBet item in objLvGenSeq.CheckedObjects)
            {
                merge.Add(item);
            }
            AddBet(merge);
        }
        private void AddBet(List<LotteryBet> listViewItems)
        {
            using (AddBetFrm bet = new AddBetFrm(this.lotteryDataServices)) {
                StringBuilder sequence = new StringBuilder();
                foreach (LotteryBet item in listViewItems)
                {
                    bet.AddSequenceEntry(item.GetGNUFormat());
                    sequence.Clear();
                }

                if (objLvGenSeq.Tag !=null) bet.SelectedSequenceGenerator = ((SequenceGenerator)objLvGenSeq.Tag).GetSequenceGeneratorType();
                Form refToMainForm = ClassReflectionUtil.GetMainFormObj(this, this.Owner);
                if (refToMainForm == null) refToMainForm = this;
                bet.ShowDialog(refToMainForm);
            }
        }
        private void checkToolStripMenuItem_CheckSelected(object sender, EventArgs e)
        {
             foreach (OLVListItem item in objLvGenSeq.SelectedItems)
            {
                item.Checked = true;
            }
        }
        private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllSequences();
        }
        private void PickGeneratorFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.None)
            {
                e.Cancel = true;
            }
        }
        private void btnViewCompareHits_Click(object sender, EventArgs e)
        {
            if (objLvGenSeq.Objects == null) return;
            HitComparisonFrm hitComparisonFrm = new HitComparisonFrm(this.lotteryDataServices);
            List<LotteryBet> arrBet = new List<LotteryBet>();
            LotteryOutlet outlet = this.lotteryDataServices.GetDefaultLotteryOutlet();

            foreach (LotteryBetSetup item in objLvGenSeq.Objects)
            {
                SequenceGenerator seqGentor = ((SequenceGenerator)objLvGenSeq.Tag);
                LotterySequenceGeneratorSetup seqGen = new LotterySequenceGeneratorSetup();
                seqGen.ID = seqGentor.GetSequenceGeneratorID();
                seqGen.Description = seqGentor.GetDescription();
                item.LotterySeqGen = seqGen;
                item.LotteryOutlet = outlet;
                item.TargetDrawDate = DateTime.Now;
                arrBet.Add(item);
            }
            hitComparisonFrm.UserDefinedLotteryBets = arrBet;
            hitComparisonFrm.LotteryBetsCheckboxes = true;
            hitComparisonFrm.ShowDialog(this);
            AutoCheckSelectedBetsFromHitComparisonForm(hitComparisonFrm.GetCheckedLotteryBets);
            hitComparisonFrm.Dispose();
        }
        private void AutoCheckSelectedBetsFromHitComparisonForm(List<LotteryBet> selectedLotteryBets)
        {
            LotteryBet seqGenVisibleItem = null;
            foreach (LotteryBet bet in selectedLotteryBets)
            {
                foreach (LotteryBet seqGen in objLvGenSeq.Objects)
                {
                    if(seqGen.GetGNUFormat().Equals(bet.GetGNUFormat(), StringComparison.OrdinalIgnoreCase))
                    {
                        objLvGenSeq.CheckObject(seqGen);
                        seqGenVisibleItem = seqGen;
                    }
                }
            }
            //ensure last item check is visible/auto scroll
            if (seqGenVisibleItem != null) objLvGenSeq.EnsureModelVisible(seqGenVisibleItem);
        }
    }
}
