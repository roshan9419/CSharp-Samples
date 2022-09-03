namespace PlacementManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    
    public partial class StudentProgram
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int ProgramId { get; set; }

        [Required]
        public int BatchStartYear { get; set; }

        [Required]
        public int BatchEndYear { get; set; }

        [Required]
        public int Backlogs { get; set; }

        public decimal? CurrentCGPA { get; set; }
    }
}
