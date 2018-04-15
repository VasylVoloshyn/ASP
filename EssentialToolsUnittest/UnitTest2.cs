using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyQASPTrCh6EssentialTools.Models;
using Moq;


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
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                            .Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mock.Object);            
            var result = target.ValueProducts(products);
            Assert.AreEqual(products.Sum(e=>e.Price), result);
        }
    }
}
