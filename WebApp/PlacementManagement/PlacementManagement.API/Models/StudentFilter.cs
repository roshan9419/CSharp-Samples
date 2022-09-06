using PlacementManagement.DataModels.Enums;

namespace PlacementManagement.API.Models
{
    public class StudentFilter : Pagination
    {
        /// <summary>
        /// Minimum CGPA required
        /// </summary>
        public double? MinimumCGPA { get; set; }

        /// <summary>
        /// Maximum number of backlogs a student can have
        /// </summary>
        public int? MaximumBacklog { get; set; }

        /// <summary>
        /// Gender types like [Male, Female]
        /// </summary>
        public Gender[] Genders { get; set; }

        /// <summary>
        /// Batch year like [2023, 2024]
        /// </summary>
        public int[] Batches { get; set; }

        /// <summary>
        /// Array of ProgramId in which a student is enrolled, eg, BTech CSE, BTech ECE
        /// </summary>
        public int[] ProgramIds { get; set; }

        /// <summary>
        /// Qualifications a student must have with minimum percentage
        /// </summary>
        public QualificationPercentage[] Qualifications { get; set; }

        /// <summary>
        /// Array of skills a student has, eg, NodeJs, Python
        /// </summary>
        public int[] SkillIds { get; set; }
    }

    public class QualificationPercentage
    {
        public int QualificationTypeId { get; set; }
        public double MinimumPercentage { get; set; }
    }
}