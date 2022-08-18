using System;

namespace RetailCRUD.Models
{
    public partial class SaleDetail
    {
        public string SaleId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
}
