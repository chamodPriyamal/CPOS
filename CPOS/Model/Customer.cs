using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public class Customer
    {
        [Key] public int Id { get; set; }
        
        [Required] public string Name { get; set; }
        
        public string Address { get; set; }

        public string Nic { get; set; }

        public string LandLine { get; set; } = "-";

        public string Mobile { get; set; }

        public decimal DueAmount { get; set; } = 0;

        public decimal LoyalPoints { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public bool CanDelete { get; set; } = true;
    }
}
