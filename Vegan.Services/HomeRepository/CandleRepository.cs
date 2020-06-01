using Vegan.Database;
using Vegan.Entities.Home;
using Vegan.Entities.Interfaces.HomeInterfaces;

namespace Vegan.Services.HomeRepository
{
    public class CandleRepository : GenericRepository<Candle>, ICandle
    {
        public CandleRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
