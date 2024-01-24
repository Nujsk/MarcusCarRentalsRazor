using System.ComponentModel.DataAnnotations;

namespace MarcusCarRentals.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }

        public User()
        {

        }
    }
}
