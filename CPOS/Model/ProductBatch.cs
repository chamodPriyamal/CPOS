﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOS.Model
{
    public class ProductBatch
    {
        [Key] public int Id { get; set; }
        [Required] public decimal Cost { get; set; }
        [Required] public decimal Cash { get; set; }
        [Required] public decimal Credit { get; set; }
        [Required] public decimal Markup { get; set; }
        [Required] public decimal Stock { get; set; }
        [Required] public Product Product { get; set; } 
    }
}
