using Vegan.Database;
using Vegan.Entities.Interfaces.SupplementInterfaces;
using Vegan.Entities.Supplement;

namespace Vegan.Services.SupplementRepository
{
    public class SuperFoodRepository : GenericRepository<SuperFood>, ISuperFood
    {
        public SuperFoodRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
