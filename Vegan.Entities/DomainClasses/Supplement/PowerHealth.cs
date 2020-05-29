using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Supplement
{
    public class PowerHealth : Supplement
    {
        public string SubCategory { get; set; } = "PowerHealth";
    }
}
