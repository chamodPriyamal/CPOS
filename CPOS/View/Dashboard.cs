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
using CPOS.Reports;

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
            ThemeHelper.ChangeFormBackgroundColor(this);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            new ProductsMenu().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CustomerMenu().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Pos().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new ReportDashboard().Show();
        }
    }
}
