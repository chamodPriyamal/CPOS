using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public class SaleDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int Id { get; set; }
        [Required] public Product Product { get; set; }
        [Required] public ProductBatch ProductBatch { get; set; }
        [Required] public decimal Qty { get; set; }
        [Required] public decimal Total { get; set; }
        
    }
}
