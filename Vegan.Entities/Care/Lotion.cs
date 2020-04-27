using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Care
{
    public class Lotion : Care
    {
        public string Incredient { get; set; } // include a small paragraph with all the increadients for now
        public Size Size { get; set; } 

        //https://www.the-apothecary.ca/Cremes-Lotions_c_120.html
    }
}
