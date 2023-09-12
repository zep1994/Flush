namespace Flush_API.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string MealName { get; set; } // e.g. "Dinner", "Breakfast", etc.

        // Foreign Key for User
        public int UserId { get; set; }
        // Navigation Property for User
        public User User { get; set; }
        public DateTime DateOfMeal { get; set; } = DateTime.Now;


        // Navigation Property for the relationship
        public ICollection<MealFoodItem> MealFoodItems { get; set; } = new List<MealFoodItem>();
    }
}

