using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
