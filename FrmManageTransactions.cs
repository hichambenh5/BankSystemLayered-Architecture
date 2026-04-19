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
    public partial class FrmManageTransactions : Form
    {
        private DataTable _dtalltransaction = ClsTransaction.GetAllTransactions();
        public FrmManageTransactions()
        {
            InitializeComponent();
        }

        private void Btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmManageTransactions_Load(object sender, EventArgs e)
        {
            dgvalltrasaction.DataSource = _dtalltransaction;
            lblRecordsCount.Text = _dtalltransaction.Rows.Count.ToString();
        }
        private void _RefreshTransactionList()
        {
            _dtalltransaction = ClsTransaction.GetAllTransactions();
            dgvalltrasaction.DataSource = _dtalltransaction;
            lblRecordsCount.Text = _dtalltransaction.Rows.Count.ToString();
        }
    }
}
