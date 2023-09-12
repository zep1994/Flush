using Flush_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flush_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<IbsCount> IbsCount => Set<IbsCount>();

        public DbSet<Ingredient> Ingredient => Set<Ingredient>();

        public DbSet<User> User => Set<User>();

        public DbSet<UserLogin> UserLogin => Set<UserLogin>();

        public DbSet<FoodItem> FoodItem => Set<FoodItem>();
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealFoodItem> MealFoodItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealFoodItem>()
                .HasKey(mfi => new { mfi.MealId, mfi.FoodItemId });

            modelBuilder.Entity<MealFoodItem>()
                .HasOne(mfi => mfi.Meal)
                .WithMany(m => m.MealFoodItems)
                .HasForeignKey(mfi => mfi.MealId);

            modelBuilder.Entity<MealFoodItem>()
                .HasOne(mfi => mfi.FoodItem)
                .WithMany(f => f.MealFoodItems)
                .HasForeignKey(mfi => mfi.FoodItemId);
        }
    }
}
