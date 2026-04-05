using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCES.Models
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        [BindNever]
        public string RegistrationNo { get; set; }

        // Personal Details
        [Required]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string? Whatsapp { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime? DOB { get; set; }

        // Course
        public string? CourseMode { get; set; }
        public string? CourseName { get; set; }
        public string? Experience { get; set; }

        // Files (MAKE OPTIONAL)
        public string? PhotoPath { get; set; }
        public string? ResumePath { get; set; }
        public string? CertificatePath { get; set; }

        public string? Query { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}