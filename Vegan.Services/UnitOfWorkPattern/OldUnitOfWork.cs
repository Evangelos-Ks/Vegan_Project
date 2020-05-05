//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.Validation;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Vegan.Database;

//namespace Vegan.Services
//{
//    public class UnitOfWork<TdbContext> : IUnitOfWork<TdbContext>, IDisposable where TdbContext : DbContext, new()
//    {
//        //=========================================================== Fields ===============================================
//        //Here TContext is nothing but your DBContext class
//        //In our example it is MyDatabase class
//        private readonly TdbContext db;
//        private bool isDisposed;
//        private string errorMessage = string.Empty;
//        private DbContextTransaction dbContextTransaction;
//        private Dictionary<string, object> repositories;

//        //=========================================================== Constructor ==========================================
//        //Using the Constructor we are initializing the _context variable is nothing but
//        //we are storing the DBContext (MyDatabase) object in _context variable
//        public UnitOfWork()
//        {
//            this.db = new TdbContext();
//        }

//        //=========================================================== Properties ==========================++++++++++++++++++++================
//        //This Context property will return the DBContext object i.e. (MyDatabase) object
//        public TdbContext Context
//        {
//            get { return db; }
//        }


//        //=========================================================== Methods ==========================++++++++++++++++++++================

//        //If all the Transactions are completed successfuly then we need to call this Commit() 
//        //method to Save the changes permanently in the database
//        public void Commit()
//        {
//            dbContextTransaction.Commit();
//        }

//        //This CreateTransaction() method will create a database Trnasaction so that we can do database operations by
//        //applying do evrything and do nothing principle
//        public void CreateTransaction()
//        {
//            dbContextTransaction = db.Database.BeginTransaction();
//        }

//        //If atleast one of the Transaction is Failed then we need to call this Rollback() 
//        //method to Rollback the database changes to its previous state
//        public void Rollback()
//        {
//            dbContextTransaction.Rollback();
//            dbContextTransaction.Dispose();
//        }

//        //This Save() Method Implement DbContext Class SaveChanges method so whenever we do a transaction we need to
//        //call this Save() method so that it will make the changes in the database
//        public void Save()
//        {
//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbEntityValidationException dbEx)
//            {
//                foreach (var validationErrors in dbEx.EntityValidationErrors)
//                    foreach (var validationError in validationErrors.ValidationErrors)
//                        errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
//                throw new Exception(errorMessage, dbEx);
//            }
//        }

//        //The Dispose() method is used to free unmanaged resources like files, 
//        //database connections etc. at any time.
//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!isDisposed)
//            {
//                if (disposing)
//                {
//                    db.Dispose();
//                }
//            }
//            isDisposed = true;
//        }

//        public GenericRepository<T> GenericRepository<T>() where T : class
//        {
//            if (repositories == null)
//                repositories = new Dictionary<string, object>();
//            var type = typeof(T).Name;
//            if (!repositories.ContainsKey(type))
//            {
//                var repositoryType = typeof(GenericRepository<T>);
//                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), db);
//                repositories.Add(type, repositoryInstance);
//            }
//            return (GenericRepository<T>)repositories[type];
//        }
//    }
//}
