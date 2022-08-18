using System.Collections.Generic;

namespace RetailCRUD.Models
{
    public partial class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
