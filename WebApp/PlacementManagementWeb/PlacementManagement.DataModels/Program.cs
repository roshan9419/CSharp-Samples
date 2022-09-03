namespace PlacementManagement.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Program
    {
        public int ProgramId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProgramName { get; set; }
    }
}
