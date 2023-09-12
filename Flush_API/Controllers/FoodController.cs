using Flush_API.Data;
using Flush_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flush_API.Controllers
{
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly AppDbContext _context;

        private static List<FoodItem> _foodItems = new List<FoodItem>();

        public FoodController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/foods")]
        public IActionResult GetFoods()
        {
            return Ok(_foodItems);
        }

        [HttpGet]
        [Route("api/food/byname")]
        public async Task<IActionResult> GetFoodItem([FromBody] FoodItem requestFoodItem)
        {
            {
                if (requestFoodItem == null || string.IsNullOrEmpty(requestFoodItem.Name))
                {
                    return BadRequest("Invalid food item name provided.");
                }

                var foodItem = await _context.FoodItem
                                      .FirstOrDefaultAsync(b => b.Name.ToLower() == requestFoodItem.Name.ToLower());

                if (foodItem == null)
                {
                    return NotFound($"No food item found with the name: {requestFoodItem.Name}");
                }

                return Ok(foodItem);
            }
        }

        [HttpPost]
        [Route("api/food")]
        public async Task<IActionResult> PostFoodItem([FromBody] FoodItem foodItem)
        {
            if (foodItem == null)
            {
                return BadRequest("Food data is empty.");
            }

            _context.FoodItem.Add(foodItem);
            await _context.SaveChangesAsync();

            // Return a success response.
            return Ok("Food Item registered successfully.");
        }

        [HttpPut("{id}")]
        [Route("api/foods/{id}")]
        public IActionResult UpdateFoodItem(int id, FoodItem foodItem)
        {
            var existingItem = _foodItems.FirstOrDefault(item => item.Id == id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = foodItem.Name;
            existingItem.Description = foodItem.Description;
            existingItem.Carbs = foodItem.Carbs;
            existingItem.Proteins = foodItem.Proteins;
            existingItem.Fats = foodItem.Fats;

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Route("api/foods/{id}")]
        public IActionResult DeleteFoodItem(int id)
        {
            var existingItem = _foodItems.FirstOrDefault(item => item.Id == id);
            if (existingItem == null)
            {
                return NotFound();
            }

            _foodItems.Remove(existingItem);

            return NoContent();
        }
    }
}