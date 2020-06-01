using Vegan.Database;
using Vegan.Entities.Care;
using Vegan.Entities.Interfaces.CareInterfaces;

namespace Vegan.Services.CareRepository
{
    public class ShaveBeardRepository : GenericRepository<ShaveBeard>, IShaveBeard
    {
        public ShaveBeardRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
