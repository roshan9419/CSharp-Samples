using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Data
{
    public interface IShopItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
