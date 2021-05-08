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

namespace CPOS.Reports
{
    public partial class ReportDashboard : Form
    {
        public ReportDashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportDashboard_Load(object sender, EventArgs e)
        {
            ThemeHelper.ChangeFormBackgroundColor(this);
        }
    }
}
