using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vegan.Entities.Care
{
    public abstract class Care : Product
    {
        public string Directions { get; set; }
        [Display(Name = "Ingredients")]
        public string NameOfIngredient { get; set; }
        public string Information { get; set; }

    }
}
