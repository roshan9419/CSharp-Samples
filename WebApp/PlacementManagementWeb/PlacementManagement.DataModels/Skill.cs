namespace PlacementManagement.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Skill
    {
        public int SkillId { get; set; }

        [Required]
        [StringLength(100)]
        public string SkillName { get; set; }
    }
}
