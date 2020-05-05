using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Database;
using Vegan.Entities.Care;
using Vegan.Entities.Interfaces;

namespace Vegan.Services.CareRepository
{
    public class FaceCreamRepository : GenericRepository<FaceCream>, IFaceCream
    {
        public FaceCreamRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
