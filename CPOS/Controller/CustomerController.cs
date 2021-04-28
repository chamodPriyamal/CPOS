using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using CPOS.Model;

namespace CPOS.Controller
{
    public class CustomerController
    {
        private CPOSContext context;

        public CustomerController()
        {
            context = new CPOSContext();
            context.Customers.Load();
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.CUSTOMER_VIEW))
                {
                    var cust = context.Customers.FirstOrDefault(x => x.Id == id);
                    if (cust == null)
                    {
                        throw new Exception("Customer Not Found!");
                    }
                    else
                    {
                        return cust;
                    }
                }
                else
                {
                    throw new Exception("Access Denied!");
                }
            }
            catch (Exception e)
            {
                Helper.MessageHelper.AlertError(e.Message);
                return null;
            }
        }
    }
}
