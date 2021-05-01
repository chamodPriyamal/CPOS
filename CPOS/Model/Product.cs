using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public class Product
    {
        [Key] public int Id { get; set; }
        [Required] public string  Name { get; set; }
        [Required] public string Description { get; set; } = "-";
        [Required] public virtual Category Category { get; set; }
        [Required] public decimal ReOrderLevel { get; set; } = 0; 
        public byte [] BarcodeImage { get; set; } 
        public string BarcodeData { get; set; }
        public virtual ICollection<ProductBatch> Batches { get; set; }
    }
}
