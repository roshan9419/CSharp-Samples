namespace MVCAuthIndividual.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MizzaSize")]
    public partial class MizzaSize
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MizzaSize()
        {
            MizzaSKUs = new HashSet<MizzaSKU>();
        }

        [Required]
        [StringLength(50)]
        public string MizzaSizeName { get; set; }

        [StringLength(10)]
        public string MizzaSizeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MizzaSKU> MizzaSKUs { get; set; }
    }
}
