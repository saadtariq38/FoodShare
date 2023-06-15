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
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        public required string Role { get; set; }

        [Required]
        [Phone]
        public required string Contact { get; set; }

        public int SharesCompleted { get; set; }
    }
}
