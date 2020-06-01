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
