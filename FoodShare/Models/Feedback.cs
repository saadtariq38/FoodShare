using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodShare.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public required User User { get; set; }

        [Required]
        [Range(0, 5)]
        public decimal Rating { get; set; }

        public string[]? Comments { get; set; }
    }
}
