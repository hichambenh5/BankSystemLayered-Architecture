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
    public partial class ctrlAccountCardWithFilter : UserControl
    {
        public event Action<int> OnAccountSelected;
        protected virtual void AccountSelected(int AccountID)
        {
            Action<int> handler = OnAccountSelected;
            if (handler != null)
            {
                handler(AccountID);
            }

        }
     public int _AccountID;
       private ClsAccount _Account;
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilters.Visible = _FilterEnabled;
            }
        }
        public ctrlAccountCardWithFilter()
        {
            InitializeComponent();
            
        }
        public void ResetAccountInfo()
        {
           _AccountID = -1;
            lblAccountID.Text= "[????]";
            lblPersonID.Text= "[????]";
            lblAccountNumber.Text= "[????]";
            lblAccountType.Text= "[????]";
            lblBalance.Text= "[????]";
            lblStatus.Text= "[????]";
            lblUser.Text= "[????]"; 
            lblDate.Text= "[????]";
        }
        private void _FillAccountInfo()
        {
            _AccountID = _Account.AccountID;
            lblAccountID.Text = _Account.AccountID.ToString();
            lblPersonID.Text = _Account.PersonID.ToString();
            ctrlCustomerCard1.LoadPersonInfo(int.Parse(lblPersonID.Text));
            lblAccountNumber.Text = _Account.AccountNumber;
            lblAccountType.Text = _Account.AccountTypeInfo.TypeName;
            lblBalance.Text = _Account.Balance.ToString();
            lblStatus.Text = _Account.Status;
            lblUser.Text = _Account.CreatedByUserID.ToString();
            lblDate.Text = _Account.CreationDate.ToString("dd/mm/yyyy");
        }
        public void LoadAccountInfo(int AccountID)
        {
            _Account = ClsAccount.Find(AccountID);
            if (_Account == null)
            {
                ResetAccountInfo();
                MessageBox.Show("No Account with AccountID = " + AccountID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillAccountInfo();
        }
        public void LoadAccountInfo(string AccountNumber)
        {
            _Account = ClsAccount.Find(AccountNumber);
            if (_Account == null)
            {
                ResetAccountInfo();
                MessageBox.Show("No Account with AccountNumber = " + AccountNumber.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillAccountInfo();
        }
        private void FindNow()
        {
          
            switch (cbFilterBy.Text)
            {
                case "AccountID":
                   this.LoadAccountInfo(int.Parse(txtFilterValue.Text));
                    break;
                case "AccountNumber":
                    this.LoadAccountInfo(txtFilterValue.Text);
                    break;
            }
            if (_Account != null)
                AccountSelected(_Account.AccountID);
        }
        private void CtrlAccountCardWithFilter_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
                return;
            FindNow();
        }
    }
}
