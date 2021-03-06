﻿using System;
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
        [TestMethod]
        public void DiscountBetween10And100()
        {
            IDiscountHelper target = getTestObject();
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HundredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftDollarDiscount = target.ApplyDiscount(50);

            Assert.AreEqual(5, TenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 discount is wrong");
            Assert.AreEqual(45, FiftDollarDiscount, "$50 discount is wrong");
        }

        [TestMethod]
        public void DiscountLessThan10 ()
        {
            IDiscountHelper target = getTestObject();

            decimal discount5 = target.ApplyDiscount(5);
            decimal discount0 = target.ApplyDiscount(0);

            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DiscountNegativeTotal()
        {
            IDiscountHelper target = getTestObject();
            target.ApplyDiscount(-1);
        }
    }

}
