namespace PlacementManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    
    public partial class StudentQualification
    {
        [Required]
        public int StudentId { get; set; }
        
        [Required]
        public int QualificationTypeId { get; set; }

        public string QualificationName { get; set; }

        [Required]
        public decimal Percentage { get; set; }

        [Required]
        public int PassingYear { get; set; }
    }
}