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
       

        [ForeignKey("Share")]
        public int ShareId { get; set; }

        [Required]
        public int HoursToPickup { get; set; }

        [Required]
        public string RequestStatus { get; set; } = string.Empty;
    }
}
