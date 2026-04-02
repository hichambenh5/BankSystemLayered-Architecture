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
    public partial class frmAddEditCustomer : Form
    {
        public delegate void DataBackEventHandler(object sender, int CustomerID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode;
        private int _CustomerID = -1;
        ClsCustomer _Customer;
        public frmAddEditCustomer()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmAddEditCustomer(int CustomerID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _CustomerID = CustomerID;
        }
        private void _ResetDefualtValues()
        {
            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Customer";
                _Customer = new ClsCustomer();
            }
            else
            {
                lblTitle.Text = "Update Customer";
            }
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtNationalID.Text = "";
        }
        private void _LoadData()
        {
            _Customer = ClsCustomer.Find(_CustomerID);
            if (_Customer == null)
            {
                MessageBox.Show("No customer with ID = " + _Customer, "customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblCustomerID.Text = _CustomerID.ToString();
            txtFirstName.Text = _Customer.FirstName;
            txtLastName.Text = _Customer.LastName;
            txtEmail.Text = _Customer.Email;
            txtPhone.Text = _Customer.Phone;
            txtNationalID.Text = _Customer.NationalID;
        }
        private void FrmAddEditCustomer_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
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
            _Customer.FirstName = txtFirstName.Text;
            _Customer.LastName = txtLastName.Text;
            _Customer.Email = txtEmail.Text;
            _Customer.Phone = txtPhone.Text;
            _Customer.NationalID = txtNationalID.Text;
            if (_Customer.Save())
            {
                lblCustomerID.Text = _Customer.PersonID.ToString();
                Mode = enMode.Update;
                lblTitle.Text = "Update Customer";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this, _Customer.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
            {
                return;
            }
            if (!ClsValiditing.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
            ;
        }

        private void TxtNationalID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalID, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalID, null);
            }

            //Make sure the national number is not used by another person
            if (txtNationalID.Text.Trim() != _Customer.NationalID && ClsCustomer.IsCustomerExist(txtNationalID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalID, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalID, null);
            }
        }
    }
}
