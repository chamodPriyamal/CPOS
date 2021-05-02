﻿using System;
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
using CPOS.Migrations;
using CPOS.Model;

namespace CPOS.View
{
    public partial class AddProduct : Form
    {
        private CategoryController categoryController;
        private CPOSContext context;
        public AddProduct()
        {
            InitializeComponent();
            categoryController = new CategoryController();
            context = DatabaseController.GetConnection();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.PRODUCT_ADD))
                {
                    if (MessageHelper.AlertRegisterConfirmation() == DialogResult.Yes)
                    {
                        Product product = new Product();
                        product.Name = txtName.Text;
                        product.Description = txtDescription.Text;
                        product.Category = (Category)cmbCategory.SelectedItem;
                        product.BarcodeData = txtBarcode.Text;
                        product.ReOrderLevel = decimal.Parse(txtReOrder.Text);


                        ProductBatch batch = new ProductBatch();
                        batch.Cost = CostCodeController.CodeToCost(txtCost.Text);
                        batch.Cash = decimal.Parse(txtCash.Text);
                        batch.Credit = decimal.Parse(txtCredit.Text);
                        batch.Markup = decimal.Parse(txtMarkup.Text);
                        batch.Stock = decimal.Parse(txtStock.Text);

                        if (product.BarcodeData == "")
                        {
                            context.Products.Add(product);
                            context.SaveChanges();
                            product.BarcodeData = product.Id.ToString();
                            product.BarcodeImage = BarcodeController.GetBarcodeBytes(product.BarcodeData.ToString());
                            context.SaveChanges();
                            batch.Product = product;
                            context.ProductBatches.Add(batch);
                            context.SaveChanges();
                            MessageHelper.AlertRegisterSuccess();
                        }
                        else
                        {
                            context.Products.Add(product);
                            context.SaveChanges();
                            batch.Product = product;
                            context.ProductBatches.Add(batch);
                            context.SaveChanges();
                            MessageHelper.AlertRegisterSuccess();
                        }
                    }
                }
                else
                {
                    throw new Exception("Access Denied! (PRODUCT_ADD)");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.AlertError(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = categoryController.GetCategoryListForComboBox();
            cmbCategory.ValueMember = "Id";
            cmbCategory.DisplayMember = "Name";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProductCategory().Show();
        }
    }
}