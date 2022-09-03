using PlacementManagement.Models;
using System.Collections.Generic;

namespace PlacementManagement.Web.ViewModels
{
    public class StudentDetailViewModel
    {
        public Student Student { get; set; }
        public List<StudentProgram> StudentPrograms { get; set; }
        public List<StudentQualification> StudentQualifications { get; set; }
        public List<StudentSkill> StudentSkills { get; set; }
    }
}