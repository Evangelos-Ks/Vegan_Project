using System.ComponentModel.DataAnnotations;


namespace Vegan.Entities.Care
{
    public abstract class Care : Product
    {
        public string Directions { get; set; }
        [Display(Name = "Ingredients")]
        public string NameOfIngredient { get; set; }
        public string Information { get; set; }
        public string Category { get; set; } = "Care";
    }
}
