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
        public string NameOfIngredient { get; set; }
        public string ValueOfIngredient { get; set; }

        //TODO check layout 
    }
}
