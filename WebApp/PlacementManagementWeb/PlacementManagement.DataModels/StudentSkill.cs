namespace PlacementManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    
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
