﻿using System;
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
using LottoDataManager.Includes.Classes.Comparers;
using LottoDataManager.Includes.Classes.Generator;
using LottoDataManager.Includes.Classes.Generator.Types;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
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

        public PickGeneratorFrm(LotteryDataServices lotteryDataServices)
        {
            InitializeComponent();
            this.lotteryDataServices = lotteryDataServices;

            //Debugging
            //if(lotteryDataServices==null)
            //    this.lotteryDataServices = new LotteryDataServices(new Game658());
            //end debugging

            this.lotteryTicketPanel = this.lotteryDataServices.GetLotteryTicketPanel();
        }

        private void PickGeneratorFrm_Load(object sender, EventArgs e)
        {
            grpbxGenType.Text = ResourcesUtils.GetMessage("pick_grp_gen_type");
            grpbxParam.Text = ResourcesUtils.GetMessage("pick_grp_param");
            grpbxActions.Text = ResourcesUtils.GetMessage("pick_grp_actions");
            grpbxOutput.Text = ResourcesUtils.GetMessage("pick_grp_gen_out");
            grpbxFinalActions.Text = ResourcesUtils.GetMessage("pick_grp_fnl_actions");
            btnClearSel.Text = ResourcesUtils.GetMessage("pick_btn_clr_sel");
            btnGenerate.Text = ResourcesUtils.GetMessage("pick_btn_generate");

            EnlistGenerators();
            //LayoutGeneratorsParams();
        }

        private int GetSpecificGeneratedValue(object rowObject, int index)
        {
            if (rowObject == null) return 0;
            int[] seq = (int[])rowObject;
            return seq[index];
        }
        private void EnlistGenerators()
        {
            DisplayGenerators(new LuckyPickGenerator(this.lotteryDataServices));
            DisplayGenerators(new TopDrawCurrentSeasonGenerator(this.lotteryDataServices));
            DisplayGenerators(new TopDrawPreviousSeasonGenerator(this.lotteryDataServices));
            DisplayGenerators(new TopDrawnNumbersFromJackpotGenerator(this.lotteryDataServices));
            DisplayGenerators(new RandomNumbersFromJackpotsDigitsGenerator(this.lotteryDataServices));
            DisplayGenerators(new TopDrawNumbersFromDateRange(this.lotteryDataServices));
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
            lvGenSeq.BeginUpdate();
            lvGenSeq.Items.Clear();
            int ctr = 1;
            foreach(int[] seq in seqArr)
            {
                ListViewItem item = new ListViewItem(String.Format(" {0}. ) ",ctr++));
                
                for (int seqCtr=0; seqCtr < seq.Length; seqCtr++)
                {
                    item.SubItems.Add(seq[seqCtr].ToString());
                }
                lvGenSeq.Items.Add(item);
            }
            lvGenSeq.EndUpdate();
        }
        private void btnClearSel_Click(object sender, EventArgs e)
        {
            lvGenType.SelectedItems.Clear();
            ClearSequenceGenParametersValue();
        }
        private void ClearSequenceGenParametersValue()
        {
            tblPnlLayParams.Controls.Clear();
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
                String errMsg = "";
                if(!seqGen.AreParametersValueValid(out errMsg))
                {
                    MessageBox.Show(errMsg);
                    return;
                }
                DisplayGeneratedSequence(seqGen.GenerateSequence());
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

    }
}
