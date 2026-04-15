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
    public partial class FrmListAccountType : Form
    {
        private static DataTable _dtAllAccounttype = ClsAccountType.GetAllAccountType();
        public FrmListAccountType()
        {
            InitializeComponent();
        }

        private void FrmListAccountType_Load(object sender, EventArgs e)
        {
            dgvAllAccountType.DataSource = _dtAllAccounttype;
            lblRecordsCount.Text = _dtAllAccounttype.Rows.Count.ToString();
        }
        private void _RefreshAccountTypeList()
        {
            _dtAllAccounttype = ClsAccountType.GetAllAccountType();
            dgvAllAccountType.DataSource = _dtAllAccounttype;
            lblRecordsCount.Text = _dtAllAccounttype.Rows.Count.ToString();
        }

        private void AddNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditAccountType frm = new FrmAddEditAccountType();
            frm.ShowDialog();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditAccountType frm = new FrmAddEditAccountType((int)dgvAllAccountType.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Account Type [" + dgvAllAccountType.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                if (ClsAccountType.DeleteAccountType((int)dgvAllAccountType.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Account Type Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAccountTypeList();
                }

                else
                    MessageBox.Show("Account Type was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
