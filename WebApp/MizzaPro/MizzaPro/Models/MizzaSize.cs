using System;
using System.Collections.Generic;

#nullable disable

namespace MizzaPro.Models
{
    public partial class MizzaSize
    {
        public MizzaSize()
        {
            MizzaSkus = new HashSet<MizzaSku>();
        }

        public string MizzaSizeName { get; set; }
        public string MizzaSizeId { get; set; }

        public virtual ICollection<MizzaSku> MizzaSkus { get; set; }
    }
}
