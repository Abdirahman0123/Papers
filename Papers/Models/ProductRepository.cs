using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Papers.Models;

namespace Papers.Models
{
    // Retrieves and stores product objects by implementing ProductDbContext class
    public class ProductRepository : IProductRepository
    {
        // a variable of type ProductDbContext is declared
        // and initialised in the constructort so that
        // it can be used to access the database
        private readonly ProductDbContext context;
       public ProductRepository (ProductDbContext _context)
        {
            context = _context;
        }

        // get a product by its id
        public Product GetProduct(int id)
        {
            // return the product that matches the id
            return GetProducts().First(c => c.Id == id);
        }

        // Return all products in the database
        public IEnumerable<Product> GetProducts()
        {
            return context.Product;
        }
    }
}
