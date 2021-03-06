using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPOS.Reports;
using CPOS.View;
using BarcodeLib;

namespace CPOS.Controller
{
    public static class BarcodeController
    {

        public static byte[] GetBarcodeBytes(string data)
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            b.Encode(TYPE.CODE128, data);
            return b.GetImageData(SaveTypes.PNG);
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
            TwoByOneBarcode rpt = new TwoByOneBarcode();
            rpt.SetDatabaseLogon("cvpos", "CVPOS@1010809");
            rpt.RecordSelectionFormula = "{Products.Id} = " + id;
            rpt.PrintToPrinter(LabelCount / 2,false,1,1);
        }

        public static void print_barcode_preview(int id)
        {
            TwoByOneBarcode rpt = new TwoByOneBarcode();
            rpt.SetDatabaseLogon("cvpos","CVPOS@1010809");
            rpt.RecordSelectionFormula = "{Products.Id} = " + id;
            ReportViewer view = new ReportViewer(rpt);
            view.TopMost = true;
            view.Show();
        }
    }
}
