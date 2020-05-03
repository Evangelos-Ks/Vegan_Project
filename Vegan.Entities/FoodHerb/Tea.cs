using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.FoodHerb
{
    public class Tea : FoodHerb
    {
        [Display(Name = "Ingredients")]
        public string NameOfIngredient { get; set; }
        [Display(Name = "Ingredients' values")]
        public string ValueOfIngredient { get; set; }
    

        //https://www.the-apothecary.ca/alpen-glow-tea



        //Εδώ άλλαξα τις ιδιότητες, καθώς δεν ήταν ίδια με αυτά που θα έπαιρνα από το τσάι.

        //public string MoreInformation { get; set; }
        //public string Preparation { get; set; }
        //public string Precautions { get; set; }

        //https://www.the-apothecary.ca/Bulk-Herbs_c_71.html
    }
}
