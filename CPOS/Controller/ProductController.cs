using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPOS.Helper;
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

        public void Register(Product product, ProductBatch batch)
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.PRODUCT_ADD))
                {
                    if (product.BarcodeData == "")
                    {
                        context.Products.Add(product);
                        context.SaveChanges();
                        product.BarcodeData = product.Id.ToString();
                        product.BarcodeImage = BarcodeController.GetBarcodeBytes(product.BarcodeData.ToString());
                        context.SaveChanges();
                        batch.Product = product;
                        context.ProductBatches.Add(batch);
                        context.SaveChanges();
                        MessageHelper.AlertRegisterSuccess();
                    }
                    else
                    {
                        context.Products.Add(product);
                        context.SaveChanges();
                        batch.Product = product;
                        context.ProductBatches.Add(batch);
                        context.SaveChanges();
                        MessageHelper.AlertRegisterSuccess();
                    }
                }
            }
            catch (Exception e)
            {
                Helper.MessageHelper.AlertError(e.Message);
            }
        }
    }
}
