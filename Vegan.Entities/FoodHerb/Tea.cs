using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.FoodHerb
{
    public class Tea : FoodHerb
    {
        public string MoreInformation { get; set; }
        public string Preparation { get; set; }
        public string Precautions { get; set; }

        //https://www.the-apothecary.ca/Bulk-Herbs_c_71.html
    }
}
