using System.Collections.Generic;
using Vegan.Entities.Care;
using Vegan.Entities.FoodHerb;
using Vegan.Entities.Home;
using Vegan.Entities.Supplement;

namespace Vegan.Web.Models
{
    public class AllProductViewModel
    {

        // ================================ Properties =========================================
        public IEnumerable<Home> HomeProducts { get; set; }
        public IEnumerable<FoodHerb> FoodHerbProducts { get; set; }
        public IEnumerable<Care> CareProducts { get; set; }
        public IEnumerable<Supplement> SupplementProducts { get; set; }

    }

}
