using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyQASPTrCh6EssentialTools.Models;


namespace EssentialToolsUnittest
{
    [TestClass]
    public class UnitTest2
    {
        private Product[] products = {
                    new Product { Name = "Kayak", Category ="WaterSports", Price = 275M},
                    new Product { Name = "LifeJacket", Category ="WaterSports",Price = 48.95M},
                    new Product { Name = "Ball", Category ="Football", Price = 19.50M},
                    new Product { Name = "Flag", Category ="Football", Price= 34.95M}
                    };
        [TestMethod]
        public void SumProductsCorrectly()
        {
            var discounter = new MinimumDiscountHelper();
            var target = new LinqValueCalculator(discounter);
            var goalTotal = products.Sum(e => e.Price);

            var result = target.ValueProducts(products);
            Assert.AreEqual(goalTotal, result);
        }
    }
}
