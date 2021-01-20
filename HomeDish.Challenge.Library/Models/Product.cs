using System;

namespace HomeDish.Challenge.Library.Models
{
    public class Product
    {
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public double total => price * quantity;
    }
}
