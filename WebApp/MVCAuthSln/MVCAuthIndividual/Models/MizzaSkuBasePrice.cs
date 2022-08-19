namespace MVCAuthIndividual.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MizzaSkuBasePrice")]
    public partial class MizzaSkuBasePrice
    {
        [Key]
        [StringLength(10)]
        public string SKUID { get; set; }

        public int Price { get; set; }

        public virtual MizzaSKU MizzaSKU { get; set; }
    }
}
