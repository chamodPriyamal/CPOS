// Author  : Chamod Priyamal Kumarasiri
// Email   : chammaofficial@gmail.com
// Company : www.techwiz.lk
// Date    : 2021-04-15
// Comment : This Controller Provides the Funcationality to Employee Model 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPOS.Model;

namespace CPOS.Controller
{
    public class EmployeeController
    {
        private CPOSContext context;

        public EmployeeController()
        {
           context = DatabaseController.GetConnection();
        }

        public void Register(Employee emp )
        {
            try
            {
                if (emp.Name == "")
                {
                    throw new Exception("Employee Name Cant be Empty");
                }
                else
                {
                    if (emp.Mobile == "") { emp.Mobile = "-";}
                    if (emp.Address == "") { emp.Address = "-"; }
                    if(Helper.MessageHelper.AlertRegisterConfirmation() == DialogResult.Yes)
                    {
                        context.Employees.Add(emp);
                        context.SaveChanges();
                    }
                    else
                    {
                        Helper.MessageHelper.AlertInfo("No Changes were made.");
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageHelper.AlertError(ex.Message);
            }
        }
        public void Remove(Employee emp)
        {
            try
            {
                if (emp.Id >= 0)
                {
                    throw new Exception("Invalid Employee Id!");
                }
                else
                {
                    if (Helper.MessageHelper.AlertRemoveConfirmation() == DialogResult.Yes)
                    {
                        context.Employees.Remove(emp);
                        context.SaveChanges();
                    }
                    else
                    {
                        Helper.MessageHelper.AlertInfo("No Changes were made.");
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageHelper.AlertError(ex.Message);
            }
        }

    }
}
