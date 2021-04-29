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
using CPOS.Model;

namespace CPOS.View
{
    public partial class EditCustomer : Form
    {
        private int CustId;
        private CustomerController controller;
        private Customer cust;

        public EditCustomer(int id)
        {
            this.CustId = id;
            this.controller = new CustomerController();
            
            InitializeComponent();
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.CUSTOMER_EDIT))
                {
                    cust = controller.GetCustomer(CustId);
                    txtName.Text = cust.Name;
                    txtAddress.Text = cust.Address;
                    txtNic.Text = cust.Nic;
                    txtLandLine.Text = cust.LandLine;
                    txtMobile.Text = cust.Mobile;
                    txtDueAmount.Text = cust.DueAmount.ToString();
                    txtLoyalPoints.Text = cust.LoyalPoints.ToString();
                }
                else
                {
                    throw new Exception("Access Denied.!");
                }
            }
            catch (Exception exception)
            {
                Helper.MessageHelper.AlertError(exception.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cust.Name = txtName.Text;
            cust.Address = txtAddress.Text;
            cust.Nic = cust.Nic;
            cust.CanDelete = false;
            cust.IsActive = true;
            cust.DueAmount = decimal.Parse(txtDueAmount.Text);
            cust.LoyalPoints = decimal.Parse(txtLoyalPoints.Text);
            cust.Mobile = txtMobile.Text;
            cust.LandLine = txtLandLine.Text;
            controller.EditCustomer();
            this.Close();
        }
    }
}
