using System;
using System.Collections.Generic;
using System.Data.Entity;
using DomainShop;
using RepositoryShop.Contexts;

namespace RepositoryShop
{
    public class SQLPurchaseRepository : IRepository<Purchase>
    {

        private PurchaseContext _db;

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Purchase> GetItemList()
        {
            return _db.Purchases;
        }

        public Purchase GetItem(int id)
        {
            return _db.Purchases.Find(id);
        }

        public void Create(Purchase item)
        {
            _db.Purchases.Add(item);
        }

        public void Delete(int id)
        {
            Purchase purchase = _db.Purchases.Find(id);
            if (purchase != null)
            {
                _db.Purchases.Remove(purchase);
            }
        }

        public void Update(Purchase item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}