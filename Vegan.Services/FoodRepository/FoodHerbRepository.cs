using Vegan.Database;
using Vegan.Entities.FoodHerb;
using Vegan.Entities.Interfaces.FoodInterfaces;

namespace Vegan.Services.FoodRepository
{
    public class FoodHerbRepository : GenericRepository<FoodHerb>, IFoodHerb
    {
        public FoodHerbRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
