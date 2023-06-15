using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodShare.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public required User User { get; set; }

        [ForeignKey("Share")]
        public int ShareId { get; set; }
        public required Share Share { get; set; }

        [Required]
        public int HoursToPickup { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
