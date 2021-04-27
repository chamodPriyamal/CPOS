using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Controller
{
    public static class LogController
    {
        public static void writeLog(string data)
        {
            using(var context = DatabaseController.GetConnection())
            {
                Model.Log l = new Model.Log();
                l.Data = data;
                l.LoggedDate = DateTime.Now;
                context.Logs.Add(l);
                context.SaveChanges();
            }
        }
    }
}
