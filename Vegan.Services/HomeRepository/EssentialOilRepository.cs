using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Database;
using Vegan.Entities.Home;
using Vegan.Entities.Interfaces.HomeInterfaces;

namespace Vegan.Services.HomeRepository
{
    public class EssentialOilRepository : GenericRepository<EssentialOil>, IEssentialOil
    {
        public EssentialOilRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
