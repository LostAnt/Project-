using System;
using System.Collections.Generic;
using DomainShop;

namespace RepositoryShop.IRepositories
{
    public interface IPurchaseRepository : IDisposable
    {
        IEnumerable<Purchase> GetItemList();
        Purchase GetItem(int id);
        void Create(Purchase item);
        void Delete(int id);
        void Update(Purchase item);
        void Save();
    }
}