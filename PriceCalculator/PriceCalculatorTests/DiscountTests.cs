namespace PriceCalculatorTests
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using PriceCalculator;
    using PriceCalculator.Discounts;

    [TestFixture]
    public class DiscountTests
    {
        [Test]
        public void TwoButterAndBreadDiscountShouldDiscount50PercentOffBread()
        {
            var twoButter50PercentBreadDiscount = new TwoButter50PercentBreadDiscount();
            var items = new List<Item>()
            {
                new Item("butter", 0.8m),
                new Item("butter", 0.8m),
                new Item("bread", 1.0m),
                new Item("code complete", 1.0m)
            };
            (IEnumerable<Item> remainingItems, decimal discountedAmount) = twoButter50PercentBreadDiscount.Apply(items);

            Assert.AreEqual(2.1m, discountedAmount);
            Assert.AreEqual(1, remainingItems.Count());
            Assert.AreEqual("code complete", remainingItems.First().Name);
        }

        [Test]
        public void FourMilksDiscountShouldDiscount100PercentOffFourthMilk()
        {
            var fourMilkFourthFreeDiscount = new FourMilkFourthFreeDiscount();

            var items = new List<Item>()
            {
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m)
            };

            (IEnumerable<Item> remainingItems, decimal discountedAmount) = fourMilkFourthFreeDiscount.Apply(items);

            Assert.AreEqual(3.45m, discountedAmount);
            Assert.AreEqual(1, remainingItems.Count());
            Assert.AreEqual("milk", remainingItems.First().Name);
        }

        [Test]
        public void TwoButterAndBreadDiscountShouldReturnAllItemsIfSetNotComplete()
        {
            var twoButter50PercentBreadDiscount = new TwoButter50PercentBreadDiscount();
            var items = new List<Item>()
            {
                new Item("butter", 1.05m),
                new Item("bread", 1.20m),
                new Item("bread", 1.20m)
            };
            (IEnumerable<Item> remainingItems, decimal discountedAmount) = twoButter50PercentBreadDiscount.Apply(items);

            Assert.AreEqual(0.0m, discountedAmount);
            Assert.AreEqual(3, items.Count);
        }
    }
}