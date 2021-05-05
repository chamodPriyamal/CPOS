using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPOS.Helper;

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
                if (Controller.PermissionController.CheckPermission(Model.PermissionType.PRODUCT_CATEGORY_VIEW))
                {
                    new ProductCategory().Show();
                }
                else
                {
                    throw new Exception("Access Denied.! (PRODUCT_CATEGORY_VIEW)");
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

        private void ProductsMenu_Load(object sender, EventArgs e)
        {
            ThemeHelper.ChangeFormBackgroundColor(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Controller.PermissionController.CheckPermission(Model.PermissionType.PRODUCT_ADD))
            {
                new AddProduct().Show();
            }
            else
            {
                throw new Exception("Access Denied.! (PRODUCT_ADD)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Controller.PermissionController.CheckPermission(Model.PermissionType.PRODUCT_VIEW))
            {
                new ProductList().Show();
            }
            else
            {
                throw new Exception("Access Denied.! (PRODUCT_VIEW)");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new PrintLabel().Show();
        }
    }
}
