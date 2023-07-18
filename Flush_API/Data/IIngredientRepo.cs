using Flush_API.Models;

namespace Flush_API.Data
{
    public interface IIngredientRepo
    {
        Task SaveChanges();
        Task<Ingredient> GetIngredientSubstitutes(string ingredientName);
        Task<Ingredient> GetIngredientInformation(int? id, decimal? amount, string unit);
        Task CreateIngredient(Ingredient ingredient);
        void DeleteIngredient(Ingredient ingredient);

    }
}
