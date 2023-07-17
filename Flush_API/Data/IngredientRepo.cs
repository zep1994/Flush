using Flush_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flush_API.Data
{
    public class IngredientRepo : IIngredientRepo
    {
        private readonly AppDbContext _context;

        public IngredientRepo(AppDbContext context)
        {
            _context = context;
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

        public async Task<Ingredient> GetIngredientById(int id)
        {
            return await _context.Ingredient.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
