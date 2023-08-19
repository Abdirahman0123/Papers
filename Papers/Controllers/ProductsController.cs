using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Papers.Models;

namespace Papers.Controllers
{
     [Authorize (Roles = "Admin")]
    public class ProductsController : Controller
    {
        // a variable of type ProductDbContext is declared to access the database
        // The variable is initialised using dependency injection
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: Products
        //  all the products all retrieved and conver them to a list
        public async Task<IActionResult> Index()
        {
            var productDbContext = _context.Product.Include(p => p.Supplier);
            return View(await productDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        // Display details of the selected product
        public async Task<IActionResult> Details(int? id)
        {
            // if the id is null, return notFound() meaning 404 error
            if (id == null)
            {
                return NotFound();
            }

            // the product that match the Id is retrieved from the database and 
            // and displayed it using view template
            var product = await _context.Product
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        // This the foreign key creation for the supplier
        public IActionResult Create()
        {
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "Email");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        // creates a new product which takes user arguments as parameters
        public async Task<IActionResult> Create([Bind("Id,Name,Category,Price,SupplierId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "Email", product.SupplierId);
            return View(product);
        }

        // GET: Products/Edit/5
        // get the producs
        // It takes product Id as parameter and searches for the product using findAsync method and 
        // then returns it to the view
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "Email", product.SupplierId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        // edit the product details with the new details entered by the user and then save it in the database
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Name,Category,Price,SupplierId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            // ModelState.IsValid varifies input data can bounded to the model (product)
            // and input values also pass validation checks
            // if ModelState.IsValid evaluates to true, the product is updated with the new data 
            // update method and the change are saved to the database using SaveChangesAsync method
            // 

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // if the product does not exit an error is returned
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "Email", product.SupplierId);
            return View(product);
        }

        // GET: Products/Delete/5
        // the product is retrieved  from the database for deletion.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // the product is retrieved based it id.
            var product = await _context.Product
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        // This method deletes a product using its id
        public async Task<IActionResult> DeleteConfirmed(int id)
        {   
            var product = await _context.Product.FindAsync(id); // find the product
            _context.Product.Remove(product); // delete it
            await _context.SaveChangesAsync(); // save the changes
            return RedirectToAction(nameof(Index)); // direct user back to the index page
        }

        // checks if product exists using its id
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}