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
            return true;
        }
        public static bool check_product_category_view()
        {
            foreach (var permission in SessionController.usr.Permissions)
            {
                if ((permission.Name == "PRODUCT_CATEGORY_VIEW") || (permission.Code == 2))
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
        public static bool check_product_category_add()
        {
            foreach (var permission in SessionController.usr.Permissions)
            {
                if ((permission.Name == "PRODUCT_CATEGORY_ADD") || (permission.Code == 3))
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
        public static bool check_product_category_edit()
        {
            foreach (var permission in SessionController.usr.Permissions)
            {
                if ((permission.Name == "PRODUCT_CATEGORY_EDIT") || (permission.Code == 4))
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
        public static bool check_product_category_delete()
        {
            foreach (var permission in SessionController.usr.Permissions)
            {
                if ((permission.Name == "PRODUCT_CATEGORY_DELETE") || (permission.Code == 5))
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
