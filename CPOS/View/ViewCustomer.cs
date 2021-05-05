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
    public partial class ViewCustomer : Form
    {
        private CustomerController controller;
        public ViewCustomer()
        {
            InitializeComponent();
            controller = new CustomerController();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (PermissionController.CheckPermission(PermissionType.CUSTOMER_ADD))
            {
                new AddCustomer().Show();
            }
            else
            {
                Helper.MessageHelper.AlertError("Access Denied!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            ThemeHelper.ChangeFormBackgroundColor(this);
            DGV.AutoGenerateColumns = false;
            DGV.DataSource = controller.GetCustomerListForDataGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new EditCustomer(int.Parse(DGV.SelectedRows[0].Cells[0].Value.ToString())).Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            controller.DeleteCustomer(int.Parse(DGV.SelectedRows[0].Cells[0].Value.ToString()));
        }
    }
}
