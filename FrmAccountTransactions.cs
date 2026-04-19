using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANKSYSTEMWINDOWSFORMS
{
    public partial class FrmAccountTransactions : Form
    {
        public int accountid = -1;
        private DataTable _dttransactionaccount;
        public FrmAccountTransactions(int Accountid)
        {
            InitializeComponent();
            accountid = Accountid;
           _dttransactionaccount = ClsTransaction.GetAccountHistory(accountid);
        }
        
        private void Btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAccountTransactions_Load(object sender, EventArgs e)
        {
            dgvtransactionaccount.DataSource = _dttransactionaccount;
            
        }
    }
}
