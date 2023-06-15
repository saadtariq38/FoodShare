using FoodShare.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodShare.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
