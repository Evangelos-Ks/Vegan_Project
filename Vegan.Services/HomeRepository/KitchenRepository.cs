using Vegan.Database;
using Vegan.Entities.Home;
using Vegan.Entities.Interfaces.HomeInterfaces;

namespace Vegan.Services.HomeRepository
{
    public class KitchenRepository : GenericRepository<Kitchen>, IKitchen
    {
        public KitchenRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
