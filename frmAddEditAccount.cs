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
    public partial class frmAddEditAccount : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode;
        private int _AccountID = -1;
        private ClsAccount _Account;
        public frmAddEditAccount()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            ctrlCustomerCardWithFilter1.OnCustomerSelected += (customerID) => {
                if (customerID != -1)
                {
                    _Account.PersonID = customerID;
                }
            };
        }
        public frmAddEditAccount(int accountid)
        {
            InitializeComponent();
            _AccountID = accountid;
            Mode = enMode.Update;
            ctrlCustomerCardWithFilter1.OnCustomerSelected += (customerID) => {
                _Account.PersonID = customerID;
            };

        }
        private void _FillAccountTypes()
        {
            DataTable dtAccountTypes = ClsAccountType.GetAllAccountType();

            if (dtAccountTypes != null && dtAccountTypes.Columns.Count > 0)
            {
                
                cmbaccounttype.DataSource = null;

             
                cmbaccounttype.DataSource = dtAccountTypes;

              
                cmbaccounttype.DisplayMember = "TypeName";
                cmbaccounttype.ValueMember = "AccountTypeID";
            }
            else
            {
               
                MessageBox.Show("Warning: No account types found in database!");
            }
        }
        private void _ResetDefaultValues()
        {
            _FillAccountTypes();

            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Account";
                _Account = new ClsAccount();
            }
            else
            {
                lblTitle.Text = "Update Account";
            }

           
            numericUpDown1.Value = 0;
           txtAccountnumber.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;
            cmbaccounttype.SelectedIndex = 0;
            
        }
        private void _LoadData()
        {
           _Account = ClsAccount.Find(_AccountID);
            if (_Account == null)
            {
                MessageBox.Show("No account  with ID = " + _AccountID, "account  Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
           lblaccountid.Text = _AccountID.ToString();
           txtAccountnumber.Text = _Account.AccountNumber;
           numericUpDown1.Value = _Account.Balance;

        }
        private void FrmAddEditAccount_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (Mode == enMode.Update)
            {
                _LoadData();

            }
          
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ctrlCustomerCardWithFilter1.CustomerID == -1)
            {
                MessageBox.Show("Please select a customer first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _Account.AccountNumber = txtAccountnumber.Text;
            _Account.Balance = numericUpDown1.Value;
            _Account.AccountTypeID = (int)cmbaccounttype.SelectedValue;
            _Account.Status = cmbStatus.Text;
            _Account.CreationDate = DateTime.Now;
            _Account.CreatedByUserID = ClsGlobal.CurrentUser.UserID; 
            _Account.PersonID = ctrlCustomerCardWithFilter1.CustomerID;

            if (_Account.Save())
            {
                lblaccountid.Text = _Account.AccountID.ToString();
                Mode = enMode.Update;
                lblTitle.Text = "Update Account";
                MessageBox.Show("Account Saved Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btnnext_Click(object sender, EventArgs e)
        {
            if(ctrlCustomerCardWithFilter1.CustomerID != -1)
            {
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Please select a customer first!");
            }
        }
    }
}
