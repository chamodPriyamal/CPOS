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
    public partial class ProductList : Form
    {
        private ProductController controller;
        public ProductList()
        {
            InitializeComponent();
            controller = new ProductController();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            DGV.AutoGenerateColumns = false;
            DGV2.AutoGenerateColumns = false;
            DGV.DataSource = controller.GetProductBindingList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            if (PermissionController.CheckPermission(PermissionType.PRODUCT_ADD))
            {
                new AddProduct().Show();
            }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            load_batches();   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(DGV.SelectedRows[0].Cells[0].Value.ToString());
            controller.DeleteProduct(id);
            DGV2.Refresh();
        }

        private void btnDeleteBatch_Click(object sender, EventArgs e)
        {
            int id = int.Parse(DGV2.SelectedRows[0].Cells[0].Value.ToString());
            controller.DeleteProductBatch(id);
            DGV2.Refresh();
        }

        private void editBatch_Click(object sender, EventArgs e)
        {
            new EditBatch(int.Parse(DGV2.SelectedRows[0].Cells[0].Value.ToString())).Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            load_batches();
        }

        private void load_batches()
        {
            int id = int.Parse(DGV.SelectedRows[0].Cells[0].Value.ToString());
            var p = controller.GetProduct(id);
            List<POKO_ProductBatch> batchList = new List<POKO_ProductBatch>();

                foreach (var batch in p.Batches)
                {
                    POKO_ProductBatch pokobatch = new POKO_ProductBatch();
                    pokobatch.Id = batch.Id;
                    pokobatch.Cash = batch.Cash;
                    pokobatch.Credit = batch.Credit;
                    pokobatch.Markup = batch.Markup;
                    pokobatch.Cost = batch.Cost;
                    pokobatch.Stock = batch.Stock;
                    pokobatch.CostCode = CostCodeController.CostToCode(batch.Cost);
                    batchList.Add(pokobatch);
                }
            DGV2.DataSource = batchList;
        }
    }
}
