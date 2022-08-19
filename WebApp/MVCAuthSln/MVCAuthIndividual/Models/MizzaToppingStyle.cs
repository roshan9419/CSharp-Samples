namespace MVCAuthIndividual.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MizzaToppingStyle")]
    public partial class MizzaToppingStyle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MizzaToppingStyle()
        {
            MizzaToppingsStyleSKUs = new HashSet<MizzaToppingsStyleSKU>();
        }

        [Key]
        [StringLength(10)]
        public string ToppingStyleID { get; set; }

        [Required]
        [StringLength(50)]
        public string ToppingName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MizzaToppingsStyleSKU> MizzaToppingsStyleSKUs { get; set; }
    }
}
