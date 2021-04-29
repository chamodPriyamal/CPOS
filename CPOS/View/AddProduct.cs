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
using CPOS.Migrations;
using CPOS.Model;

namespace CPOS.View
{
    public partial class AddProduct : Form
    {
        private ProductController productController;
        private CategoryController categoryController;

        public AddProduct()
        {
            InitializeComponent();
            productController = new ProductController();
            categoryController = new CategoryController();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.Category = cmbCategory.SelectedItem as Category;
            if (txtReOrder.Text.Length > 0)
            {
                product.ReOrderLevel = decimal.Parse(txtReOrder.Text);
            }
            else
            {
                product.ReOrderLevel = 3;
            }

            if (txtBarcode.Text.Length > 0)
            {
                product.BarcodeData = txtBarcode.Text;
            }
            else
            {
                product.BarcodeData = "";
            }

            //

            ProductBatch batch = new ProductBatch();
            batch.Cost = CostCodeController.CodeToCost(txtCost.Text);
            batch.Cash = decimal.Parse(txtCash.Text);
            batch.Markup = decimal.Parse(txtMarkup.Text);
            batch.Credit = decimal.Parse(txtCredit.Text);
            batch.Stock = decimal.Parse(txtStock.Text);

            //

            productController.Register(product,batch);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = categoryController.GetCategoryListForDataGrid();
            cmbCategory.ValueMember = "Id";
            cmbCategory.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProductCategory().Show();
        }
    }
}
