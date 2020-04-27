namespace Vegan.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vegan.Entities.Care;
    using Vegan.Entities.FoodHerb;
    using Vegan.Entities.Home;
    using Vegan.Entities.Supplement;

    internal sealed class Configuration : DbMigrationsConfiguration<Vegan.Database.MyDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Vegan.Database.MyDatabase context)
        {
            Candle c1 = new Candle() { Title = "c1", Price = 1.2m, ImageURL = "#1", Instructions = "1-instrcut", Description = "descr1" };
            Candle c2 = new Candle() { Title = "c2", Price = 2.2m, ImageURL = "#2", Instructions = "2-instrcut", Description = "descr2" };
            Candle c3 = new Candle() { Title = "c3", Price = 3.2m, ImageURL = "#3", Instructions = "3-instrcut", Description = "descr3" };


            FaceCream f1 = new FaceCream() { Title = "f1", Price = 1.1m, ImageURL = "#1", Incrediant = "some1", Directions = "directions1" };
            FaceCream f2 = new FaceCream() { Title = "f2", Price = 2.2m, ImageURL = "#2", Incrediant = "some2", Directions = "directions2" };
            FaceCream f3 = new FaceCream() { Title = "f3", Price = 3.3m, ImageURL = "#3", Incrediant = "some3", Directions = "directions3" };


            Tea t1 = new Tea() { Title = "t1", Price = 1.1m, ImageURL = "#1", Description = "description1", MoreInfo = "Info1" };
            Tea t2 = new Tea() { Title = "t2", Price = 2.2m, ImageURL = "#2", Description = "description2", MoreInfo = "Info2" };
            Tea t3 = new Tea() { Title = "t3", Price = 3.3m, ImageURL = "#3", Description = "description3", MoreInfo = "Info3" };



            Spice sp1 = new Spice() { Title = "t1", Price = 1.1m, ImageURL = "#1", Description = "description1", MyProperty = "MyProperty1" };
            Spice sp2 = new Spice() { Title = "t2", Price = 2.2m, ImageURL = "#2", Description = "description2", MyProperty = "MyProperty2" };
            Spice sp3 = new Spice() { Title = "t3", Price = 3.3m, ImageURL = "#3", Description = "description3", MyProperty = "MyProperty3" };


            SuperFood sf1 = new SuperFood() { Title = "sf1", Price = 1.1m, ImageURL = "#1", Information = "Information1", Ingredient = "Ingredient1" };
            SuperFood sf2 = new SuperFood() { Title = "sf2", Price = 2.2m, ImageURL = "#2", Information = "Information2", Ingredient = "Ingredient2" };
            SuperFood sf3 = new SuperFood() { Title = "sf3", Price = 3.3m, ImageURL = "#3", Information = "Information3", Ingredient = "Ingredient3" };

            context.Candles.AddOrUpdate(x => x.Title, c1, c2, c3);
            context.FaceCreams.AddOrUpdate(x => x.Title, f1, f2, f3);
            context.Teas.AddOrUpdate(x => x.Title, t1, t2, t3);
            context.Spices.AddOrUpdate(x => x.Title, sp1, sp2, sp3);
            context.SuperFoods.AddOrUpdate(x => x.Title, sf1, sf2, sf3);
            context.SaveChanges();
        }
    }
}
