using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Home
{
    public partial class EssentialOil : Home
    {
        [Display(Name = "Incredients")]
        public string NameOfIngredientEssentOil { get; set; }
        [Display(Name = "Incredients' values")]
        public string ValueOfIngredientEssentOil { get; set; }
        [Display(Name = "Size")]
        public BottleSize Size { get; set; }

       // https://www.the-apothecary.ca/Synergies-Blends_c_19.html
    }
}
