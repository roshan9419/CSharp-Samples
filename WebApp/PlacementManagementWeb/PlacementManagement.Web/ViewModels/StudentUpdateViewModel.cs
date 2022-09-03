using System;
using System.ComponentModel.DataAnnotations;

namespace PlacementManagement.Web.ViewModels
{
    public class StudentUpdateViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(6)]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Aadhaar Number")]
        public string Aadhaar { get; set; }

        [Required]
        [StringLength(256)]
        public string Address { get; set; }

        [Required]
        [StringLength(45)]
        public string Country { get; set; }

        [Required]
        [StringLength(45)]
        public string State { get; set; }

        [Required]
        [StringLength(45)]
        public string City { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
