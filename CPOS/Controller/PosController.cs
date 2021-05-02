using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using CPOS.Model;

namespace CPOS.Controller
{
    public class PosController
    {
        private CPOSContext context = new CPOSContext();
        private CustomerController customerController;
        private EmployeeController employeeController;

        public PosController()
        {
            customerController = new CustomerController();
            employeeController = new EmployeeController();
        }

        public void update_stock()
        {
            context.SaveChanges();
        }
            public void AddSale(Sale sale)
        {
            context.Sales.Add(sale);
            context.SaveChanges();
        }
        
    }
}
