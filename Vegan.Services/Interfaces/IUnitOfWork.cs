using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Vegan.Services
{
    public interface IUnitOfWork<out TdbContext> where TdbContext : DbContext, new()
    {
        TdbContext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
