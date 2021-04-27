using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Controller
{
    public static class PermissionController
    {

        public static bool CheckPermission(Model.PermissionType ptype)
        {
            foreach (var permission in SessionController.usr.Permissions)
            {
                if (permission.Code == (int)ptype)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
