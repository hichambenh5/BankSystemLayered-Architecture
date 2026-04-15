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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            if (ClsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
           
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ClsUser user = ClsUser.Find(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (user != null)
            {
                if (chkRememberMe.Checked)
                {
                    ClsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    ClsGlobal.RememberUsernameAndPassword("", "");
                }
                ClsGlobal.CurrentUser = user;
                this.Hide();
                FrmMain frm = new FrmMain(this);
                frm.ShowDialog();
            }
            
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
