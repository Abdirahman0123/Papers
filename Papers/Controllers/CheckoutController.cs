using EO.WebBrowser.DOM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Papers.Controllers
{
    [Authorize(Roles= "Customer")]
    public class CheckoutController : Controller
    {
        public ProductDbContext _context;
        public CheckoutController(ProductDbContext context)
        {
            _context = context;

        }
        // displays the form
        public ViewResult Index()
        {
            return View(new Order());
        }
            
        // saves order details to the database
        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                _context.SaveChangesAsync();
                HttpContext.Session.Clear();
            }

           else
            {
                return View(order);
            }

            // redirect the user to Confirmation page
            return RedirectToAction("Index", "Confirmation");
        }  
    }
}
