using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Papers.Models
{
    // Interface that retrieves all products and individual product
    // any class that wants implement these two must implement this
    // interface
    public interface IProductRepository
    {
        // get a product using its Id
        Product GetProduct(int id);
       
        // get all the products
        IEnumerable<Product> GetProducts();
    }
}
