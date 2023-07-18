namespace Flush_API.Models
{
    public class UserConstants
    {
        public static List<User> Users = new List<User>()
        {
            new User() { UserName = "test", Email = "test",Password = "test", Role="Admin" },
            new User() { UserName = "test2", Email="test2", Password = "test2", Role="User"}
        };
    }
}
