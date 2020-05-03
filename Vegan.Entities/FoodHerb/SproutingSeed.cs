using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.FoodHerb
{
    public class SproutingSeed : FoodHerb
    {
        [Display(Name = "Ingredients")]
        public string NameOfIngredient { get; set; }
        [Display(Name = "Ingredients' values")]
        public string ValueOfIngredient { get; set; } 

        //https://www.the-apothecary.ca/organic-sprouting-seeds
    }
}
