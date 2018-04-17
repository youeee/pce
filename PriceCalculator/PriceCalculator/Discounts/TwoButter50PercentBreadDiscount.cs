namespace PriceCalculator.Discounts
{
    using System.Collections.Generic;
    using System.Linq;

    public class TwoButter50PercentBreadDiscount : IDiscount
    {
        private const string ItemButter = "butter";
        private const string ItemBread = "bread";
        private const decimal BreadDiscount = 0.5m;
        public (IEnumerable<Item>, decimal) Apply(IEnumerable<Item> items)
        {
            if (items.Count(i => i.Name == ItemButter) < 2 || !items.Any(i => i.Name == ItemBread))
                return (items, 0.0m);

            var butters = items.Where(i => i.Name == ItemButter).Take(2);
            var breads = items.Where(i => i.Name == ItemBread).Take(1);

            var remainingItems = items.Except(butters).Except(breads);
            var discountSum = butters.Sum(b => b.Price) + breads.Sum(b => b.Price) * BreadDiscount;

            return (remainingItems, discountSum);
        }
    }
}