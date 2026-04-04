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
    public partial class CtrlCustomerCard : UserControl
    {
        private ClsCustomer _Customer;
        private int _CustomerID = -1;
        public int CustomerID
        {
            get { return _CustomerID; }
        }
        public ClsCustomer SelectedCustomerInfo
        {
            get
            {
                return _Customer;
            }
        }
        public CtrlCustomerCard()
        {
            InitializeComponent();
        }
        public void LoadPersonInfo(int CustomerID)
        {
            _Customer = ClsCustomer.Find(CustomerID);
            if (_Customer == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Customer with CustomerID = " + CustomerID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalID)
        {
            _Customer = ClsCustomer.Find(NationalID);
            if (_Customer == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Customer with NationalID = " + NationalID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        private void _FillPersonInfo()
        {
            _CustomerID = _Customer.PersonID;
            lblPersonID.Text = _Customer.PersonID.ToString();
            lblFullName.Text = _Customer.FullName;
            lblNationalNo.Text = _Customer.NationalID;
            lblEmail.Text = _Customer.Email;
            lblPhone.Text = _Customer.Phone;
        }
        public void ResetPersonInfo()
        {
            _CustomerID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";

            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";


        }
        private void CtrlCustomerCard_Load(object sender, EventArgs e)
        {

        }
    }
}
