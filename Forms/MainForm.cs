using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Includes.Database.DAO;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;
using LottoDataManager.Includes.Utilities;

namespace LottoDataManager
{
    public partial class MainForm : Form
    {
        private LotteryDetails lotteryDetails;
        public MainForm()
        {
            InitializeComponent();
            InitializesFormContent();
        }

        private void InitializesFormContent()
        {
            //debug
            this.lotteryDetails = new Game642();
            //debug end

            RefreshWinningNummbersGridContent();

        }

        private void RefreshWinningNummbersGridContent()
        {
            LotteryDrawResultDao lotteryDrawResultDao = LotteryDrawResultDaoImpl.GetInstance();
            objListVwWinningNum.SetObjects(lotteryDetails.GetAllLotteryDrawResults());
            this.olvColDrawDate.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum2.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum3.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum4.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum5.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColNum6.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColJackpot.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.olvColWinners.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            objListVwWinningNum.EnsureVisible(objListVwWinningNum.Items.Count - 1);
        }


    }
}
