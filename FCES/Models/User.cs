using System.ComponentModel.DataAnnotations;

namespace FCES.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Course { get; set; }

        public string Role { get; set; }
    }
}