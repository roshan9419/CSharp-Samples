using System;
using System.Collections.Generic;

namespace RetailCRUD.Models
{
    public partial class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public string SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public float SaleAmount { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
