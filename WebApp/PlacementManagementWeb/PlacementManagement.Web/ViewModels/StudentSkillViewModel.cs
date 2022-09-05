using System.ComponentModel.DataAnnotations;

namespace PlacementManagement.Web.ViewModels
{
    public class StudentSkillViewModel
    {
        [Required]
        [Display(Name = "Skill")]
        public int SkillId { get; set; }

        [Display(Name = "Skill")]
        public string SkillName { get; set; }

        [Required]
        [Display(Name = "Experience (in months)")]
        public int? Experience { get; set; }

        [Required]
        [Display(Name = "Total Projects done")]
        public int? ProjectsDone { get; set; }
    }
}