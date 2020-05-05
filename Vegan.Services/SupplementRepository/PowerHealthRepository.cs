using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Database;
using Vegan.Entities.Interfaces.SupplementInterfaces;
using Vegan.Entities.Supplement;

namespace Vegan.Services.SupplementRepository
{
    public class PowerHealthRepository : GenericRepository<PowerHealth>, IPowerHealth
    {
        public PowerHealthRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
