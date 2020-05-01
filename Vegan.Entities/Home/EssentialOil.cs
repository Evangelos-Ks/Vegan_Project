using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Home
{
    public partial class EssentialOil : Home
    {
        public string NameOfIngredient { get; set; }
        public string ValueOfIngredient { get; set; }
        public BottleSize Size { get; set; }

       // https://www.the-apothecary.ca/Synergies-Blends_c_19.html
    }
}
