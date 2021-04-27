using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public class Log
    {
        [Key] public int Id { get; set; }
        [Required] public string  Data { get; set; }
        [Required] public DateTime LoggedDate { get; set; } = DateTime.Now;
        
    }
}
