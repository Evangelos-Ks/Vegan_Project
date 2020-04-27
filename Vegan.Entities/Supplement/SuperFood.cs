using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Supplement
{
    public class SuperFood : Supplement
    {
        public Dictionary<string, string> Ingredient { get; set; } // e.g. "Melatonin"(string 1)	"1 mg"(string 2)

        //https://www.superfoods.eu/products/

    }
}
