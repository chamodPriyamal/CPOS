using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPOS.Controller;
using CPOS.Helper;
using CPOS.Model;

namespace CPOS.View
{
    public partial class EditBatch : Form
    {
        private int batchid;
        private ProductBatch batch;
        private ProductController controller;

        public EditBatch(int batchId)
        {
            InitializeComponent();
            controller = new ProductController();
            this.batchid = batchId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditBatch_Load(object sender, EventArgs e)
        {
            ThemeHelper.ChangeFormBackgroundColor(this);
            batch = controller.GetBatchById(batchid);
            txtCost.Text = CostCodeController.CostToCode(batch.Cost);
            txtCash.Text = batch.Cash.ToString();
            txtCredit.Text = batch.Credit.ToString();
            txtMarkup.Text = batch.Markup.ToString();
            txtStock.Text = batch.Stock.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            batch.Cost = CostCodeController.CodeToCost(txtCost.Text);
            batch.Cash = decimal.Parse(txtCash.Text);
            batch.Credit = decimal.Parse(txtCredit.Text);
            batch.Markup = decimal.Parse(txtMarkup.Text);
            batch.Stock = decimal.Parse(txtStock.Text);
            controller.UpdateProduct();
            this.Close();
        }
    }
}
