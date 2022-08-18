using System;
using System.Collections.Generic;

#nullable disable

namespace MizzaPro.Models
{
    public partial class MizzaToppingsStyleSku
    {
        public string ToppingStyleId { get; set; }
        public string ToppingSkuid { get; set; }

        public virtual MizzaToppingStyle ToppingStyle { get; set; }
        public virtual MizzaToppingSkuprice MizzaToppingSkuprice { get; set; }
        public virtual MizzaToppingSkustock MizzaToppingSkustock { get; set; }
    }
}
