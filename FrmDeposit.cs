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
    public partial class FrmDeposit : Form
    {
        public FrmDeposit()
        {
            InitializeComponent();
            ctrlAccountCardWithFilter1.OnAccountSelected += CtrlAccountCardWithFilter1_OnAccountSelected;
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void FrmDeposit_Load(object sender, EventArgs e)
        {

        }

        private void Btnnext_Click(object sender, EventArgs e)
        {
           
            tabControl1.SelectedIndex++;
            nmAmount.Focus();
        }

        private void CtrlAccountCardWithFilter1_OnAccountSelected(int obj)
        {
            btnnext.Enabled = true;
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            int accountid = ctrlAccountCardWithFilter1._AccountID;
            decimal Amount = nmAmount.Value;
            if (MessageBox.Show("Are you sure you want to deposit " + Amount.ToString("C") + " into this account?",
                    "Confirm Transaction",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (ClsTransaction.Deposit(accountid, Amount))
            {
                MessageBox.Show("Deposit transaction completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
