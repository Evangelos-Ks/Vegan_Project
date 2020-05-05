using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.FoodHerb
{
    public abstract class FoodHerb : Product
    {
        [Display(Name = "Bulk pricing")]
        public string BulkPricing { get; set; }

        public string Information { get; set; }
        //Review
    }
}
