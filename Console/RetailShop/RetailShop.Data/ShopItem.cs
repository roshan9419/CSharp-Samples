using System;
using Utils.Generators;

namespace RetailShop.Data
{
    public class ShopItem : IShopItem
    {
        public ShopItem(string name, DateTime expiryDate)
        {
            Id = new IDGenerator().NextID();
            Name = name;
            ExpiryDate = expiryDate;
        }

        public string Id { get; set; } // batch number
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
