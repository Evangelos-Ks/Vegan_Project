using Vegan.Database;
using Vegan.Entities.Interfaces;
using Vegan.Entities.Interfaces.CareInterfaces;
using Vegan.Entities.Interfaces.FoodInterfaces;
using Vegan.Entities.Interfaces.HomeInterfaces;
using Vegan.Entities.Interfaces.SupplementInterfaces;
using Vegan.Services.CareRepository;
using Vegan.Services.FoodRepository;
using Vegan.Services.HomeRepository;
using Vegan.Services.SupplementRepository;

namespace Vegan.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDatabase context;

        public UnitOfWork(MyDatabase context)
        {
            this.context = context;
            Cares = new CareRepository.CareRepository(context);
            FaceCreams = new FaceCreamRepository(context);
            Hairs = new HairRepository(context);
            Lotions = new LotionRepository(context);
            ShaveBeards = new ShaveBeardRepository(context);
            FoodHerbs = new FoodHerbRepository(context);
            Salts = new SaltRepository(context);
            Spices = new SpiceRepository(context);
            SproutingSeeds = new SproutingSeedRepository(context);
            Teas = new TeaRepository(context);
            Candles = new CandleRepository(context);
            EssentialOils = new EssentialOilRepository(context);
            Homes = new HomeRepository.HomeRepository(context);
            HomeCleanings = new HomeCleaningRepository(context);
            Kitchens = new KitchenRepository(context);
            PowerHealths = new PowerHealthRepository(context);
            SuperFoods = new SuperFoodRepository(context);
            Supplements = new SupplementRepository.SupplementRepository(context);
            Orders = new OrderRepository(context);
            Products = new ProductRepository(context);
            Users = new UserRepository(context);
        }

        public ICare Cares { get; private set; }
        public IFaceCream FaceCreams { get; private set; }
        public IHair Hairs { get; private set; }
        public ILotion Lotions { get; private set; }
        public IShaveBeard ShaveBeards { get; private set; }
        public IFoodHerb FoodHerbs { get; private set; }
        public ISalt Salts { get; private set; }
        public ISpice Spices { get; private set; }
        public ISproutingSeed SproutingSeeds { get; private set; }
        public ITea Teas { get; private set; }
        public ICandle Candles { get; private set; }
        public IEssentialOil EssentialOils { get; private set; }
        public IHome Homes { get; private set; }
        public IHomeCleaning HomeCleanings { get; private set; }
        public IKitchen Kitchens { get; private set; }
        public IPowerHealth PowerHealths { get; private set; }
        public ISuperFood SuperFoods { get; private set; }
        public ISupplement Supplements { get; private set; }
        public IOrder Orders { get; private set; }
        public IProduct Products { get; private set; }
        public IUser Users { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
