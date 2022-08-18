using System;
using System.Collections.Generic;

#nullable disable

namespace MizzaPro.Models
{
    public partial class MizzaToppingStyle
    {
        public MizzaToppingStyle()
        {
            MizzaToppingsStyleSkus = new HashSet<MizzaToppingsStyleSku>();
        }

        public string ToppingStyleId { get; set; }
        public string ToppingName { get; set; }

        public virtual ICollection<MizzaToppingsStyleSku> MizzaToppingsStyleSkus { get; set; }
    }
}
