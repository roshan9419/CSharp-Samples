namespace PlacementManagement.DataModels
{
    using PlacementManagement.Attributes;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StudentQualification")]
    public partial class StudentQualification
    {
        [Required]
        public int StudentId { get; set; }
        
        [Required]
        public int QualificationTypeId { get; set; }

        [IgnorePropertyConversion]
        public string QualificationName { get; set; }

        [Required]
        public decimal Percentage { get; set; }

        [Required]
        public int PassingYear { get; set; }
    }
}