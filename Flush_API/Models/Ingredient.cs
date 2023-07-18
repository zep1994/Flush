using System.ComponentModel.DataAnnotations;

namespace Flush_API.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public string[]? Results { get; set; }


    }
}
