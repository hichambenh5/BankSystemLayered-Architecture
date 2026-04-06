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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ClientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ListClientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmListCustomer frm = new FrmListCustomer();
            frm.ShowDialog();
        }

        private void AddClientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer frm = new frmAddEditCustomer();
            frm.ShowDialog();
        }

        private void ListRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListRoles frm = new FrmListRoles();
            frm.ShowDialog();
        }

        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddRoles frm = new FrmAddRoles();
            frm.ShowDialog();
        }

        private void DeleteClientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ListUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListUser frm = new FrmListUser();
            frm.ShowDialog();

        }
    }
}