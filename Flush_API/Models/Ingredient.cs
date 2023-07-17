using System.ComponentModel.DataAnnotations;

namespace Flush_API.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Amount { get; set; }

        public string? Image { get; set; }

        public string[]? MetaInformation { get; set; }

        public string[]? Nutrition { get; set; }

        public string[]? Properties { get; set; }

        public string[]? Flavonoids { get; set; }
    }
}
