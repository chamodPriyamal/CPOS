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
    public partial class AddCustomer : Form
    {
        private CPOSContext context;
        public AddCustomer()
        {
            InitializeComponent();
            context = Controller.DatabaseController.GetConnection();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
