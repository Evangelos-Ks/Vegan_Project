using System.ComponentModel.DataAnnotations;

namespace Vegan.Entities.FoodHerb
{
    public abstract class FoodHerb : Product
    {
        [Display(Name = "Bulk pricing")]
        public string BulkPricing { get; set; }
        public string Information { get; set; }
        [Display(Name = "Ingredients")]
        public string NameOfIngredient { get; set; }
        public string Category { get; set; } = "FoodHerb";
    }
}
