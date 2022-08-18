using System;
using System.Collections.Generic;

#nullable disable

namespace MizzaPro.Models
{
    public partial class MizzaToppingSkuprice
    {
        public string ToppingStyleId { get; set; }
        public string Skuid { get; set; }
        public int Price { get; set; }

        public virtual MizzaToppingsStyleSku MizzaToppingsStyleSku { get; set; }
    }
}
