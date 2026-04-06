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
    public partial class FrmListRoles : Form
    {
        private static DataTable _dtallroles = ClsRoles.GetAllRoles();
        public FrmListRoles()
        {
            InitializeComponent();
        }

        private void FrmListRoles_Load(object sender, EventArgs e)
        {
            dgvallroles.DataSource = _dtallroles;
            lblRecordsCount.Text = dgvallroles.Rows.Count.ToString();
        }
        private void _RefreshRolesList()
        {
            _dtallroles = ClsRoles.GetAllRoles();
            dgvallroles.DataSource = _dtallroles;
            lblRecordsCount.Text = dgvallroles.Rows.Count.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmAddRoles frm = new FrmAddRoles();
            frm.ShowDialog();
            _RefreshRolesList();
        }

        private void DeleteRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Roles [" + dgvallroles.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (ClsRoles.DeleteRoles((int)dgvallroles.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Roles Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshRolesList();
                }

                else
                    MessageBox.Show("Roles was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}