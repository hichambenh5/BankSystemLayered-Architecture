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
    public partial class FrmListCustomer : Form
    {
        private static DataTable _dtAllCustomer = ClsCustomer.GetAllCustomer();
        public FrmListCustomer()
        {
            InitializeComponent();
        }

        private void FrmListCustomer_Load(object sender, EventArgs e)
        {
            dgvAllCustomer.DataSource = _dtAllCustomer;
            lblRecordsCount.Text = dgvAllCustomer.Rows.Count.ToString();
        }
        private void _RefreshPeoplList()
        {
            _dtAllCustomer = ClsCustomer.GetAllCustomer();
            dgvAllCustomer.DataSource = _dtAllCustomer;
            lblRecordsCount.Text = dgvAllCustomer.Rows.Count.ToString();
        }

        private void Txtfilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbfilterby.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";

                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "NationalID":
                    FilterColumn = "NationalID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtfilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllCustomer.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvAllCustomer.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "PersonID")
            {
                _dtAllCustomer.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtfilter.Text.Trim());

            }
            else
                _dtAllCustomer.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtfilter.Text.Trim());
        }

        private void Cbfilterby_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfilter.Visible = (cbfilterby.Text != "None");
            if (txtfilter.Visible)
            {
                txtfilter.Text = "";
                txtfilter.Focus();
            }
        }

        private void AddCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmAddEditCustomer();
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditCustomer((int)dgvAllCustomer.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Customer [" + dgvAllCustomer.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (ClsCustomer.DeleteCustomers((int)dgvAllCustomer.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("customer Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }

                else
                    MessageBox.Show("customer was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void ShowCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFindCustomer frm = new FrmFindCustomer();
            frm.ShowDialog();
        }
    }
}
