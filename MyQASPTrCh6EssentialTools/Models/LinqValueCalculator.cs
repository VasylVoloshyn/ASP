using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyQASPTrCh6EssentialTools.Models
{
    public class LinqValueCalculator
    {
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return products.Sum(p => p.Price);
        }
    }
}