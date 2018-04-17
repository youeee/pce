namespace PriceCalculator
{
    using System.Collections.Generic;
    using System.Linq;

    public class Basket
    {
        private IEnumerable<Item> _items;
        private readonly IEnumerable<IDiscount> _discounts;
        public Basket(IEnumerable<Item> items, IEnumerable<IDiscount> discounts)
        {
            _items = items;
            _discounts = discounts;
        }

        public decimal Total()
        {
            var totalOfDiscountedItems = 0.0m;
            //TODO: Check for null reference for discounts
            foreach (var discount in _discounts)
            {
                    (IEnumerable<Item> items, decimal itemsValue) = discount.Apply(_items);
                    totalOfDiscountedItems += itemsValue;
                    _items = items;
            }
            return _items.Sum(i => i.Price) + totalOfDiscountedItems;
        }
    }

    //Possibly look at writting something functional to apply discounts
}
