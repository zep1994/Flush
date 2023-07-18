using Flush_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flush_API.Data
{
    public class IngredientRepo : IIngredientRepo
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _client;

        public IngredientRepo(AppDbContext context, HttpClient httpClient)
        {
            _context = context;
            _client = httpClient;   
        }
        public async Task CreateIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            await _context.AddAsync(ingredient);
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            _context.Ingredient.Remove(ingredient);
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            return await _context.Ingredient.ToListAsync();
        }


        public Task<Ingredient> GetIngredientInformation(int? id, decimal? amount, string unit)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetIngredientSubstitutes(string ingredientName)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
