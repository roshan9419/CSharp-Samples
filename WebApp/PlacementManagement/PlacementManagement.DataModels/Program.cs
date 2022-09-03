namespace PlacementManagement.DataModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Program")]
    public partial class Program
    {
        public int ProgramId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProgramName { get; set; }
    }
}
