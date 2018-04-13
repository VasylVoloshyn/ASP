using MyQASPTrCh6EssentialTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyQASPTrCh6EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private Product[] products = {
                    new Product { Name = "Kayak", Category ="WaterSports", Price = 275M},
                    new Product { Name = "LifeJacket", Category ="WaterSports",Price = 48.95M},
                    new Product { Name = "Ball", Category ="Football", Price = 19.50M},
                    new Product { Name = "Flag", Category ="Football", Price= 34.95M}
        };
        // GET: Home
        public ActionResult Index()
        {
            LinqValueCalculator calculator = new LinqValueCalculator();
            ShoppingCart cart = new ShoppingCart(calculator) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
    
}