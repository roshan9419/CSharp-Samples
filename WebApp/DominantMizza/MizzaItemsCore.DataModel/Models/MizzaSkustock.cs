using System;
using System.Collections.Generic;

#nullable disable

namespace MizzaItemsCore.DataModel.Models
{
    public partial class MizzaSkustock
    {
        public string Skuid { get; set; }
        public string StockCount { get; set; }

        public virtual MizzaSku Sku { get; set; }
    }
}
