using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Supplement
{
    public class PowerHealth : Supplement
    {
        //public Dictionary<string, string> Ingredient { get; set; }  // e.g. "Melatonin"(string 1)	"1 mg"(string 2)
        public string NameOfIngridient { get; set; }
        public string ValueOfIngridient { get; set; }
        public string UseInstruction { get; set; }

        //https://www.powerhealth.gr/proionta/apotoxinosi/
    }
}
