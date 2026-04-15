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
    public partial class FrmAddEditAccountType : Form
    {
        public delegate void DataBackEventHandler(object sender, int accounttypeID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode;
        private int _AccounttypeID = -1;
        ClsAccountType _accountType;
        public FrmAddEditAccountType()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public FrmAddEditAccountType(int accounttypeid)
        {
            InitializeComponent();
            _AccounttypeID = accounttypeid;
            Mode = enMode.Update;
           
        }
        private void _ResetDefualtValues()
        {
            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Account Type";
                _accountType = new ClsAccountType();
               
            }
            else
            {
                lblTitle.Text = "Update Account Type";
            }
            txtNameType.Text = "";
            nmMinimumbalance.Value = 0;

        }
        private void _LoadData()
        {
            _accountType = ClsAccountType.find(_AccounttypeID);
            if (_accountType == null)
            {
                MessageBox.Show("No account type with ID = " + _AccounttypeID, "account type Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblAccounttypeID.Text = _AccounttypeID.ToString();
            txtNameType.Text = _accountType.TypeName;
            nmMinimumbalance.Value = _accountType.MinimumBalance;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _accountType.TypeName = txtNameType.Text;
            _accountType.MinimumBalance = nmMinimumbalance.Value;
            if (_accountType.Save())
            {
                lblAccounttypeID.Text = _accountType.AccountTypeID.ToString();
                Mode = enMode.Update;
                lblTitle.Text = "Update Account Type";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this, _accountType.AccountTypeID);
            }
        }

        private void FrmAddEditAccountType_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (Mode == enMode.Update)
            {
                _LoadData();
            }
        }
    }
}
