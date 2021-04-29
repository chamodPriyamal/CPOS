using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPOS.Model;

namespace CPOS.Controller
{
    public class CustomerController
    {
        private CPOSContext context;

        public CustomerController()
        {
            context = DatabaseController.GetConnection();
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

        public void RegisterCustomer(Customer c)
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.CUSTOMER_ADD))
                {
                    if (Helper.MessageHelper.AlertRegisterConfirmation() == DialogResult.Yes)
                    {
                        context.Customers.Add(c);
                        if (context.SaveChanges() == 1)
                        {
                            Helper.MessageHelper.AlertRegisterSuccess();
                        }
                        else
                        {
                            throw new Exception("Unknown Error Occured!");
                        }
                    }
                }
                else
                {
                    throw new Exception("Access Denied.!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void EditCustomer()
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.CUSTOMER_EDIT))
                {
                    if (Helper.MessageHelper.AlertUpdateConfirmation() == DialogResult.Yes)
                    {
                        if (context.SaveChanges() == 1)
                        {
                            Helper.MessageHelper.AlertUpdateSuccess();
                        }
                        else
                        {
                            throw new Exception("Unknown Error Occured!");
                        }
                    }
                }
                else
                {
                    throw new Exception("Access Denied.!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void DeleteCustomer(int id)
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.CUSTOMER_DELETE))
                {
                    if (Helper.MessageHelper.AlertRemoveConfirmation() == DialogResult.Yes)
                    {
                        var c = context.Customers.FirstOrDefault(x => x.Id == id);
                        context.Customers.Remove(c);
                        if (context.SaveChanges() == 1)
                        {
                            Helper.MessageHelper.AlertRemoveSuccess();
                        }
                        else
                        {
                            throw new Exception("Unknown Error Occured!");
                        }
                    }
                }
                else
                {
                    throw new Exception("Access Denied.!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public BindingList<Customer> GetCustomerListForDataGrid()
        {
            try
            {
                if (PermissionController.CheckPermission(PermissionType.CUSTOMER_VIEW))
                {
                    return context.Customers.Local.ToBindingList();
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
