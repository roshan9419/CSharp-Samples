using System;
using System.Collections.Generic;

#nullable disable

namespace MizzaPro.Models
{
    public partial class MizzaSkuBasePrice
    {
        public string Skuid { get; set; }
        public int Price { get; set; }

        public virtual MizzaSku Sku { get; set; }
    }
}
