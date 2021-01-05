using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LottoDataManager.Includes.Model;
using LottoDataManager.Includes.Model.Settings;

namespace LottoDataManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializesFormContent();
        }

        private void InitializesFormContent()
        {
            LotteryDetails lotteryDetails = new Game642();
        }

    }
}
