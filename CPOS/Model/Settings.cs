using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public class Settings
    {
        [Key] public int Id { get; set; }
        [Required] public string BusinessName { get; set; }
        [Required] public string BusinessAddress { get; set; }
        [Required] public string BusinessContact { get; set; }
        [Required] public string CostCode { get; set; }
        //[Required] public string ODBC_Dsn { get; set; }
        //[Required] public string ODBC_Host { get; set; }
        //[Required] public string ODBC_Username { get; set; }
        //[Required] public string Password { get; set; }
    }
}
