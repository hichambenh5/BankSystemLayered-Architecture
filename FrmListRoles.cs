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
    }
}
