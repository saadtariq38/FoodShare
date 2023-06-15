using System.ComponentModel.DataAnnotations;

namespace FoodShare.Models
{
    public class FoodType
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        [MaxLength(30)]
        public  required string TypeName { get; set; }
    }
}
