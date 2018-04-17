namespace PriceCalculator
{
    public class Item
    {
        public readonly string Name;
        public readonly decimal Price;

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}