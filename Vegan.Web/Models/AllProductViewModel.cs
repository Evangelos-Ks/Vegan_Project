using System.Collections.Generic;
using Vegan.Entities.Care;
using Vegan.Entities.FoodHerb;
using Vegan.Entities.Home;
using Vegan.Entities.Supplement;

namespace Vegan.Web.Controllers
{
    public class AllProductViewModel
    {
        public IEnumerable<Home> HomeProducts;
        public IEnumerable<Care> CareProducts;
        public IEnumerable<FoodHerb> FoodHerbProducts;
        public IEnumerable<Supplement> SupplementProducts;
    }
}