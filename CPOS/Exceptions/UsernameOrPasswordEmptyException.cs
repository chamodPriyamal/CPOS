using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Exceptions
{
    public class UsernameOrPasswordEmptyException : Exception
    {
        public UsernameOrPasswordEmptyException() : base("The Username or Password is empty.")
        {

        }
    }
}
