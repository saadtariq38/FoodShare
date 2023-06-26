using System.ComponentModel;

namespace FoodShare.Enums
{
    public enum ShareStatus
    {
        [Description("Available")]
        Available = 1,

        [Description("Pending")]
        Pending = 2,

        [Description("Claimed")]
        Claimed = 3,

        [Description("Completed")]
        Completed = 4,

        // Add more share statuses as needed
    }
}
