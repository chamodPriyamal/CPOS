using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace CPOS.Controller
{
    public class PosController
    {
        private CustomerController customerController;
        private EmployeeController employeeController;

        public PosController()
        {
            customerController = new CustomerController();
            employeeController = new EmployeeController();

        }
    }
}
