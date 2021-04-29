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
            bool IsGranted = false;

            var permission = SessionController.Permissions.FirstOrDefault(x => x.Code == (int) ptype);
            if (permission == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
