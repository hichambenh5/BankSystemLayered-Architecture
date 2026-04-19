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
    public partial class FrmListAccount : Form
    {
        private static DataTable _dtallaccount = ClsAccount.GetAllAccount();
        public FrmListAccount()
        {
            InitializeComponent();
        }

        private void Btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmListAccount_Load(object sender, EventArgs e)
        {
            dgvallaccount.DataSource = _dtallaccount;
            lblRecordsCount.Text = dgvallaccount.Rows.Count.ToString();
        }
        private void _RefreshAccountList()
        {
            _dtallaccount = ClsAccount.GetAllAccount();
            dgvallaccount.DataSource = _dtallaccount;
            lblRecordsCount.Text = dgvallaccount.Rows.Count.ToString();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "AccountID":
                    FilterColumn = "AccountID";
                    break;
                case "PersonID":
                    FilterColumn = "PersonID";
                    break;
                case "AccountTypeID":
                    FilterColumn = "AccountTypeID";
                    break;
                case "AccountNumber":
                    FilterColumn = "AccountNumber";
                    break;
                case "None":
                    FilterColumn = "None";
                    break;
                    

            }
            if (txtfilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtallaccount.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvallaccount.Rows.Count.ToString();
                return;
            }
            if (txtfilter.Text.Trim() == "AccountNumber")
            {
                _dtallaccount.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtfilter.Text.Trim());
            }
            else
                _dtallaccount.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtfilter.Text.Trim());
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfilter.Visible = (cbFilter.Text != "None");
            if (txtfilter.Visible)
            {
                txtfilter.Text = "";
                txtfilter.Focus();
            }
        }

        private void AddNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditAccount frm = new frmAddEditAccount();
            frm.ShowDialog();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditAccount frm = new frmAddEditAccount((int)dgvallaccount.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Account [" + dgvallaccount.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                if (ClsAccount.DeleteAccount((int)dgvallaccount.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Account Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAccountList();
                }

                else
                    MessageBox.Show("Account was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccountTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int accountid = (int)dgvallaccount.CurrentRow.Cells[0].Value;
            FrmAccountTransactions frm = new FrmAccountTransactions(accountid);
            frm.ShowDialog();
        }
    }
}
