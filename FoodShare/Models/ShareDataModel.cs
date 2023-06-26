using System.ComponentModel.DataAnnotations;

namespace FoodShare.Models
{
    public class ShareDataModel
    {
        

        [StringLength(100)]
        public string Description { get; set; }

        public string FoodType { get; set; }

        public string Allergen { get; set; }

        [Required]
        public required string Name { get; set; }

        public string Image { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public required int FeedCount { get; set; }

        [Required]
        public required string PickupLocation { get; set; }

    }
}
