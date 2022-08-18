namespace Mizza.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MizzaSKUStock")]
    public partial class MizzaSKUStock
    {
        [Key]
        [StringLength(10)]
        public string SKUID { get; set; }

        [Required]
        [StringLength(10)]
        public string StockCount { get; set; }
    }
}
