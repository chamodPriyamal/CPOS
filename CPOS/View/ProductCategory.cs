using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace CPOS.View
{
    public partial class ProductCategory : Form
    {
        private CPOSContext context;
        private Controller.CategoryController controller;

        public ProductCategory()
        {
            InitializeComponent();
            context = new CPOSContext();
            controller = new Controller.CategoryController(context);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductCategory_Load(object sender, EventArgs e)
        {
            DGV.AutoGenerateColumns = false;
            DGV.DataSource = controller.GetCategoryListForDataGrid();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (Controller.PermissionController.check_product_category_add())
                {
                    controller.RegisterCategory(new Model.Category { Name = txtNew.Text });
                    txtNew.Clear();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Controller.PermissionController.check_product_category_edit())
                {
                    int id = int.Parse(DGV.SelectedRows[0].Cells[0].Value.ToString());
                    var cat = context.Categories.FirstOrDefault(x => x.Id == id);
                    cat.Name = txtEdit.Text;
                    controller.UpdateCategory(cat);
                    txtEdit.Clear();
                    txtDelete.Clear();
                    DGV.Refresh();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Controller.PermissionController.check_product_category_delete())
                {
                    int id = int.Parse(DGV.SelectedRows[0].Cells[0].Value.ToString());
                    var cat = context.Categories.FirstOrDefault(x => x.Id == id);
                    controller.RemoveCategory(cat);
                    txtDelete.Clear();
                    txtEdit.Clear();
                    DGV.Refresh();
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

        private void DGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string name = DGV.SelectedRows[0].Cells[1].Value.ToString();
            txtEdit.Text = name;
            txtDelete.Text = name;
        }
    }
}
