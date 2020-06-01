using Vegan.Database;
using Vegan.Entities.FoodHerb;
using Vegan.Entities.Interfaces.FoodInterfaces;

namespace Vegan.Services.FoodRepository
{
    public class SaltRepository : GenericRepository<Salt>, ISalt
    {
        public SaltRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
