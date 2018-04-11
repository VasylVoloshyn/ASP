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
    }
}