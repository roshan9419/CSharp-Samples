namespace MVCAuthIndividual.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MizzaSKUStock")]
    public partial class MizzaSKUStock
    {
        [Key]
        [StringLength(10)]
        public string SKUID { get; set; }

        [Required]
        [StringLength(10)]
        public string StockCount { get; set; }

        public virtual MizzaSKU MizzaSKU { get; set; }
    }
}
