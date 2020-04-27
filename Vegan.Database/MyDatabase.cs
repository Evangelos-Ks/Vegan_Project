using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Vegan.Entities.Home;
using Vegan.Entities;
using Vegan.Entities.Care;
using Vegan.Entities.FoodHerb;
using Vegan.Entities.Supplement;

namespace Vegan.Database
{
   public  class MyDatabase : DbContext
    {
        public MyDatabase() : base("Connection")
        {
           
        }

        public DbSet<Candle> Candles { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FaceCream> FaceCreams { get; set; }
        public DbSet<Care> Cares { get; set; }
        public DbSet<FoodHerb> FoodHerbs { get; set; }
        public DbSet<Tea> Teas { get; set; }
        public DbSet<Spice> Spices { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<SuperFood> SuperFoods { get; set; }
        public DbSet<PowerHealth> PowerHealths { get; set; }
    }
}
