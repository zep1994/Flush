using Flush_API.Models;

namespace Flush_API.Data
{
    public interface IFoodItemRepo
    {
        Task<List<User>> GetFoods();
        Task<User> GetFoodItem(int id);
        Task PostFoodItem(FoodItemRepo foodItem);
        Task UpdateFoodItem(FoodItemRepo foodItem);
        void DeleteFoodItem(int id);
    }
}
