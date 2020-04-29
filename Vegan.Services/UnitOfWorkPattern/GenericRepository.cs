using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Vegan.Database;

namespace Vegan.Services
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        //============================================= Fields =============================================================
        private IDbSet<T> entities;
        private string errorMessage = string.Empty;
        private bool isDisposed;

        //============================================= Properties =========================================================
        public MyDatabase DB { get; set; }

        public virtual IQueryable<T> DbTable
        {
            get { return Entities; }
        }

        protected virtual IDbSet<T> Entities 
        { 
            get { return entities ?? (entities = DB.Set<T>()); } 
        }

        //============================================= Constuctors ========================================================
        public GenericRepository(IUnitOfWork<MyDatabase> unitOfWork) : this(unitOfWork.Context)
        {

        }

        public GenericRepository(MyDatabase db)
        {
            this.isDisposed = false;
            this.DB = db;
        }

        //============================================= Methods ============================================================      
        public virtual IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        public virtual T GetByID(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                Entities.Add(entity);
                if (DB == null || isDisposed)
                    DB = new MyDatabase();
                //Context.SaveChanges(); commented out call to SaveChanges as Context save changes will be 
                //called with Unit of work
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(errorMessage, dbEx);
            }
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }
                DB.Configuration.AutoDetectChangesEnabled = false;
                DB.Set<T>().AddRange(entities);
                DB.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                        validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (DB == null || isDisposed)
                    DB = new MyDatabase();
                SetEntryModified(entity);
                //Context.SaveChanges(); commented out call to SaveChanges as Context save changes will be called with Unit of work
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                throw new Exception(errorMessage, dbEx);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (DB == null || isDisposed)
                    DB = new MyDatabase();
                Entities.Remove(entity);
                //Context.SaveChanges(); commented out call to SaveChanges as Context save changes will be called with Unit of work
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                throw new Exception(errorMessage, dbEx);
            }
        }

        public void Dispose()
        {
            if (DB != null)
                DB.Dispose();
            isDisposed = true;
        }

        public virtual void SetEntryModified(T entity)
        {
            DB.Entry(entity).State = EntityState.Modified;
        }
    }
}
