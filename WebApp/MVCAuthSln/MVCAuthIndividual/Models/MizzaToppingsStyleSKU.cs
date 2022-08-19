namespace MVCAuthIndividual.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MizzaToppingsStyleSKU")]
    public partial class MizzaToppingsStyleSKU
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ToppingStyleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string ToppingSKUID { get; set; }

        public virtual MizzaToppingSKUPrice MizzaToppingSKUPrice { get; set; }

        public virtual MizzaToppingSKUStock MizzaToppingSKUStock { get; set; }

        public virtual MizzaToppingStyle MizzaToppingStyle { get; set; }
    }
}
