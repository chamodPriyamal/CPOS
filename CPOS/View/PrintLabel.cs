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
using CPOS.Model;

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
            BarcodeController.print_barcode(int.Parse(txtId.Text),int.Parse(txtQty.Text));
            BarcodeController.print_barcode_preview(int.Parse(txtId.Text));
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char) Keys.Enter)
            {
                int id = int.Parse(txtId.Text);
                Product p = DatabaseController.GetConnection().Products.FirstOrDefault(x => x.Id == id);
                if (p != null)
                {
                    txtName.Text = p.Name;
                    txtQty.Focus();
                }
                else
                {
                    txtName.Clear();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                btnNew.PerformClick();
            }
        }

        private void PrintLabel_Load(object sender, EventArgs e)
        {

        }
    }
}
