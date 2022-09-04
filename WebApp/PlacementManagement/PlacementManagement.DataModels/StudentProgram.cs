namespace PlacementManagement.DataModels
{
    using PlacementManagement.Attributes;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StudentProgram")]
    public partial class StudentProgram
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int ProgramId { get; set; }

        [IgnorePropertyConversion]
        public string ProgramName { get; set; }

        [Required]
        public int BatchStartYear { get; set; }

        [Required]
        public int BatchEndYear { get; set; }

        [Required]
        public int Backlogs { get; set; }

        public decimal? CurrentCGPA { get; set; }
    }
}
