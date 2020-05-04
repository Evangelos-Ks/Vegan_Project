using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Supplement
{
    public abstract class Supplement : Product
    {
        public string Information { get; set; }

        //https://www.superfoods.eu/products/
    }
}
