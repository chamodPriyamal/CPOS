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
    public partial class ProductsMenu : Form
    {
        public ProductsMenu()
        {
            InitializeComponent();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            try
            {
                if (Controller.PermissionController.check_product_category_view())
                {
                    new ProductCategory().Show();
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
    }
}
