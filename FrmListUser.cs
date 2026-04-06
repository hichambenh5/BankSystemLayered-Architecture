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
    public partial class FrmListUser : Form
    {
        private static DataTable _DtAllUser = ClsUser.GetAllUsers();
        public FrmListUser()
        {
            InitializeComponent();
        }

        private void FrmListUser_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = _DtAllUser;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }
        private void _RefreshUserList()
        {
            _DtAllUser = ClsUser.GetAllUsers();
            dgvUsers.DataSource = _DtAllUser;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmAddRoles frm = new FrmAddRoles();
            frm.ShowDialog();
        }

        private void UpdateUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddNewUser frm = new FrmAddNewUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void SerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Users [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                if (ClsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUserList();
                }

                else
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
