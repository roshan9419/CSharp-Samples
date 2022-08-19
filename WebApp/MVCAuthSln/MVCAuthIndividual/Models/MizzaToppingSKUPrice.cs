namespace MVCAuthIndividual.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MizzaToppingSKUPrice")]
    public partial class MizzaToppingSKUPrice
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ToppingStyleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SKUID { get; set; }

        public int Price { get; set; }

        public virtual MizzaToppingsStyleSKU MizzaToppingsStyleSKU { get; set; }
    }
}
