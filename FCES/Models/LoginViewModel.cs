using System.ComponentModel.DataAnnotations;

namespace FCES.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; } // Email or Mobile

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}