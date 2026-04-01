using System.ComponentModel.DataAnnotations;

namespace FCES.Models
{
    public class ContactModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string Message { get; set; }
    }
}