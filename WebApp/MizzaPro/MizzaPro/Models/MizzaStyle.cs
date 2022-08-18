using System;
using System.Collections.Generic;

#nullable disable

namespace MizzaPro.Models
{
    public partial class MizzaStyle
    {
        public MizzaStyle()
        {
            MizzaSkus = new HashSet<MizzaSku>();
        }

        public string MizzaStyleName { get; set; }
        public string MizzaStyleId { get; set; }

        public virtual ICollection<MizzaSku> MizzaSkus { get; set; }
    }
}
