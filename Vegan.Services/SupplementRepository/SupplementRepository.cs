using Vegan.Database;
using Vegan.Entities.Interfaces.SupplementInterfaces;
using Vegan.Entities.Supplement;

namespace Vegan.Services.SupplementRepository
{
    public class SupplementRepository : GenericRepository<Supplement>, ISupplement
    {
        public SupplementRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
