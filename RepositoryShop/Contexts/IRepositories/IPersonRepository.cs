using DomainShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryShop.IRepositories
{
   public interface IPersonRepository
    {
        IEnumerable<Person> GetItemList();
        Person GetItem(string id);
        Person GetItem(long id);
        void Create(Person item);
        void Update(Person item);
        void Delete(string id);
        void Delete(long id);
        void Save();
    }
}
