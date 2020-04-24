using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities
{
    public class Product
    {
        public int Id { get; set; }
       
        public decimal Price { get; set; }

        public string Title { get; set; }

        public string ImageURL { get; set; }
    }
}
