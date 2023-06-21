using System.ComponentModel.DataAnnotations;

namespace FoodShare.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "default";

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "1";

        [Required]
        [Phone]
        public string Contact { get; set; } = string.Empty;

        public int SharesCompleted { get; set; } = 0;
    }
}
