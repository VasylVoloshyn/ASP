using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyQASPTrCh4.Models
{
    public static class ProductExtensionMethods
    {
        public static decimal TotalPrice(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach(Product prod in productEnum)
            {
                total += prod.Price;
            }
            return total;
        }

        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum,string categoryParam)
        {
            foreach(Product product in productEnum)
            {
                if(product.Category == categoryParam)
                {
                    yield return product;
                }
            }
        }
    }
}