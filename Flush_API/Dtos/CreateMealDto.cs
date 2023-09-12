using Microsoft.AspNetCore.Mvc;

namespace Flush_API.Dtos
{
    public class CreateMealDto : Controller
    {
        public string MealName { get; set; }
        public DateTime DateOfMeal { get; set; }
        public int UserId { get; set; }
        public List<int> FoodItemIds { get; set; }
    }
}
