using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Database;

namespace Vegan.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //============================================= Fields =============================================================
        private MyDatabase db = null;
        private DbSet<T> dbTable = null;

        //============================================= Constuctors ========================================================
        public GenericRepository()
        {
            this.db = new MyDatabase();
            this.dbTable = db.Set<T>();
        }

        public GenericRepository(MyDatabase db)
        {
            this.db = db;
            this.dbTable = db.Set<T>();
        }

        //============================================= Methods ============================================================
        public IEnumerable<T> GetAll()
        {
            return dbTable.ToList();
        }

        public T GetByID(object id)
        {
            return dbTable.Find(id);
        }

        public void Insert(T obj)
        {
            dbTable.Add(obj);
        }

        public void Update(T obj)
        {
            dbTable.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var existing = dbTable.Find(id);
            dbTable.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
