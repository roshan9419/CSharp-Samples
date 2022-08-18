
namespace RetailShop.Data
{
    public class ItemStock
    {
        public ItemStock(string id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public string Id { get; set; }
        public int Quantity { get; set; } // stores the current qty available
    }
}
