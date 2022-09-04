using System.ComponentModel.DataAnnotations;

namespace PlacementManagement.Web.ViewModels
{
    public class StudentProgramViewModel
    {
        [Required]
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name = "Program Enrolled")]
        public int ProgramId { get; set; }

        [Display(Name = "Program Enrolled")]
        public string ProgramName { get; set; }

        [Required]
        [Display(Name = "Batch Start Year")]
        public int BatchStartYear { get; set; }

        [Required]
        [Display(Name = "Batch End Year")]
        public int BatchEndYear { get; set; }

        [Required]
        [Display(Name = "No. of backlogs")]
        public int Backlogs { get; set; }

        [Display(Name = "Current CGPA (optional)")]
        public decimal? CurrentCGPA { get; set; }
    }
}