using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Care
{
    public abstract class Care : Product
    {
        public string Directions { get; set; }
        public string Incredient { get; set; } // include a small paragraph with all the increadients for now

        //TODO check layout 
    }
}
