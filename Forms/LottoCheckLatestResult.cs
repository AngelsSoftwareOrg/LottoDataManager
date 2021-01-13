using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Includes.Classes.Scraping;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Details;

namespace LottoDataManager.Forms
{
    public partial class LottoCheckLatestResult : Form
    {

        public LottoCheckLatestResult()
        {
            InitializeComponent();
        }

        private void LottoCheckLatestResult_Load(object sender, EventArgs e)
        {
            LotteryDetails lotteryDetails = new Game655();

            List<LotteryDetails> lotteryDetailsArr = new List<LotteryDetails>();
/*            lotteryDetailsArr.Add(new Game658());
            lotteryDetailsArr.Add(new Game655());
            lotteryDetailsArr.Add(new Game649());
            lotteryDetailsArr.Add(new Game645());
            lotteryDetailsArr.Add(new Game642());*/
            LottoScraper c = new LottoScraper();
            c.StartScraping(lotteryDetailsArr);
        }
    }
}
