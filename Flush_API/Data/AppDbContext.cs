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

    }
}
