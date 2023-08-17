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

        [HttpGet("{id}")]
        [Route("api/food/{id}")]
        public IActionResult GetFoodItem(int id)
        {
            var foodItem = _foodItems.FirstOrDefault(item => item.Id == id);
            if (foodItem == null)
            {
                return NotFound();
            }

            return Ok(foodItem);
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
        [Route("api/food/{id}")]
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
        [Route("api/food/{id}")]
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