using Vegan.Database;
using Vegan.Entities.Care;
using Vegan.Entities.Interfaces.CareInterfaces;

namespace Vegan.Services.CareRepository
{
    public class LotionRepository : GenericRepository<Lotion>, ILotion
    {
        public LotionRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
