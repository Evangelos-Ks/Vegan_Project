using Vegan.Database;
using Vegan.Entities;
using Vegan.Entities.Interfaces;

namespace Vegan.Services
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {
        public ProductRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
