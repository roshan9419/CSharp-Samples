using System;
using System.Collections.Generic;

#nullable disable

namespace MizzaPro.Models
{
    public partial class MizzaSku
    {
        public string MizzaSkuid { get; set; }
        public string MizzaSkuname { get; set; }
        public string MizzaStyleId { get; set; }
        public string MizzaSizeId { get; set; }

        public virtual MizzaSize MizzaSize { get; set; }
        public virtual MizzaStyle MizzaStyle { get; set; }
        public virtual MizzaSkuBasePrice MizzaSkuBasePrice { get; set; }
        public virtual MizzaSkustock MizzaSkustock { get; set; }
    }
}
