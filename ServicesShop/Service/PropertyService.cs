using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainShop;
using RepositoryShop;
using RepositoryShop.IRepositories;
using ServicesShop.Interfaces;

namespace ServicesShop.Service
{
    public class PropertyService : IService<Property>
    {
        private IRepository<Property> db;

        public PropertyService(IRepository<Property> repository)
        {
            db = repository;
        }

        public IEnumerable<Property> GetItemList()
        {
            return db.GetItemList();
        }

        public Property GetItem(int id)
        {
            return db.GetItem(id);
        }

        public void Create(Property item)
        {
            db.Create(item);
            db.Save();
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public void Update(Property item)
        {
            db.Update(item);
        }

        public void Save()
        {
            db.Save();
        }
    }
}
