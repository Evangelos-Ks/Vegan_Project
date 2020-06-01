using System.Data.Entity;
using Vegan.Entities;
using Vegan.Entities.Care;
using Vegan.Entities.DomainClasses.Sales;
using Vegan.Entities.FoodHerb;
using Vegan.Entities.Home;
using Vegan.Entities.Library;
using Vegan.Entities.Supplement;

namespace Vegan.Database
{

    public class MyDatabase : ApplicationDbContext
    {
        public MyDatabase() : base()
        {
           
        }
       
        //====================== Product ==================
        public DbSet<Product> Products { get; set; }

        ////====================== Sales ==================
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        //public DbSet<WebhookEvent> WebhookEvents { get; set; }

        //====================== Care =====================
        public DbSet<Care> Cares { get; set; }
        public DbSet<FaceCream> FaceCreams { get; set; }
        public DbSet<Hair> Hairs {get; set; }
        public DbSet<Lotion> Lotions {get; set; }
        public DbSet<ShaveBeard> ShaveBeards {get; set; }

        //====================== FoodHerb =================
        public DbSet<FoodHerb> FoodHerbs { get; set; }
        public DbSet<Salt> Salts { get; set; }
        public DbSet<Spice> Spices { get; set; }
        public DbSet<SproutingSeed> SproutingSeeds {get; set; }
        public DbSet<Tea> Teas { get; set; }

        //====================== Home =====================
        public DbSet<Home> Homes { get; set; }
        public DbSet<Candle> Candles { get; set; }
        public DbSet<EssentialOil> EssentialOils { get; set; }
        public DbSet<HomeCleaning> HomeCleanings { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }

        //=================== Supplement ==================
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<PowerHealth> PowerHealths { get; set; }
        public DbSet<SuperFood> SuperFoods { get; set; }
    }
}
