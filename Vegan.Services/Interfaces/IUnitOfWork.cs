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
