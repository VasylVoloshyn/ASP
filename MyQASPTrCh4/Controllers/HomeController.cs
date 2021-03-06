﻿using MyQASPTrCh4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyQASPTrCh4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            return View("Index");
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

        public ViewResult UseExtensionEnumerable()
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

            Product[] productArray =
                {
                    new Product { Name = "Kayak", Price = 275M},
                    new Product { Name = "LifeJacket", Price = 48.95M},
                    new Product { Name = "Ball", Price = 19.50M},
                    new Product { Name = "Flag", Price= 34.95M}
                };
            decimal totalCart = cart.TotalPrice();
            decimal totalArray = productArray.TotalPrice();
            return View("Result", (object)String.Format("Total Cart: {0:c}, Total Array: {1:c}", totalCart, totalArray));
        }

        public ViewResult UseFilterExtension()
        {
            IEnumerable<Product> products = new ShoppingCart 
            {
                Products = new List<Product> { 
                    new Product { Name = "Kayak", Category ="WaterSports", Price = 275M},
                    new Product { Name = "LifeJacket", Category ="WaterSports",Price = 48.95M},
                    new Product { Name = "Ball", Category ="Football", Price = 19.50M},
                    new Product { Name = "Flag", Category ="Football", Price= 34.95M}
                }
            };
            decimal total = 0;
            foreach (Product prod in products.FilterByCategory("Football"))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total price: {0:c}", total));
        }

        public ViewResult UseDelegateFilter()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product { Name = "Kayak", Category ="WaterSports", Price = 275M},
                    new Product { Name = "LifeJacket", Category ="WaterSports",Price = 48.95M},
                    new Product { Name = "Ball", Category ="Football", Price = 19.50M},
                    new Product { Name = "Flag", Category ="Football", Price= 34.95M}
                }
            };
            Func<Product, bool> categoryFilter = delegate (Product prod)
             {
                 return prod.Category == "Football";
             };

            decimal total = 0;
            foreach (Product prod in products.Filter(categoryFilter))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total price: {0:c}", total));
        }

        public ViewResult UseLambdaFilter()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product { Name = "Kayak", Category ="WaterSports", Price = 275M},
                    new Product { Name = "LifeJacket", Category ="WaterSports",Price = 48.95M},
                    new Product { Name = "Ball", Category ="Football", Price = 19.50M},
                    new Product { Name = "Flag", Category ="Football", Price= 34.95M}
                }
            };
            Func<Product, bool> categoryFilter = prod => prod.Category == "Football";
            
            decimal total = 0;
            foreach (Product prod in products.Filter(categoryFilter))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total price: {0:c}", total));
        }

        public ViewResult UseLambdaFilter2()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product { Name = "Kayak", Category ="WaterSports", Price = 275M},
                    new Product { Name = "LifeJacket", Category ="WaterSports",Price = 48.95M},
                    new Product { Name = "Ball", Category ="Football", Price = 19.50M},
                    new Product { Name = "Flag", Category ="Football", Price= 34.95M}
                }
            };
            
            decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Football" && prod.Price > 20))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total price: {0:c}", total));
        }

        public ViewResult CreaneAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new {Name = "MVC", Category = "Pattern"},
                new {Name = "Hat", Category = "Clothing"},
                new {Name = "Apple", Category = "Fruit"}
            };
            StringBuilder result = new StringBuilder();
            foreach ( var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }
            return View("Result", (object)result.ToString());
        }
        /// <summary>
        /// LinQ test
        /// </summary>
        /// <returns></returns>
        public ViewResult FindProduct()
        {
            Product[] products = {
                    new Product { Name = "Kayak", Category ="WaterSports", Price = 275M},
                    new Product { Name = "LifeJacket", Category ="WaterSports",Price = 48.95M},
                    new Product { Name = "Ball", Category ="Football", Price = 19.50M},
                    new Product { Name = "Flag", Category ="Football", Price= 34.95M}
                    };
       
            var foundProducts = from match in products
                                orderby match.Price descending
                                select new { match.Name, match.Price };

            int count = 0;
            StringBuilder result = new StringBuilder();
            foreach(var p in foundProducts)
            {
                result.AppendFormat("Price: {0} ", p.Price);
                if (++count ==3)
                {
                    break;
                }
            }
            return View("Result", (object)result.ToString());
        }

        /// <summary>
        /// LinQ test
        /// </summary>
        /// <returns></returns>
        public ViewResult FindProduct2()
        {
            Product[] products = {
                    new Product { Name = "Kayak", Category ="WaterSports", Price = 275M},
                    new Product { Name = "LifeJacket", Category ="WaterSports",Price = 48.95M},
                    new Product { Name = "Ball", Category ="Football", Price = 19.50M},
                    new Product { Name = "Flag", Category ="Football", Price= 34.95M}
                    };

            var foundProducts = products.OrderByDescending(e => e.Price)
                                        .Take(3)
                                        .Select(e => new { e.Name, e.Price });
            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price: {0} ", p.Price);                
            }
            return View("Result", (object)result.ToString());
        }

        /// <summary>
        /// LinQ test
        /// </summary>
        /// <returns></returns>
        public ViewResult FindProduct3()
        {
            Product[] products = {
                    new Product { Name = "Kayak", Category ="WaterSports", Price = 275M},
                    new Product { Name = "LifeJacket", Category ="WaterSports",Price = 48.95M},
                    new Product { Name = "Ball", Category ="Football", Price = 19.50M},
                    new Product { Name = "Flag", Category ="Football", Price= 34.95M}
                    };

            var foundProducts = products.OrderByDescending(e => e.Price)
                                        .Take(3)
                                        .Select(e => new { e.Name, e.Price });

            products[2] = new Product { Name = "Stadion", Price = 79600M };
            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price: {0} ", p.Price);
            }
            return View("Result", (object)result.ToString());
        }

        /// <summary>
        /// LinQ test
        /// </summary>
        /// <returns></returns>
        public ViewResult FindProduct4()
        {
            Product[] products = {
                    new Product { Name = "Kayak", Category ="WaterSports", Price = 275M},
                    new Product { Name = "LifeJacket", Category ="WaterSports",Price = 48.95M},
                    new Product { Name = "Ball", Category ="Football", Price = 19.50M},
                    new Product { Name = "Flag", Category ="Football", Price= 34.95M}
                    };

            var results = products.Sum(e => e.Price);

            products[2] = new Product { Name = "Stadion", Price = 79600M };
            
            return View("Result", (object)String.Format("Sum = {0:c} ", results));
        }


    }
}