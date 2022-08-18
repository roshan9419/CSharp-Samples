namespace Mizza.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MizzaToppingStyle")]
    public partial class MizzaToppingStyle
    {
        [Key]
        [StringLength(10)]
        public string ToppingStyleID { get; set; }

        [Required]
        [StringLength(50)]
        public string ToppingName { get; set; }
    }
}
