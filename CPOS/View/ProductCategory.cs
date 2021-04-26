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
    public partial class ProductCategory : Form
    {
        Controller.CategoryController controller = new Controller.CategoryController();

        public ProductCategory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductCategory_Load(object sender, EventArgs e)
        {

        }
    }
}
