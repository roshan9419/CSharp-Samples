namespace RetailCRUD.Models
{
    public partial class ProductStock
    {
        public string ProductId { get; set; }
        public int StockCount { get; set; }

        public virtual Product Product { get; set; }
    }
}
