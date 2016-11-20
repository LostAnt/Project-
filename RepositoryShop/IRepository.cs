using System;
using System.Collections.Generic;

namespace RepositoryShop
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetItemList();
        T GetItem(int id);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
        void Save();
    }
}