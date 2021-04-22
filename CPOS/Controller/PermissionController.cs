using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Controller
{
    public static class PermissionController
    {
        public static bool CheckPermission_Login()
        {
            foreach (var permission in SessionController.usr.Permissions)
            {
                if((permission.Name == "LOGIN") || (permission.Code == 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
