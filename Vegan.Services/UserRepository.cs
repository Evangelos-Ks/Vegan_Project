﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Database;
using Vegan.Entities.Interfaces;
using Vegan.Entities.Library;


namespace Vegan.Services
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUser
    {
        public UserRepository(MyDatabase context) : base(context)
        {
        }

        public MyDatabase MyDatabase
        {
            get { return Context as MyDatabase; }
        }
    }
}
