namespace PriceCalculatorTests
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using PriceCalculator;
    using PriceCalculator.Discounts;

    [TestFixture]
    public class BasketTotalShould
    {
        [Test]
        public void Total_2_95_WhenBasketContainsMilkBreadButter()
        {
            var items = new List<Item>()
            {
                new Item("bread", 1.0m),
                new Item("milk", 1.15m),
                new Item("butter", .80m),
            };

            var basket = new Basket(items, ApplicableDiscounts());
            var total = basket.Total();
            Assert.AreEqual(2.95m, total);
        }
        [Test]
        public void Total_3_45_WhenBasketContainsFourMilks()
        {
            var items = new List<Item>
            {
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m)
            };

            var basket = new Basket(items, ApplicableDiscounts());
            var total = basket.Total();
            Assert.AreEqual(3.45m, total);
        }

        [Test]
        public void Total_9_00_WhenBasketContainsLotsOfThings()
        {
            var items = new List<Item>
            {
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("milk", 1.15m),
                new Item("butter", 0.8m),
                new Item("butter", 0.8m),
                new Item("bread", 1.0m)
            };

            var basket = new Basket(items, ApplicableDiscounts());
            var total = basket.Total();
            Assert.AreEqual(9.0m, total);
        }

        private IEnumerable<IDiscount> ApplicableDiscounts()
        {
            return new List<IDiscount>()
            {
                new FourMilkFourthFreeDiscount(),
                new TwoButter50PercentBreadDiscount()
            };
        }
    }
}
