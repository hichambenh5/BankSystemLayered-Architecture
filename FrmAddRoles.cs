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
    public partial class FrmAddRoles : Form
    {
        public delegate void DataBackEventHandler(object sender, int RolesID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode;
        private int _RoleID = -1;
        ClsRoles _roles;
        public FrmAddRoles()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public FrmAddRoles(int RoleID)
        {
            InitializeComponent();
            _RoleID = RoleID;
            Mode = enMode.Update;
        }
        private void _ResetDefualtValues()
        {
            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Role";
                _roles = new ClsRoles();
            }
            else
            {
                lblTitle.Text = "Update New Role";
            }
            lblID.Text = "";
            txtRolesName.Text = "";
            txteManageClients.Text = "";
            txteManageUsers.Text = "";
            txteManageRegisters.Text = "";
            txteTransactions.Text = "";
            txteUpdatePermissions.Text = "";
           
        }
        private void _LoadData()
        {
            _roles = ClsRoles.Find(_RoleID);
            if (_roles == null)
            {
                MessageBox.Show("Not Found");
                return;
            }
            lblID.Text = _roles.RoleID.ToString();
            txtRolesName.Text = _roles.RoleName;
            txteManageClients.Text = ClsRoles.CheckAccess(_roles.Permissions,(int) ClsRoles.enPermissions.eManageClients)?"1":"0";
            txteManageUsers.Text = ClsRoles.CheckAccess(_roles.Permissions, (int)ClsRoles.enPermissions.eManageUsers) ? "1" : "0";
            txteManageRegisters.Text = ClsRoles.CheckAccess(_roles.Permissions, (int)ClsRoles.enPermissions.eManageRegisters) ? "1" : "0";
            txteTransactions.Text = ClsRoles.CheckAccess(_roles.Permissions, (int)ClsRoles.enPermissions.eTransactions) ? "1" : "0";
            txteUpdatePermissions.Text = ClsRoles.CheckAccess(_roles.Permissions, (int)ClsRoles.enPermissions.eUpdatePermissions) ? "1" : "0";
            if (_roles.Permissions == -1)
            {
                rdeAll.Select();
            }
            else if (_roles.Permissions == 0)
            {
                rdeNone.Select();
            }
        }

        private void FrmAddRoles_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (Mode == enMode.Update)
            {
                _LoadData();
            }
        }
        private int _CalculatePermissions()
        {
            if (rdeAll.Checked)
            {
                return -1;
            }
            if (rdeNone.Checked)
            {
                return 0;
            }
            int SelectedPermissions = 0;
            if (txteManageClients.Text == "1")
            {
                SelectedPermissions += (int)ClsRoles.enPermissions.eManageClients;
            }
            if (txteManageUsers.Text == "1")
            {
                SelectedPermissions += (int)ClsRoles.enPermissions.eManageUsers;
            }
            if (txteManageRegisters.Text == "1")
            {
                SelectedPermissions += (int)ClsRoles.enPermissions.eManageRegisters;
            }
            if (txteTransactions.Text == "1")
            {
                SelectedPermissions += (int)ClsRoles.enPermissions.eTransactions;
            }
            if (txteUpdatePermissions.Text == "1")
            {
                SelectedPermissions += (int)ClsRoles.enPermissions.eUpdatePermissions;
            }
            return SelectedPermissions;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _roles.RoleName = txtRolesName.Text;
            _roles.Permissions = _CalculatePermissions();
            if (_roles.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
                Mode = enMode.Update;
                lblTitle.Text = "Update Role";
                lblID.Text = _roles.RoleID.ToString();
                DataBack?.Invoke(this, _RoleID);
            }
            else
            {
                MessageBox.Show("Error: Data was not saved.");
            }
        }
    }
}
