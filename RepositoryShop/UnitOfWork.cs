using System;
using RepositoryShop;
using RepositoryShop.Contexts;

namespace ServicesShop.Service
{
    public class UnitOfWork : IDisposable
    {
        private dbcontext db = new dbcontext();
        private SqlPropertyRepository PropertyRepository;
        private SqlPersonRepository PersonRepository;
        private SqlPurchaseRepository PurchaseRepository;

        public SqlPropertyRepository Property
        {
            get
            {
                if (PropertyRepository == null)
                    PropertyRepository = new SqlPropertyRepository(db);
                return PropertyRepository;
            }
        }

        public SqlPurchaseRepository Purchase
        {
            get
            {
                if (PurchaseRepository == null)
                    PurchaseRepository = new SqlPurchaseRepository(db);
                return PurchaseRepository;
            }
        }

        public SqlPersonRepository Person
        {
            get
            {
                if (PersonRepository == null)
                    PersonRepository = new SqlPersonRepository(db);
                return PersonRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}