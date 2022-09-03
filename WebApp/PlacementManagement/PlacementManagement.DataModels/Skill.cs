namespace PlacementManagement.DataModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Skill")]
    public partial class Skill
    {
        public int SkillId { get; set; }

        [Required]
        [StringLength(100)]
        public string SkillName { get; set; }
    }
}
