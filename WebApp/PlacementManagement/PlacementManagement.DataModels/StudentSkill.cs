namespace PlacementManagement.DataModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StudentSkill")]
    public partial class StudentSkill
    {
        [Required]
        public int StudentId { get; set; }
        
        [Required]
        public int SkillId { get; set; }
        
        public int? Experience { get; set; }
        
        public int? ProjectsDone { get; set; }
    }
}
