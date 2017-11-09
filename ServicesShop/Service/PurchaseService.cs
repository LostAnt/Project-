using System.Collections.Generic;
using DomainShop;
using RepositoryShop.IRepositories;
using ServicesShop.Interfaces;

namespace ServicesShop.Service
{
    public class PurchaseService : IService<Purchase>
    {
        private IRepository<Purchase> _db;

        public PurchaseService(IRepository<Purchase> repository)
        {
            _db = repository;
        }

        public IEnumerable<Purchase> GetItemList()
        {
            return _db.GetItemList();
        }

        public Purchase GetItem(int id)
        {
            return _db.GetItem(id);
        }

        public void Create(Purchase item)
        {
            _db.Create(item);
        }

        public void Delete(int id)
        {
            _db.Delete(id);
        }

        public void Update(Purchase item)
        {
            _db.Update(item);
        }

        public void Save()
        {
            _db.Save();
        }
    }
}