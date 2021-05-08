using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPOS.Helper;
using CPOS.Model;

namespace CPOS.Controller
{
    public class ProductController
    {
        private CPOSContext context;
        private CategoryController categoryController;

        public ProductController()
        {
            context = new CPOSContext();
            context.ProductBatches.Load();
            context.Products.Load();
        }

        public BindingList<Product> GetProductBindingList()
        {
            context.Products.Load();
            return context.Products.Local.ToBindingList();
        }

        public BindingList<ProductBatch> GetProductBatcheBindingList()
        {
            context.Products.Load();
            return context.ProductBatches.Local.ToBindingList();
        }

        public Product GetProduct(int id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product GetProductByBarcode(string data)
        {
            return context.Products.FirstOrDefault(x => x.BarcodeData == data);
        }

        public void DeleteProduct(int id)
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.PRODUCT_DELETE))
                {
                    var p = context.Products.FirstOrDefault(x => x.Id == id);
                    if (MessageHelper.AlertRemoveConfirmation() == DialogResult.Yes)
                    {
                        context.Products.Remove(p);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Access Denied.! (PRODUCT_DELETE)");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteProductBatch(int id)
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.PRODUCT_DELETE))
                {
                    var pb = context.ProductBatches.FirstOrDefault(x => x.Id == id);
                    if (MessageHelper.AlertRemoveConfirmation() == DialogResult.Yes)
                    {
                        context.ProductBatches.Remove(pb);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Access Denied.! (PRODUCT_DELETE)");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ProductBatch GetBatchById(int id)
        {
            return context.ProductBatches.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateProduct()
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.PRODUCT_EDIT))
                {
                    if (MessageHelper.AlertUpdateConfirmation() == DialogResult.Yes)
                    {
                        context.SaveChanges();
                        MessageHelper.AlertUpdateSuccess();
                    }
                }
                else
                {
                    throw new Exception("Access Denied! (PRODUCT_EDIT)");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
