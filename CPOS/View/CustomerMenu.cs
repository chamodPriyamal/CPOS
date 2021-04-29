using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPOS.View
{
    public partial class CustomerMenu : Form
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }

        private void btnAddCust_Click(object sender, EventArgs e)
        {
            try
            {
                if (Controller.PermissionController.CheckPermission(Model.PermissionType.CUSTOMER_ADD))
                {
                    new AddCustomer().Show();
                }
                else
                {
                    throw new Exception("Access Denied.!");
                }
            }
            catch (Exception ex)
            {
                Helper.MessageHelper.AlertError(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustList_Click(object sender, EventArgs e)
        {
            try
            {
                if (Controller.PermissionController.CheckPermission(Model.PermissionType.CUSTOMER_VIEW))
                {
                    new ViewCustomer().Show();
                }
                else
                {
                    throw new Exception("Access Denied.!");
                }
            }
            catch (Exception ex)
            {
                Helper.MessageHelper.AlertError(ex.Message);
            }
        }
    }
}
