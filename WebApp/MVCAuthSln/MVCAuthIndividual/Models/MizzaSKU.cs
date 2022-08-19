namespace MVCAuthIndividual.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MizzaSKU")]
    public partial class MizzaSKU
    {
        [StringLength(10)]
        public string MizzaSKUID { get; set; }

        [Required]
        [StringLength(50)]
        public string MizzaSKUName { get; set; }

        [Required]
        [StringLength(10)]
        public string MizzaStyleID { get; set; }

        [Required]
        [StringLength(10)]
        public string MizzaSizeID { get; set; }

        public virtual MizzaSize MizzaSize { get; set; }

        public virtual MizzaStyle MizzaStyle { get; set; }

        public virtual MizzaSkuBasePrice MizzaSkuBasePrice { get; set; }

        public virtual MizzaSKUStock MizzaSKUStock { get; set; }
    }
}
