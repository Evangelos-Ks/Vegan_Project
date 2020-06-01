using Vegan.Database;
using Vegan.Entities.FoodHerb;
using Vegan.Entities.Interfaces.FoodInterfaces;

namespace Vegan.Services.FoodRepository
{
    public class SpiceRepository : GenericRepository<Spice>, ISpice
    {
        public SpiceRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
