using Flush_API.Data;
using Flush_API.Dtos;
using Flush_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flush_API.Controllers
{
    public class MealController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MealController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/meals")]
        public async Task<IActionResult> CreateMeal([FromBody] CreateMealDto createMealDto)
        {
            var user = await _context.User.FindAsync(createMealDto.UserId);
            if (user == null)
            {
                return NotFound($"User with ID {createMealDto.UserId} not found.");
            }

            var meal = new Meal
            {
                MealName = createMealDto.MealName,
                DateOfMeal = createMealDto.DateOfMeal,
                User = user
            };

            foreach (var foodItemId in createMealDto.FoodItemIds)
            {
                var foodItem = await _context.FoodItem.FindAsync(foodItemId);
                if (foodItem == null)
                {
                    return NotFound($"FoodItem with ID {foodItemId} not found.");
                }

                meal.MealFoodItems.Add(new MealFoodItem { FoodItem = foodItem });
            }

            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return Ok(meal);
        } 
    }
}
