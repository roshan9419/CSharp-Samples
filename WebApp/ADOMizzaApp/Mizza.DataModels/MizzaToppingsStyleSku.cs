namespace Mizza.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
