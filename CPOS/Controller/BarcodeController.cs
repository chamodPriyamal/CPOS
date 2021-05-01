using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPOS.Reports;
using CPOS.View;
using NetBarcode;
using Type = NetBarcode.Type;

namespace CPOS.Controller
{
    public static class BarcodeController
    {
        private static Barcode barcode;

        public static byte[] GetBarcodeBytes(string data)
        {
            barcode = new Barcode(data, Type.Code128);
            return barcode.GetByteArray();
        }

        public static void print_barcode(int id, int count)
        {
            int LabelCount = 0;
            if (count % 2 == 1)
            {
                LabelCount = count + 1;
            }
            else
            {
                LabelCount = count;
            }
        }

        public static void print_barcode_preview(int id)
        {
            TwoByOneBarcode rpt = new TwoByOneBarcode();
            rpt.RecordSelectionFormula = "{Products.Id} = " + id;
            ReportViewer view = new ReportViewer(rpt);
            view.TopMost = true;
            view.Show();
        }
    }
}
