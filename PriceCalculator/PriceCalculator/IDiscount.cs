namespace PriceCalculator
{
    using System.Collections.Generic;

    public interface IDiscount
    {
        (IEnumerable<Item>, decimal) Apply(IEnumerable<Item> items);
    }
}