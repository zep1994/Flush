namespace Flush_API.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Carbs { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
    }
}
