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

        
        [StringLength(100)]
        public string? Description { get; set; }

        [ForeignKey("FoodType")]
        public int FoodTypeId { get; set; }
        public required FoodType FoodType { get; set; }

        [ForeignKey("Allergen")]
        public int? AllergenId { get; set; }
        public required Allergen Allergen { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int FeedCount { get; set; }

        [Required]
        public string PickupLocation { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;
    }
}
