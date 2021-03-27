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
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;

namespace LottoDataManager.Forms
{
    public partial class LotterySettingsFrm : Form
    {
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LotterySettingsFrm_Load(object sender, EventArgs e)
        {
            HideAllTabsOnTabControl(mainTabControl);
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
            ShowNodeSettings(e.Node);
        }

        private void ShowNodeSettings(TreeNode node)
        {
            HideAllTabsOnTabControl(mainTabControl);
            if (node.Name.Equals("nodeLottoOutlet", StringComparison.OrdinalIgnoreCase))
            {
                mainTabControl.TabPages.Add(lotteryOutletTabPage);
                lotterySeqGenTabPage.Show();
            }
            else if (node.Name.Equals("nodeLotteryWinComb", StringComparison.OrdinalIgnoreCase))
            {
                mainTabControl.TabPages.Add(lotteryWinPrizeTabPage);
                lotterySeqGenTabPage.Show();
            }
            else if (node.Name.Equals("nodeLottoSeqGen", StringComparison.OrdinalIgnoreCase))
            {
                mainTabControl.TabPages.Add(lotterySeqGenTabPage);
                lotterySeqGenTabPage.Show();
            }
            else if (node.Name.Equals("nodeLottoSched", StringComparison.OrdinalIgnoreCase))
            {
                mainTabControl.TabPages.Add(lotterySchedTabPage);
                lotterySchedTabPage.Show();
            }
        }
    }
}
