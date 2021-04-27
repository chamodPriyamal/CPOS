using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public enum PermissionType
    {
        LOGIN = 1,
        PRODUCT_CATEGORY_VIEW,
        PRODUCT_CATEGORY_ADD,
        PRODUCT_CATEGORY_EDIT,
        PRODUCT_CATEGORY_DELETE,
        CUSTOMER_VIEW,
        CUSTOMER_ADD,
        CUSTOMER_EDIT,
        CUSTOMER_DELETE,
    }
}
