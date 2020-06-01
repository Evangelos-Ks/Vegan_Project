using System.Collections.Generic;

namespace Vegan.Services
{
    public interface OldIGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
