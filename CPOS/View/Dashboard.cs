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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            new ProductsMenu().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CustomerMenu().Show();
        }
    }
}
