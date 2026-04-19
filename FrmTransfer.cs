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
    public partial class FrmTransfer : Form
    {
        public FrmTransfer()
        {
            InitializeComponent();
            ctrlFromAccount.OnAccountSelected += CtrlFromAccount_OnAccountSelected;
            ctrlToAccount.OnAccountSelected += CtrlToAccount_OnAccountSelected;

        }

        private void Btnnext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }

        private void CtrlFromAccount_Load(object sender, EventArgs e)
        {

        }

        private void CtrlFromAccount_OnAccountSelected(int obj)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void CtrlToAccount_OnAccountSelected(int obj)
        {
            tabControl1.SelectedIndex = 2;
            nmAmount.Focus();
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            int accountfrom = ctrlFromAccount._AccountID;
            int accountto = ctrlToAccount._AccountID;
            decimal amount = nmAmount.Value;
            if (accountfrom == accountto)
            {
                MessageBox.Show("Source and Destination accounts must be different.");
                return;
            }
            ClsAccount account = ClsAccount.Find(accountfrom);
            if (account == null)
            {
                MessageBox.Show("Account not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (amount > account.Balance)
            {
                MessageBox.Show("The amount exceeds your current balance!", "Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure you want to Transfer " + amount.ToString("C") + " into this account?",
                  "Confirm Transaction",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (ClsTransaction.Transfer(accountfrom, accountto, amount))
            {
                MessageBox.Show("Transfer transaction completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlFromAccount.LoadAccountInfo(accountfrom);
                ctrlToAccount.LoadAccountInfo(accountto);
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
    }
}
