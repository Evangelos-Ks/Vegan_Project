using Vegan.Database;
using Vegan.Entities.FoodHerb;
using Vegan.Entities.Interfaces.FoodInterfaces;

namespace Vegan.Services.FoodRepository
{
    public class TeaRepository : GenericRepository<Tea>, ITea
    {
        public TeaRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
