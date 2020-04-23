using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vegan.Database
{
   public  class MyDatabase : DbContext
    {
        public MyDatabase() : base("Connection")
        {

        }
    }
}
