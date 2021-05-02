using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public class Sale
    {
        [Key] public int Id { get; set; }
        [Required] public DateTime InvoiceDate { get; set; } = DateTime.Now;
        [Required] public decimal Total { get; set; }
        [Required] public decimal Discount { get; set; }
        [Required] public decimal GrandTotal { get; set; }
        [Required] public decimal Paid { get; set; }
        [Required] public decimal Balance { get; set; }
        [Required] public virtual Employee Cashier { get; set; }
        [Required] public virtual Employee Representive { get; set; }
        [Required] public virtual Customer Customer { get; set; }
        [Required] public virtual ICollection<SaleDetail> SaleDetails { get; set; }

    }
}
