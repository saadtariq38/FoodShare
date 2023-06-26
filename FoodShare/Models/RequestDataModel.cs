using System.ComponentModel.DataAnnotations;

namespace FoodShare.Models
{
    public class RequestDataModel
    {
        [Required]
        public required int ShareId { get; set; }

        [Required]
        public required int HoursToPickup { get; set; }
    }
}
