using Flush_API.Models;

namespace Flush_API.Data
{
    public interface IIngredientRepo
    {
        Task SaveChanges();
        Task<Ingredient> GetIngredientById(int id);
        Task<IEnumerable<Ingredient>> GetAllIngredients();
        Task CreateIngredient(Ingredient ingredient);
        void DeleteIngredient(Ingredient ingredient);

    }
}
