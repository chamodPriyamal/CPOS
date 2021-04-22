using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Exceptions
{
    class UserNotActiveException : Exception
    {
        public UserNotActiveException() : base("The Username Not Active!")
        {

        }
    }
}
