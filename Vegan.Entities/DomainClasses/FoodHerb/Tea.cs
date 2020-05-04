using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.FoodHerb
{
    public class Tea : FoodHerb
    {
        public string NameOfIngredient { get; set; }
        public string ValueOfIngredient { get; set; }
        public string BulkPricing { get; set; }

        //https://www.the-apothecary.ca/alpen-glow-tea



        //Εδώ άλλαξα τις ιδιότητες, καθώς δεν ήταν ίδια με αυτά που θα έπαιρνα από το τσάι.

        //public string MoreInformation { get; set; }
        //public string Preparation { get; set; }
        //public string Precautions { get; set; }

        //https://www.the-apothecary.ca/Bulk-Herbs_c_71.html
    }
}
