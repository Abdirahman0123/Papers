﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Papers.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }      

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
         public int SupplierId  { get; set; }

        public Supplier Supplier{ get; set; }
        
    }
}
