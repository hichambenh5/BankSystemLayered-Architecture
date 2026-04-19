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
    public partial class FrmWithdraw : Form
    {
       
        public FrmWithdraw()
        {
            InitializeComponent();
            ctrlAccountCardWithFilter1.OnAccountSelected += CtrlAccountCardWithFilter1_OnAccountSelected;
        }

        private void Btnnext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void CtrlAccountCardWithFilter1_OnAccountSelected(int obj)
        {
            tabControl1.SelectedIndex = 1;
            nmAmount.Focus();
           
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
           int accountid = ctrlAccountCardWithFilter1._AccountID;
            decimal amount = nmAmount.Value;
            ClsAccount account = ClsAccount.Find(accountid);
            if (account == null)
            {
                MessageBox.Show("Account not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (amount > account.Balance)
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to Withdraw " + amount.ToString("C") + " into this account?",
                   "Confirm Transaction",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (ClsTransaction.Withdraw(accountid, amount))
            {
                MessageBox.Show("Withdraw transaction completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlAccountCardWithFilter1.LoadAccountInfo(accountid);
                this.Close();
            }
            else
            {
                MessageBox.Show("Transaction failed. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
    }
}
