namespace Mizza.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MizzaSkuBasePrice")]
    public partial class MizzaSkuBasePrice
    {
        [Key]
        [StringLength(10)]
        public string SKUID { get; set; }

        public int Price { get; set; }
    }
}
