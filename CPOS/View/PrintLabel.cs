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

namespace CPOS.View
{
    public partial class PrintLabel : Form
    {
        public PrintLabel()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            BarcodeController.print_barcode_preview(int.Parse(txtId.Text));
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char) Keys.Enter)
            {
                int id = int.Parse(txtId.Text);
                txtName.Text = DatabaseController.GetConnection().Products.FirstOrDefault(x => x.Id == id).Name.ToString();
            }
        }
    }
}
