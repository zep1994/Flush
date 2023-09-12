namespace Flush_API.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Carbs { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public bool HighFiberFood { get; set; }
        public bool FODMAP { get; set; }
        public bool DairyProduct { get; set; }
        public bool Gluten { get; set;}
        public bool Spicy { get; set; }
        public bool FattyOrGreasyFood { get; set; }
        public bool ArtificialSweetener { get; set; }
        public bool HighSugarFood { get; set; }
        public bool Alcohol { get; set; }
        public bool ProcessedFriedFood { get; set; }
        public bool CarbonatedBeverage { get; set; }
        public bool ArtificialAdditive { get; set; }
        public bool CoffeeTea { get; set; }
    }
}
