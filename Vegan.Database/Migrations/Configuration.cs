namespace Vegan.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vegan.Entities.Home;

    internal sealed class Configuration : DbMigrationsConfiguration<Vegan.Database.MyDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Vegan.Database.MyDatabase context)
        {
            Candle c1 = new Candle() { Title = "c1", Price = 1.2m, ImageURL="#1", Instructions="1-instrcut"};
            Candle c2 = new Candle() { Title = "c2", Price = 2.2m, ImageURL = "#2", Instructions = "2-instrcut" };
            Candle c3 = new Candle() { Title = "c3", Price = 3.2m, ImageURL = "#3", Instructions = "3-instrcut" };





            context.Candles.AddOrUpdate(x => x.Title, c1, c2, c3);
            context.SaveChanges();
        }
    }
}
