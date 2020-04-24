using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Database;

namespace Vegan.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase myDatabase = new MyDatabase();
            foreach (var item in myDatabase.Products)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " "  );
            }

            Console.WriteLine("--------------");

            foreach (var item in myDatabase.Homes)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " + item.ImageURL);
            }

            Console.WriteLine("--------------");

            foreach (var item in myDatabase.Candles)
            {
                Console.WriteLine(item.Price + " " + item.Id + " " + item.Title + " " +  item.ImageURL + " " +item.Instructions  );
            }

            Console.Read();
        }
    }
}
