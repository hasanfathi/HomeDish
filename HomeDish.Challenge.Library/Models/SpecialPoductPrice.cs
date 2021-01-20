using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeDish.Challenge.Library.Models
{
    public class SpecialPoductPrice
    {
        public List<ProductPrice> prices { get; set; }
        public double specialTotal { get; set; }
        public double total
        {
            get
            {
                return prices.Sum(item => item.price) + specialTotal;
            }
        }
    }
}
