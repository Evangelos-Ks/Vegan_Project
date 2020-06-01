using Vegan.Database;
using Vegan.Entities.FoodHerb;
using Vegan.Entities.Interfaces.FoodInterfaces;

namespace Vegan.Services.FoodRepository
{
    public class SproutingSeedRepository : GenericRepository<SproutingSeed>, ISproutingSeed
    {
        public SproutingSeedRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
