using System;
using System.Collections.Generic;

#nullable disable

namespace MizzaToppingsCore.DataModel.Models
{
    public partial class MizzaToppingSkustock
    {
        public string ToppingStyleId { get; set; }
        public string Skuid { get; set; }
        public int StockCount { get; set; }

        public virtual MizzaToppingsStyleSku MizzaToppingsStyleSku { get; set; }
    }
}
