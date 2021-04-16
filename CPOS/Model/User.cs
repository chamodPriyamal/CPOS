// Author  : Chamod Priyamal Kumarasiri
// Email   : chammaofficial@gmail.com
// Company : www.techwiz.lk
// Date    : 2021-04-15
// Comment : Model for Employees

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public class User
    {
        [Key] public int Id { get; set; }

        [Required][StringLength(10)][Index(IsUnique = true)] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public bool IsActive { get; set; } = true;
        [Required] public bool CanDelete { get; set; } = true;
        [Required] public DateTime LastLogin { get; set; } = DateTime.Now;
        [Required] public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required] public DateTime LastUpdate { get; set; } = DateTime.Now;
        [Required] public virtual Employee Employee { get; set; }
    }
}
