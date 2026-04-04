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
    public partial class CtrlCustomerCardWithFilter : UserControl
    {
        public event Action<int> OnCustomerSelected;
        protected virtual void CustomerSelected(int CustomerID)
        {
            Action<int> handler = OnCustomerSelected;
            if (handler != null)
            {
                handler(CustomerID);
            }

        }
        private bool _ShowAddCustomer = true;
        public bool ShowAddCustomer
        {
            get
            {
                return _ShowAddCustomer;
            }
            set
            {
                _ShowAddCustomer = value;
                btnAddNewCustomer.Visible = _ShowAddCustomer;
            }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Visible = _FilterEnabled;
            }
        }
        public CtrlCustomerCardWithFilter()
        {
            InitializeComponent();
        }
       
        public int CustomerID
        {
            get
            {
                return ctrlCustomerCard1.CustomerID;

            }
        }
        public ClsCustomer SelectedCustomerInfo
        {
            get
            {
                return ctrlCustomerCard1.SelectedCustomerInfo;
            }
        }
        public void LoadPersonInfo(int CustomerID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = CustomerID.ToString();
            FindNow();
        }
        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlCustomerCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    break;
                case "National ID.":
                    ctrlCustomerCard1.LoadPersonInfo(txtFilterValue.Text);
                    break;
                default:
                    break;
            }
            if (OnCustomerSelected != null && FilterEnabled)
            {
                OnCustomerSelected(ctrlCustomerCard1.CustomerID);
            }
        }
        private void GbFilters_Enter(object sender, EventArgs e)
        {

        }

        private void CtrlCustomerCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FindNow();
        }

        private void BtnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer frm = new frmAddEditCustomer();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }
        private void DataBackEvent(object sender, int Customerid)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = CustomerID.ToString();
            ctrlCustomerCard1.LoadPersonInfo(Customerid);
        }
    }
}
