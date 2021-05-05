using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPOS.Controller;
using CPOS.Helper;
using CPOS.Model;

namespace CPOS.View
{
    public partial class AddCustomer : Form
    {
        private CustomerController controller;
        public AddCustomer()
        {
            InitializeComponent();
            controller = new CustomerController();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            ThemeHelper.ChangeFormBackgroundColor(this);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var cust = new Customer();
            cust.Name = txtName.Text;
            cust.Address = txtAddress.Text;
            cust.Nic = cust.Nic;
            cust.CanDelete = false;
            cust.IsActive = true;
            cust.DueAmount = decimal.Parse(txtDueAmount.Text);
            cust.LoyalPoints = decimal.Parse(txtLoyalPoints.Text);
            cust.Mobile = txtMobile.Text;
            cust.LandLine = txtLandLine.Text;
            controller.RegisterCustomer(cust);
            Helper.ClearForm.ClearAllTextFields(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
