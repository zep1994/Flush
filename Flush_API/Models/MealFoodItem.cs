namespace Flush_API.Models
{
    public class MealFoodItem
    {
        public int MealId { get; set; }
        public Meal Meal { get; set; }

        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
    }
}
