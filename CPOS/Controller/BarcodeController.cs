using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
