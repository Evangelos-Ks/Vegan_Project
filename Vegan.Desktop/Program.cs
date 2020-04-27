using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Database;
using Vegan.Entities.Supplement;

namespace Vegan.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase myDatabase = new MyDatabase();
            foreach (var item in myDatabase.Products)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " "  + item.ImageURL);
            }

            Console.WriteLine("-------HOME-------");

            foreach (var item in myDatabase.Homes)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL + " " + item.Description );
            }

            Console.WriteLine("--------------");

            foreach (var item in myDatabase.Candles)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " +  item.ImageURL + " " + item.Description+ " " +item.Instructions  );
            }

            Console.WriteLine("--------CARE------");

            foreach (var item in myDatabase.Cares)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL + " " + item.Directions );
            }

          
            Console.WriteLine("--------------");

            foreach (var item in myDatabase.FaceCreams)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " +  item.ImageURL + " " + item.Directions + " " + item.Incrediant  );
            }

            Console.WriteLine("--------FoodHome------");

            foreach (var item in myDatabase.FoodHerbs)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL + " " + item.Description);
            }


            Console.WriteLine("--------------");

            foreach (var item in myDatabase.Teas)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL + " " + item.Description + " " + item.MoreInfo);
            }

            Console.WriteLine("--------------");

            foreach (var item in myDatabase.Spices)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL + " " + item.Description + " " + item.MyProperty);
            }

            Console.WriteLine("--------Supplement------");

            foreach (var item in myDatabase.Supplements)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL + " " + item.Information);
            }


            Console.WriteLine("--------------");

            foreach (var item in myDatabase.SuperFoods)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL + " " + item.Information + " " + item.NameOfIngridient + " " + item.ValueOfIngridient);
            }

            Console.WriteLine("--------------");

            foreach (var item in myDatabase.PowerHealths)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL + " " + item.Information + " " + item.NameOfIngridient + " " + item.ValueOfIngridient + " " + item.UseInstruction);
            }

            Console.Read();
        }
    }
}
