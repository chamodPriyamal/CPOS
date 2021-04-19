using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Controller
{
    public static class SessionController
    {
        private static Model.Employee emp;
        private static Model.User usr;
        private static Model.Permission[] Permissions;

        public static void StartSession(Model.Employee emp , Model.User usr)
        {
            SessionController.emp = emp;
            SessionController.usr = usr;
        }

        public static void EndSession()
        {
            SessionController.emp = null;
            SessionController.usr = null;
        }
    }
}
