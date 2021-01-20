using System;
using System.Collections.Generic;

namespace HomeDish.Challenge.Library.Models
{
    public class AggregateProduct
    {
        public List<Product> products { get; set; }
        public List<Special> specials { get; set; }
    }
}
