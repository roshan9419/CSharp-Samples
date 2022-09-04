using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlacementManagement.Web.ViewModels
{
    public class StudentQualificationViewModel
    {
        [Required]
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name = "Qualification Type")]
        public int QualificationTypeId { get; set; }

        [Display(Name = "Qualification Type")]
        public string QualificationName { get; set; }

        [Required]
        [Display(Name = "Percentage Scored")]
        public decimal Percentage { get; set; }

        [Required]
        [Display(Name = "Passing Year")]
        public int PassingYear { get; set; }
    }
}