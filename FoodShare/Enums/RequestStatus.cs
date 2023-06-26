using System.ComponentModel;

namespace FoodShare.Enums
{
    public enum RequestStatus
    {
        [Description("Pending")]
        Pending = 1,

        [Description("Accepted")]
        Accepted = 2,

        [Description("Rejected")]
        Rejected = 3,

        [Description("Completed")]
        Completed = 4,

        
    }
}
