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

        public string Description { get; set; }

        // public bool Availability { get; set; } // λεω να μπει εδω γιατι ολα την εχουν και ισως θελουμε να φαινεται και οταν καποιος βαζει το προιον στο cart

        //TODO after we reach the web: to Add Review
    }
}
