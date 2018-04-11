using MyQASPTrCh4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyQASPTrCh4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to URL to show Example";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "Kayak";
            string productName = myProduct.Name;

            return View("Result", (object)String.Format("Product Name: {0}", productName));
        }

        public ViewResult CreateProduct()
        {
            Product myMproduct = new Product { ProductID = 100, Name = "Kayak",
                Description = "A boat for one Person",
                Price = 275M, Category = "Watersports" };
            return View("Result", (object)String.Format("Category: {0}", myMproduct.Category));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int>
            { { "apple", 10}, {"orange", 20}, {"plum", 30} };
            return View("Result", (object)stringArray[1]);
        }

        public ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product { Name = "Kayak", Price = 275M},
                    new Product { Name = "LifeJacket", Price = 48.95M},
                    new Product { Name = "Ball", Price = 19.50M},
                    new Product { Name = "Flag", Price= 34.95M}
                }
            };
            decimal totalCart = cart.TotalPrice();
            return View("Result", (object)String.Format("Total: {0:c}", totalCart));
        }

    }
}