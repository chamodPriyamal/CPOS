// Author  : Chamod Priyamal Kumarasiri
// Email   : chammaofficial@gmail.com
// Company : www.techwiz.lk
// Date    : 2021-04-15
// Comment : Model for Employees

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public class Employee
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Address { get; set; }
        [Required] public string Mobile { get; set; }
        [Required] public decimal CommisionRate { get; set; } = 0;
        [Required] public decimal OTRate { get; set; } = 0;
        [Required] public bool IsActive { get; set; } = true;
        [Required] public bool CanDelete { get; set; } = true;
        [Required] public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required] public DateTime LastUpdate { get; set; } = DateTime.Now;

        public void Register()
        {

        }
    }
}
