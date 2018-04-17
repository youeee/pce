namespace PriceCalculator.Discounts
{
    using System.Collections.Generic;
    using System.Linq;

    public class FourMilkFourthFreeDiscount : IDiscount
    {
        private const string ItemMilk = "milk";
        public (IEnumerable<Item>, decimal) Apply(IEnumerable<Item> items)
        {
            var total = 0.0m;
            var milkCount = items.Count(i => i.Name == ItemMilk);

            for (var i = 0; i < milkCount/4; i++ )
            {
                var discountedItems = 0.0m;
                (items, discountedItems) = ApplyDiscount(items);
                total += discountedItems;
            }

            return (items, total);
        }

        private (IEnumerable<Item>, decimal) ApplyDiscount(IEnumerable<Item> items)
        {
            var milks = items.Where(i => i.Name == ItemMilk).Take(4);
            var remainingItems = items.Except(milks);
            var discountSum = milks.Take(3).Sum(b => b.Price);

            return (remainingItems, discountSum);
        }
    }
}