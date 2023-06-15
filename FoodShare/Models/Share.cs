using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodShare.Models
{
    public class Share
    {
        [Key]
        public int ShareId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public required User User { get; set; }

        [ForeignKey("FoodType")]
        public int FoodTypeId { get; set; }
        public required FoodType FoodType { get; set; }

        [ForeignKey("Allergen")]
        public int? AllergenId { get; set; }
        public required Allergen Allergen { get; set; }

        [Required]
        public required string Name { get; set; }

        public required string Image { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int FeedCount { get; set; }

        [Required]
        public required string PickupLocation { get; set; }

        [Required]
        public required string Status { get; set; }
    }
}
