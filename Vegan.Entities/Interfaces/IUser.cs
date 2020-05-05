using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Entities.Library;

namespace Vegan.Entities.Interfaces
{
    public interface IUser : IGenericRepository<ApplicationUser>
    {
    }
}
