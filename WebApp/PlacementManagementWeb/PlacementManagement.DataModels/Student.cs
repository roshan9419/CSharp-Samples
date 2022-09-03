namespace PlacementManagement.Models
{
    using PlacementManagement.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {
        [Required]
        public string UserId { get; set; }

        public int StudentId { get; set; }

        [Required]
        [StringLength(45)]
        public string FirstName { get; set; }

        [StringLength(45)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(12)]
        public string Aadhaar { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

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
        public string PostalCode { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
