using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPOS.Model;
using NetBarcode;
using Type = NetBarcode.Type;

namespace CPOS.Controller
{
    public class ProductController
    {
        private CPOSContext context;

        public ProductController()
        {
            context = new CPOSContext();
        }
        
        public void Register(Product p , ProductBatch pb)
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.PRODUCT_ADD))
                {
                    if (Helper.MessageHelper.AlertRegisterConfirmation() == DialogResult.Yes)
                    {
                        pb.Product = p;
                        if (p.BarcodeData == "")
                        {
                            p.BarcodeData = "0";
                            p.BarcodeImage = BarcodeController.GetBarcodeBytes("0");
                            context.ProductBatches.Add(pb);
                            context.SaveChanges();
                            p.BarcodeData = p.Id.ToString();
                            p.BarcodeImage = BarcodeController.GetBarcodeBytes(p.Id.ToString());
                            context.SaveChanges();
                            Helper.MessageHelper.AlertRegisterSuccess();
                        }
                        else
                        {
                            p.BarcodeImage = BarcodeController.GetBarcodeBytes(p.BarcodeData);
                            context.ProductBatches.Add(pb);
                            context.SaveChanges();
                            Helper.MessageHelper.AlertRegisterSuccess();
                        }
                    }
                }
                else
                {
                    throw new Exception("Access Denied! (PRODUCT_ADD)");
                }
            }
            catch (Exception e)
            {
               Helper.MessageHelper.AlertError(e.Message);
            }   
        }
    }
}
