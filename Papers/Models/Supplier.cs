using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Papers.Models
{
    public class Supplier
    {
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        // This a navigation property to establish relationship between
        // supplier table and Product table
        public ICollection<Product> Products { get; set; }
    }
}
