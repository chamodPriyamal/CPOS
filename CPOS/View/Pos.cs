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
    public partial class Pos : Form
    {
        private Sale sale;
        private SaleDetail saleDetail;
        private Customer customer;
        private List<SaleDetail> SaleDetails;
        private Employee Rep;
        private CPOSContext context = DatabaseController.GetConnection();


        public Pos()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarcodeData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (saleDetail != null)
                {
                    saleDetail = new SaleDetail();
                }
                if (txtBarcodeData.Text != "")
                {
                   
                    Product p = context.Products.FirstOrDefault(x => x.BarcodeData == txtBarcodeData.Text);

                    if (p != null)
                    {
                        lblProductName.Text = p.Name;
                        saleDetail.Product = p;
                        saleDetail.ProductBatch = p.Batches.FirstOrDefault();
                        txtQty.Focus();
                    }
                }
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char) Keys.Enter)
                {
                    if (txtName.Text == "" || txtName.Text == "0" || txtName.Text.Contains(" "))
                    {
                        txtName.Text = "0000000000";
                    }

                    if ((customer = context.Customers.FirstOrDefault(x=>x.Mobile == txtName.Text)) != null)
                    {
                        lblName.Text = customer.Name;
                        txtBarcodeData.Focus();
                    }
                }
            }
                    
            catch (Exception exception)
            {
               MessageHelper.AlertError(exception.Message);
            }
        }

        private void reset()
        {
            customer = new Customer();
            saleDetail = new SaleDetail();
            SaleDetails = new List<SaleDetail>();
            Rep = new Employee();
            sale = new Sale();
            lblTotal.Text = "0000.00";
            lblGrandTotal.Text = "0000.00";
            lblBalance.Text = "0000.00";
            txtDiscount.Text = "0";
            txtPaid.Text = "0";
            DGV.Rows.Clear();
            lblTotal.Text = "Add to Cart";
            txtName.Focus();
        }

        private void Pos_Load(object sender, EventArgs e)
        {
            ThemeHelper.ChangeFormBackgroundColor(this);
            reset();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (txtQty.Text != "" && txtQty.Text != @"0" && decimal.Parse(txtQty.Text) <= saleDetail.ProductBatch.Stock)
                    {
                        saleDetail.Qty = decimal.Parse(txtQty.Text);
                        saleDetail.Total = saleDetail.ProductBatch.Cash * saleDetail.Qty;

                        DGV.Rows.Add(saleDetail.Product.Id, saleDetail.Product.Name, saleDetail.Product.BarcodeData, saleDetail.ProductBatch.Stock, CostCodeController.CostToCode(saleDetail.ProductBatch.Cost),
                            saleDetail.ProductBatch.Cash, saleDetail.Qty, saleDetail.Total);

                        SaleDetails.Add(saleDetail);

                    }
                    lblProductName.Text = "Scan!";
                    txtBarcodeData.Clear();
                    txtQty.Clear();
                    txtBarcodeData.Focus();
                }
                catch (Exception exception)
                {

                }
            }
        }

        private void DGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           calculate_stats();
        }

        private void DGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            calculate_stats();
            SaleDetails.RemoveAt(e.Row.Index);
        }

        private void calculate_stats()
        {
            try
            {
                decimal totalqty = 0;
                decimal total = 0;
                decimal discount = 0;
                decimal grandtotal = 0;
                decimal paid = 0;
                decimal balance = 0;

                foreach (DataGridViewRow row in DGV.Rows)
                {
                    totalqty += decimal.Parse(row.Cells[6].Value.ToString());
                    total += decimal.Parse(row.Cells[7].Value.ToString());
                }
                discount = decimal.Parse(txtDiscount.Text);
                grandtotal = total - discount;
                paid = decimal.Parse(txtPaid.Text);
                balance = paid - grandtotal;

                lblTotalQty.Text = totalqty.ToString();
                lblTotal.Text = total.ToString();
                lblGrandTotal.Text = grandtotal.ToString();
                lblBalance.Text = balance.ToString();

            }
            catch (Exception e)
            {

            }

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            calculate_stats();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            calculate_stats();
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are Sure Want to Continue!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                sale.Representive = context.Employees.FirstOrDefault();
                sale.Customer = customer;
                sale.Cashier = SessionController.emp;
                try
                {
                    sale.Total = decimal.Parse(lblTotal.Text);
                    sale.Discount = decimal.Parse(txtDiscount.Text);
                    sale.GrandTotal = decimal.Parse(lblGrandTotal.Text);
                    sale.Balance = decimal.Parse(lblBalance.Text);
                    sale.Paid = decimal.Parse(txtPaid.Text);
                }
                catch (Exception exception)
                {

                }

                //First Deduct the stock
                foreach (var sd in SaleDetails)
                {
                    var xib = context.ProductBatches.FirstOrDefault(x => x.Id == sd.ProductBatch.Id);
                    xib.Stock = xib.Stock - sd.Qty;
                    context.SaveChanges();
                }


                //Add Sale Entry
                sale.SaleDetails = SaleDetails;
                context.Sales.Add(sale);
                context.SaveChanges();
            }

            if (MessageBox.Show("Do you want to print the receipt ?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Reports.PosInvoice receipt = new Reports.PosInvoice();
                receipt.SetDatabaseLogon("cvpos", "CVPOS@1010809");
                receipt.RecordSelectionFormula = "{Sales.Id} = " + sale.Id;
                receipt.PrintToPrinter(1, false, 1, 1);
                ReportViewer viewer = new ReportViewer(receipt);
                viewer.TopMost = true;
                viewer.ShowDialog();
                this.Close();
                reset();
            }
            else
            {
                reset();
            }
        }
    }
}
