using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyQASPTrCh6EssentialTools.Models;

namespace EssentialToolsUnittest
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }
        [TestMethod]
        public void DiscountAbove100()
        {
            IDiscountHelper target = getTestObject();
            decimal total = 200;
            var discountedTotal = target.ApplyDiscount(total);

            Assert.AreEqual(total * 0.9M, discountedTotal);
        }
    }
}
