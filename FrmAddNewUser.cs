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
    public partial class FrmAddNewUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID = -1;
        ClsUser _User;
        private int _SelectedRoleID = -1;
        public FrmAddNewUser(int ID,bool IsUpdateMode = true)
        {
            InitializeComponent();

            if (IsUpdateMode)
            {
                _Mode = enMode.Update;
                _UserID = ID; 
            }
            else
            {
                _Mode = enMode.AddNew;
                _SelectedRoleID = ID; 
            }
        }
       
        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new ClsUser();
            }
            else
            {

                lblTitle.Text = "update user";
                this.Text = "update user";
                
            }
            btnSave.Enabled = true;
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
        private void _LoadData()
        {
            _User = ClsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
        }
        private void FrmAddNewUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (_User == null)
            {
                MessageBox.Show("Unexpected error: User object is null.");
                return;
            }
            _User.UserName = txtUserName.Text.Trim();
            _User.SetPassword(txtPassword.Text);
            if (_Mode == enMode.AddNew)
            {
                _User.RoleID = _SelectedRoleID;
            }
            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
            ;
        }

        private void TxtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
            ;

        }

        private void TxtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
            ;


            if (_Mode == enMode.AddNew)
            {

                if (ClsUser.IsUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
                ;
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (ClsUser.IsUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }
                    ;
                }
            }
            }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
