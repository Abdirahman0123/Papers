using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Papers.Models;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Papers.Controllers
{
    // This class displays product list to the user and allows them to search for a product
    public class ProductController : Controller
    {
        // a variable of type ProductDbContext to access products in the database.
        public readonly ProductDbContext context;

        // context variable initiliased 
        public ProductController(ProductDbContext _context)
        {
            context = _context;
        }
        // Display all the products on the web browser
         [HttpGet]
        public async Task<IActionResult> Index(string searchProduct)
        {
            // retrieves products from DbContext and assign it to products variable
            var products = from Product in context.Product select Product;

            // Checks if searchProduct is not null or empty.
            if (!String.IsNullOrEmpty(searchProduct))
            {
                // filters the products and retrieves the product that match the searchProduct
                products = products.Where(s => s.Name!.Contains(searchProduct));
            }
            // products are converted to list and then passed to the view
            return View(await products.ToListAsync());
        }

    }
}
