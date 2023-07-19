using Flush_API.Models;

namespace Flush_API.Data
{
    public interface IUserRepo
    {
        Task SaveChanges();
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task CreateUser(User user);
        void DeleteUser(User user);
    }
}
