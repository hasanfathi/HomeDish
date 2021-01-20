using System;
using HomeDish.Challenge.Library.Interfaces;
using HomeDish.Challenge.Library.Models;
using System.Linq;
using System.Collections.Generic;

namespace HomeDish.Challenge.Services
{
    public class BasketService : IService
    {
        // Implementation of IService interface
        public double CalculateLowestTotal(AggregateProduct basket)
        {
            List<SpecialPoductPrice> allPrices = new List<SpecialPoductPrice>();
            List<ProductPrice> prices = null;

            // apply all offers and get the best match
            basket.specials.ForEach(special =>
            {
                prices = new List<ProductPrice>();

                // get not matched products with the actual total
                prices.AddRange(
                basket.products.Where(bp => !special.products.Any(item => item.name == bp.name))
                               .ToList()
                               .Select(item => new ProductPrice
                               {
                                   productName = item.name,
                                   price = item.total
                               }));

                // fetch matched products to apply current offer
                var matchedProducts = basket.products.Where(bp => special.products.Any(item => item.name == bp.name)).ToList();
                int matchTime = 0;
                while (matchedProducts.All(item => item.quantity >= special.products.Where(sp => item.name == sp.name).First().quantity))
                {
                    // in this section apply offer multiple times it can be possible
                    matchedProducts =
                    matchedProducts.Join(special.products,
                                    mp => mp.name,
                                    sp => sp.name,
                   (mp, sp) => new Product
                   {
                       name = mp.name,
                       price = mp.price,
                       quantity = mp.quantity - sp.quantity
                   }).ToList();
                    matchTime++;
                }

                // after applying the offer and get the actual quantity to calculate the actual total
                prices.AddRange(matchedProducts
                               .Select(item => new ProductPrice
                               {
                                   productName = item.name,
                                   price = item.total
                               }));

                // finally, calculate the sum of the actual total with offer apply result
                allPrices.Add(new SpecialPoductPrice { prices = prices, specialTotal = special.total * matchTime });
            });

            // return best match with the lowest total
            return allPrices.Min(item => item.total);
        }
    }
}
