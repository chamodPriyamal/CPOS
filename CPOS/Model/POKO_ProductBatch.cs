using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public class POKO_ProductBatch
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public decimal Cash { get; set; }
        public decimal Credit { get; set; }
        public decimal Markup { get; set; }
        public decimal Stock { get; set; }
        public Product Product { get; set; }
        public string CostCode { get; set; }
    }
}
