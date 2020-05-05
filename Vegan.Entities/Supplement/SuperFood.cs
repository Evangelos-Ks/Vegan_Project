using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Supplement
{
    public class SuperFood : Supplement
    {
        [Display(Name = "Incredients")]
        public string NameOfIngredient { get; set; }
        [Display(Name = "Incredients' values")]
        public string ValueOfIngredient { get; set; }

        //https://www.superfoods.eu/products/

    }
}
