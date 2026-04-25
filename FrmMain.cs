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
        frmLogin _login;
        public FrmMain(frmLogin login)
        {
            InitializeComponent();
            _login = login;
        }
        private bool CheckUserPermission(ClsRoles.enPermissions permissions)
        {
            if (ClsGlobal.CurrentUser.Permissions == (int)ClsRoles.enPermissions.eAll) return true;
            return ClsRoles.CheckAccess(ClsGlobal.CurrentUser.Permissions, (int)permissions);
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
            FrmAddNewUser frm = new FrmAddNewUser(ClsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
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

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditAccount frm = new frmAddEditAccount();
            frm.ShowDialog();
        }

        private void AddNewAccountTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAddEditAccountType frm = new FrmAddEditAccountType();
            frm.ShowDialog();
        }

        private void ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListAccount frm = new FrmListAccount();
            frm.ShowDialog();
            
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            clientsToolStripMenuItem.Enabled = CheckUserPermission(ClsRoles.enPermissions.eManageClients);
            usersToolStripMenuItem.Enabled = CheckUserPermission(ClsRoles.enPermissions.eManageUsers);
            transactionsToolStripMenuItem.Enabled = CheckUserPermission(ClsRoles.enPermissions.eTransactions);
            rolesToolStripMenuItem.Enabled = CheckUserPermission(ClsRoles.enPermissions.eUpdatePermissions);
        }

        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {

        }

        private void AccountSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ChangePassordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmChangePassword frm = new FrmChangePassword(ClsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void SignOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsGlobal.CurrentUser = null;
            _login.Show();
            this.Close();
        }

        private void ListAccountTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListAccountType frm = new FrmListAccountType();
            frm.ShowDialog();
        }

        private void DepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDeposit frm = new FrmDeposit();
            frm.ShowDialog();
        }

        private void WithdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWithdraw frm = new FrmWithdraw();
            frm.ShowDialog();
        }

        private void TransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTransfer frm = new FrmTransfer();
            frm.ShowDialog();
        }

        private void FrmManageTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageTransactions frm = new FrmManageTransactions();
            frm.ShowDialog();
        }
    }
}