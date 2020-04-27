namespace Vegan.Database.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vegan.Entities.Care;
    using Vegan.Entities.FoodHerb;
    using Vegan.Entities.Home;
    using Vegan.Entities.Supplement;
    using Size = Entities.Care.Size;
    

    internal sealed class Configuration : DbMigrationsConfiguration<Vegan.Database.MyDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Vegan.Database.MyDatabase context)
        {




            //*************************************************** Care ***************************************************

            //=================================================== FaceCream ==============================================
            FaceCream f1 = new FaceCream() { Title = "f1", Price = 1.1m, ImageURL = "#1", Incredient = "some1", Directions = "directions1", Description = "descr1" };
            FaceCream f2 = new FaceCream() { Title = "f2", Price = 2.2m, ImageURL = "#2", Incredient = "some2", Directions = "directions2", Description = "descr2"  };
            FaceCream f3 = new FaceCream() { Title = "f3", Price = 3.3m, ImageURL = "#3", Incredient = "some3", Directions = "directions3", Description = "descr3"  };

            //=================================================== Hair ===================================================
            Hair h1 = new Hair() { Title = "h1", Price = 1.1m, ImageURL = "#1", Incredient = "some1", Directions = "directions1", Description = "descr1" , Detail = "Detail1" };
            Hair h2 = new Hair() { Title = "h2", Price = 2.2m, ImageURL = "#2", Incredient = "some2", Directions = "directions2", Description = "descr2" , Detail = "Detail2" };
            Hair h3 = new Hair() { Title = "h3", Price = 3.3m, ImageURL = "#3", Incredient = "some3", Directions = "directions3", Description = "descr3" , Detail = "Detail3" };

            //=================================================== Lotions ================================================
            Lotion l1 = new Lotion() { Title = "l1", Price = 1.1m, ImageURL = "#1", Incredient = "some1", Directions = "directions1", Description = "descr1", Size = Size.Fifteen};

            
            //=================================================== ShaveBeard =============================================
            ShaveBeard sb1 = new ShaveBeard() { Title = "l1", Price = 1.1m, ImageURL = "#1", Incredient = "some1", Directions = "directions1", Description = "descr1", Information = "info1"};



            //*************************************************** FoodHerb ***********************************************
            //=================================================== Salt ===================================================
            Salt s1 = new Salt() { Title = "l1", Price = 1.1m, ImageURL = "#1", Description = "descr1", Information = "info1", BulkPricing = "b1" };

             //=================================================== Spice =================================================
            Spice sp1 = new Spice() { Title = "l1", Price = 1.1m, ImageURL = "#1", Description = "descr1", Information = "info1", BulkPricing = "b1"};

            
             //=================================================== Kitchen =========================================
            SproutingSeed ss1 = new SproutingSeed() { Title = "l1", Price = 1.1m, ImageURL = "#1", Description = "descr1", Information = "info1", Incredient = "incr 1"};


            //=================================================== Tea =====================================================
            Tea t1 = new Tea() { Title = "t1", Price = 1.1m, ImageURL = "#1", Description = "description1", MoreInformation = "Info1", Information = "info 1", Preparation = "prep1", Precautions = "p1" };
            Tea t2 = new Tea() { Title = "t2", Price = 2.2m, ImageURL = "#2", Description = "description2", MoreInformation = "Info2", Information = "info 2", Preparation = "prep2", Precautions = "p2" };
            Tea t3 = new Tea() { Title = "t3", Price = 3.3m, ImageURL = "#3", Description = "description3", MoreInformation = "Info3", Information = "info 3", Preparation = "prep3", Precautions = "p3" };




            //*************************************************** Home**** *************************************************
            //=================================================== Candle ===================================================
            Candle c1 = new Candle() { Title = "c1", Price = 1.2m, ImageURL = "#1", Instructions = "1-instrcut", Description = "descr1" };
            Candle c2 = new Candle() { Title = "c2", Price = 2.2m, ImageURL = "#2", Instructions = "2-instrcut", Description = "descr2" };
            Candle c3 = new Candle() { Title = "c3", Price = 3.2m, ImageURL = "#3", Instructions = "3-instrcut", Description = "descr3" };


            //=================================================== Essential Oil ============================================
            EssentialOil eo1 = new EssentialOil() { Title = "l1", Price = 1.1m, ImageURL = "#1", Description = "descr1", Information = "info1", Ingredient = "i1", Size = BottleSize.Fifty};


            //=================================================== HomeCleaning =============================================
            HomeCleaning hc1 = new HomeCleaning() { Title = "l1", Price = 1.1m, ImageURL = "#1", Description = "descr1", Information = "info1", About = "about1" };

            //=================================================== Kitchen ==================================================
            Kitchen k1 = new Kitchen() { Title = "l1", Price = 1.1m, ImageURL = "#1", Description = "descr1", Information = "info1", Instruction = "instr.1"};


            //*************************************************** Supplement ***********************************************
            //=================================================== PowerHealth ==============================================
            PowerHealth ph1 = new PowerHealth() { Title = "ph1", Price = 1.1m, ImageURL = "#1", Information = "Information1", NameOfIngridient = "Ingredient1", ValueOfIngridient = "1 mg", UseInstruction = "UseInstruction1" };
            PowerHealth ph2 = new PowerHealth() { Title = "ph2", Price = 2.2m, ImageURL = "#2", Information = "Information2", NameOfIngridient = "Ingredient2", ValueOfIngridient = "2 mg", UseInstruction = "UseInstruction2" };
            PowerHealth ph3 = new PowerHealth() { Title = "ph3", Price = 3.3m, ImageURL = "#3", Information = "Information3", NameOfIngridient = "Ingredient3", ValueOfIngridient = "3 mg", UseInstruction = "UseInstruction3" };

            //=================================================== SuperFood ================================================
            SuperFood sf1 = new SuperFood() { Title = "sf1", Price = 1.1m, ImageURL = "#1", Information = "Information1", NameOfIngridient = "Ingredient1", ValueOfIngridient = "1 mg" };
            SuperFood sf2 = new SuperFood() { Title = "sf2", Price = 2.2m, ImageURL = "#2", Information = "Information2", NameOfIngridient = "Ingredient2", ValueOfIngridient = "2 mg" };
            SuperFood sf3 = new SuperFood() { Title = "sf3", Price = 3.3m, ImageURL = "#3", Information = "Information3", NameOfIngridient = "Ingredient3", ValueOfIngridient = "3 mg" };


            //*************************************************** Care ***************************************************
            context.FaceCreams.AddOrUpdate(x => x.Title, f1, f2, f3);
            context.Hairs.AddOrUpdate(x => x.Title, h1, h2, h3);
            context.Lotions.AddOrUpdate(x => x.Title, l1);
            context.ShaveBeards.AddOrUpdate(x => x.Title, sb1);
            //*************************************************** FoodHerb ***********************************************
            context.Salts.AddOrUpdate(x => x.Title, s1);
            context.Spices.AddOrUpdate(x => x.Title, sp1);
            context.SproutingSeeds.AddOrUpdate(x => x.Title, ss1);
            context.Teas.AddOrUpdate(x => x.Title, t1, t2, t3);
            //*************************************************** Home ***************************************************
            context.Candles.AddOrUpdate(x => x.Title, c1, c2, c3);
            context.EssentialOils.AddOrUpdate(x => x.Title, eo1);
            context.HomeCleanings.AddOrUpdate(x => x.Title, hc1);
            context.Kitchens.AddOrUpdate(x => x.Title, k1);
            //*************************************************** Supplement *********************************************
            context.PowerHealths.AddOrUpdate(x => x.Title, ph1, ph2, ph3);
            context.SuperFoods.AddOrUpdate(x => x.Title, sf1, sf2, sf3);


            context.SaveChanges();
        }
    }
}
