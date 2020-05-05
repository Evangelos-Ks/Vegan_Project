using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Care
{
    public class Hair : Care
    {
        [Display(Name = "Details")]
        public string Detail{ get; set; }

        //https://www.the-apothecary.ca/Hair-Care_c_182.html
    }
}
