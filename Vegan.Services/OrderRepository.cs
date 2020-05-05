using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Database;
using Vegan.Entities;
using Vegan.Entities.Interfaces;

namespace Vegan.Services
{
    public class OrderRepository : GenericRepository<Order>, IOrder
    {
        public OrderRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
