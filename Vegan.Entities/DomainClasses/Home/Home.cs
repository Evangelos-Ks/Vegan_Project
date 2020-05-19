using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Home
{
    public abstract class Home : Product
    {

        public string Instructions { get; set; }

        public string Information { get; set; }
        [Display(Name = "Incredients")]
        public string NameOfIngredientEssentOil { get; set; }



    }
}
