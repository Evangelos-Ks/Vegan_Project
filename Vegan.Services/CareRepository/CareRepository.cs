using Vegan.Database;
using Vegan.Entities.Care;
using Vegan.Entities.Interfaces;

namespace Vegan.Services.CareRepository
{
    public class CareRepository : GenericRepository<Care>, ICare
    {
        public CareRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
