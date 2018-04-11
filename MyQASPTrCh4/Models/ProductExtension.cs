using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyQASPTrCh4.Models
{
    public static class ProductExtensionMethods
    {
        public static decimal TotalPrice(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach(Product prod in cartParam.Products)
            {
                total += prod.Price;
            }
            return total;
        }
    }
}