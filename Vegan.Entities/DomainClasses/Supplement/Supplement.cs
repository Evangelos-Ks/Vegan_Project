using System.ComponentModel.DataAnnotations;

namespace Vegan.Entities.Supplement
{
    public abstract class Supplement : Product
    {
        public string Information { get; set; }
        [Display(Name = "Incredients")]
        public string NameOfIngredient { get; set; }
        [Display(Name = "Incredients' values")]
        public string ValueOfIngredient { get; set; }
        [Display(Name = "Instructions")]
        public string UseInstruction { get; set; }
        public string Category { get; set; } = "Supplement";


    }
}
