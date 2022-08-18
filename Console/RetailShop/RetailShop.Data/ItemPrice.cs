
namespace RetailShop.Data
{
    public class ItemPrice
    {
        public ItemPrice(string id, float price, float? discount)
        {
            Id = id;
            Price = price;
            Discount = discount;
        }

        public string Id { get; set; }
        public float Price { get; set; }
        public float? Discount { get; set; } // rate
    }
}
