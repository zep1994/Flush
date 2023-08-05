using System.ComponentModel.DataAnnotations;

namespace Flush_API.Dtos
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
