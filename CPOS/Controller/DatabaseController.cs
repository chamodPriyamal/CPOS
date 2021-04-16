// Author  : Chamod Priyamal Kumarasiri
// Email   : chammaofficial@gmail.com
// Company : www.techwiz.lk
// Date    : 2021-04-15
// Comment : This Controller make the database connection is a single context. for the entire application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Controller
{
    public static class DatabaseController
    {
        private static CPOSContext context;

        public static CPOSContext GetConnection()
        {
            if(context == null)
            {
                context = new CPOSContext();
            }
            return context;
        }


    }
}
