using System.ComponentModel.DataAnnotations;

namespace FoodShare.Models
{
    public class LoginDataModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "default";
    }
}
