namespace Mizza.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MizzaStyle")]
    public partial class MizzaStyle
    {
        [Required]
        [StringLength(50)]
        public string MizzaStyleName { get; set; }

        [StringLength(10)]
        public string MizzaStyleID { get; set; }
    }
}
