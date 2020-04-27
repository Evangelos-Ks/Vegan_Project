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
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL + " " + item.Information + " " + item.Ingredient);
            }

            Console.WriteLine("--------------");

            foreach (var item in myDatabase.PowerHealths)
            {
                //PowerHealth ph = new PowerHealth() { Price = item.Price, Id = item.Id, Title = item.Title, ImageURL = item.ImageURL, Information = item.Information, Ingredient = item.Ingredient, UseInstruction = item.UseInstruction };

                Console.Write(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL + " " + item.Information + " ");
                foreach (var ingredient in item.Ingredient)
                {
                    Console.Write(ingredient.Key + " " + ingredient.Value + " ");
                }
                Console.WriteLine(item.UseInstruction);

                //Νομίζω πως θέλει ξεχωριστό πίνακα γιατί στη βάση δεν βλέπει το value. Μια άλλη λύση είναι να βγάλουμε το dictionary και να βάλουμε δύο string στη 
                //θέση του. string NameOfIngridient και string ValueOfIngridient. Εμένα μου αρέσει αυτή η ιδέα και νομίζω πως θα μας βολέψει πολύ.
            }

            Console.Read();
        }
    }
}
