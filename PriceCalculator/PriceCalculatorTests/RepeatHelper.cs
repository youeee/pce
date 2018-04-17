namespace PriceCalculatorTests
{
    using System.Collections.Generic;
    using System.Linq;

    public static class RepeatHelper
    {
        public static void AddRepeated<T>(this List<T> self, T item, int count)
        {
            var temp = Enumerable.Repeat(item, count);
            self.AddRange(temp);
        }
    }
}