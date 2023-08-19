using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papers.Extensions;
using Papers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Papers.Controllers
{
    // This class handles user interact with the shopping cart
    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;

        public CartController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        // display the cart
        public IActionResult Index()
        {
            // get item list in the cart from the session
            // if it is not null, calculate the total and assign it to total
            var cart = HttpContext.Session.Get<List<Item>>("cart");
            if (cart != null)
            {
                ViewBag.total = cart.Sum(s => s.Quantity * s.Product.Price);
            }
            else
            {
                cart = new List<Item>();
                ViewBag.total = 0;
            }

            return View(cart);
        }

        // Buys the product by adding to the cart
        public IActionResult Buy(int Id)
        {
            // get the product selected based on its Id
            var product = productRepository.GetProduct(Id);
            // get list of items in the session using cart key
            var cart = HttpContext.Session.Get<List<Item>>("cart");

            // if the cart is empty, add the product to the cart
            // and set the quantity to 1

            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item { Product = product, Quantity = 1 });
            }

            else
            {
                
                int index = cart.FindIndex(w => w.Product.Id == Id);
                // if the product already in the cart, increase the quantity
                // else add the product to cart and set the q
                if (index != -1) 
                {
                    cart[index].Quantity++;
                }

                else
                {
                    cart.Add(new Item { Product = product, Quantity = 1 });

                }
            }

            // Store the new item list in the cart to the session using "cart" key
            HttpContext.Session.Set<List<Item>>("cart", cart);
            // The user is redirected to Index action method in this controller
            return RedirectToAction("Index");
        }



        // increment the item quantity in the cart
        public IActionResult Increase(int Id)
        {
            // get the product using Id
            var product = productRepository.GetProduct(Id);

            // get list of items in the cart from the session
            var cart = HttpContext.Session.Get<List<Item>>("cart");

            // find the index of the product since items in the cart are stored in a list
            int index = cart.FindIndex(p => p.Product.Id == Id);

            // increment the product
            cart[index].Quantity++;

            // Store the new item list in the cart to the session
            // using "cart" key and
            HttpContext.Session.Set<List<Item>>("cart", cart);

            return RedirectToAction("Index");
        }

        // decrease the quantity of the item in the cart
        public IActionResult Decrease(int Id)
        {   // the product that you want to decrease its quantity
            var product = productRepository.GetProduct(Id);

            // get the product list from cart in the session
            var cart = HttpContext.Session.Get<List<Item>>("cart");

            int index = cart.FindIndex(p => p.Product.Id == Id);
            //int index = cart.FindIndex(p => p.Product.Id == Id);

            // if it is the last item of the product, remove from the cart
            // else decrease the quantity by 1
            if (cart[index].Quantity == 1) {

                cart.RemoveAt(index);
            }

            else
            {
                cart[index].Quantity--;
            }

            // Store the new item list in the cart to the session
            // using "cart" key and
            HttpContext.Session.Set<List<Item>>("cart", cart);

            // The user is redirected to Index action method in this controller
            return RedirectToAction("Index");
        }

        // remove the whole product Item from the cart
        public IActionResult Remove(int Id)
        {
            var product = productRepository.GetProduct(Id);

            // get the product list from cart in the session
            var cart = HttpContext.Session.Get<List<Item>>("cart");

            int index = cart.FindIndex(p => p.Product.Id == Id);
            //int index = cart.FindIndex(p => p.Product.Id == Id);

            // remove the whole product item from cart
            cart.RemoveAt(index);

            // set the new item list in the cart to the session
            // using "cart" key and cart object after serialising it
            HttpContext.Session.Set<List<Item>>("cart", cart);

            // redirect to the Index
            return RedirectToAction("Index");
        }

        // remove all items from the cart
        // Clear the cart when you submit the form
        // call session.Get and clear it but dont delete this
        public IActionResult ClearCart()
        {
            //var cart = HttpContext.Session.Get<List<Item>>("cart");

            //cart.Clear();

            //HttpContext.Session.Set<List<Item>>("cart", cart);
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult GO()
        {

            return RedirectToAction("Product");

        }
    }
}

