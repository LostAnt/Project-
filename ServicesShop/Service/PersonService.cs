using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainShop;
using RepositoryShop.IRepositories;
using ServicesShop.Interfaces;

namespace ServicesShop.Service 
{
   public class PersonService : IPersonService
    {
        private IPersonRepository db;

        public PersonService(IPersonRepository repository)
        {
            db =  repository;
        }

        public IEnumerable<Person> GetItemList()
        {
            return db.GetItemList();
        }

        public Person GetItem(string id)
        {
            return db.GetItem(id);
        }

        public void Create(Person item)
        {
            db.Create(item);
        }

        public void Delete(string id)
        {
            db.Delete(id);
        }

        public void Update(Person item)
        {
            db.Update(item);
        }

        public void Save()
        {
            db.Save();
        }
    }
}
